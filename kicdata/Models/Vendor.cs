﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCData.Models
{
    public class Vendor

    {
        public string? FetName { get; set; }

        public string? Details { get; set; }

        public string? Notes { get; set; }

        public DateOnly? LastAttended { get; set; }
    }
}