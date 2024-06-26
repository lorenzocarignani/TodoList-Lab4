﻿using System.ComponentModel.DataAnnotations;

namespace TP_Todo_List.Data.Models
{
    public class UserDto
    {
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Address { get; set; }
    }
}
