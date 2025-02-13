namespace AcentaWebAPI.DTOs
{
    public class DeleteUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? UserTypeId { get; set; }
        public string? Password { get; set; }
    }
}
