﻿using System.ComponentModel.DataAnnotations;

namespace AcentaWebAPI.DataTO
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
