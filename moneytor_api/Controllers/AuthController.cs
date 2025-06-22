using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using moneytor_api.Entities;
using moneytor_api.Models.DTOModels;
using moneytor_api.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace moneytor_api.Controllers
{
    [Route("Moneytor/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new User();

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("Username already exists.");
            }

            return Ok(user);
        }

        #region LOGIN ENDPOINT
        //Main endpoint for login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            //Call login service async. Returns the access & refresh tokens and user info once login is successful; null if login fails.
            var result = await authService.LoginAsync(request);
            if (result is null)
            {
                return BadRequest("Username or Password is Invalid.");
            }

            SetAccessTokenCookie(result.AccessToken);   // Set access token in HttpOnly cookie
            SetRefreshTokenCookie(result.RefreshToken); // Set refresh token in HttpOnly cookie

            // Return user info but not the tokens (they're in cookies now)
            return Ok(new      
            {
                userId = result.UserId,
                username = result.Username,
                role = result.Role
            });
        }

        private void SetAccessTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // for HTTPS
                SameSite = SameSiteMode.None,
                Expires = authService.GetTokenExpiryTimeAsync("Access").Result,
            };

            Response.Cookies.Append("access_token", token, cookieOptions);
        }

        private void SetRefreshTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // for HTTPS
                SameSite = SameSiteMode.None,
                Expires = authService.GetTokenExpiryTimeAsync("Refresh").Result,
            };

            Response.Cookies.Append("refresh_token", token, cookieOptions);
        }
        #endregion




        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var refreshToken = Request.Cookies["refresh_token"];    //Retrieve refresh token from HttpOnly Cookies
            request.RefreshToken = refreshToken ?? "";
            var result = await authService.RefreshTokensAsync(request);
            if(result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return Unauthorized("Invalid refresh token.");
            }

            SetAccessTokenCookie(result.AccessToken);   // Set access token in HttpOnly cookie
            SetRefreshTokenCookie(result.RefreshToken); // Set refresh token in HttpOnly cookie

            // Return user info but not the tokens (they're in cookies now)
            return Ok(new
            {
                token = result.AccessToken,
                userId = result.UserId,
                username = result.Username,
                role = result.Role
            });
        }


        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok(
                new { status = 1, message = "You are authenticated.", data = new { } 
                });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are an Admin!");
        }
    }
}
