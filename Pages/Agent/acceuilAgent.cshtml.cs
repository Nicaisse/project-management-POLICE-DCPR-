using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TESTASP_DCPR.Pages.Agent
{
    public class acceuilAgent : PageModel
    {
        private readonly ILogger<acceuilAgent> _logger;

        public acceuilAgent(ILogger<acceuilAgent> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}