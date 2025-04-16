using moneytor_api.Entities;
using moneytor_api.Models.DTOModels;

namespace moneytor_api.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
        Task<DateTime> GetTokenExpiryTimeAsync(string tokenType);
    }
}
