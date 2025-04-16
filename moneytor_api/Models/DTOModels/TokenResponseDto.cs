namespace moneytor_api.Models.DTOModels
{
    public class TokenResponseDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public required Guid UserId { get; set; }
        public required string Username { get; set; }
        public required string Role { get; set; }
    }
}
