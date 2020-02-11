using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _OrnekProje.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, MaxLength(30)]
        public string EMail { get; set; }

        [DataType(DataType.Password)]
        [Required, MaxLength(16)]
        public string Password { get; set; }
    }
}