﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCData.Models
{
    public class Vendor

    {
        [Required]
        [Display(Name = "Your Fetlife handle. (Put N/A if you don't use Fetlife.")]
        public string? FetName { get; set; }

        [Required]
        [Display(Name  = "Your business or professional name.")]
        public string? PublicName { get; set; }

        [Required]
        [Display(Name = "Your email address.")]
        public string? EmailAddress { get; set; }

        [Required]
        [Display(Name = "About your business.")]
        public string? Bio { get; set; }

        public DateOnly? LastAttended { get; set; }
    }
}
