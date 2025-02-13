namespace AcentaWebAPI.DTOs
{
    public class JwtSettings
    {
        public string Key { get; set; } = null!;
        public string Issuer { get; set; } = null!; //JWT VEREN
        public string Audience { get; set; } = null!;
        public int ExpireMinutes { get; set; }
    }
}
