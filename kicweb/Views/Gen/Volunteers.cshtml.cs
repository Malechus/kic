using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KiCWeb.Views.Gen
{
    public class Volunteers : PageModel
    {
        private readonly ILogger<Volunteers> _logger;

        public Volunteers(ILogger<Volunteers> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}