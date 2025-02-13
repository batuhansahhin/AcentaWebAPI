using System.ComponentModel.DataAnnotations;

namespace AcentaWebAPI.DataTO
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ad zorunludur.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kullanıcı tipi seçmelisiniz.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kullanıcı tipi seçmelisiniz.")]
        public int UserTypeId { get; set; }
    }
}
