using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TESTASP_DCPR.Pages.conducteurs
{
    public class SERVICE_AGENT : PageModel
    {
        private readonly ILogger<SERVICE_AGENT> _logger;

        public SERVICE_AGENT(ILogger<SERVICE_AGENT> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}