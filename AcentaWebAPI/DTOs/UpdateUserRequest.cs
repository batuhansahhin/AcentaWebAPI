namespace AcentaWebAPI.DTOs
{
    public class UpdateUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? UserTypeId { get; set; }
        public string? Password { get; set; }
    }
}
