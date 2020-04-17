using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CORE_IMPERSONATE.Models;
using Microsoft.AspNetCore.Hosting;
using AspNetCore.Impersonation;

namespace CORE_IMPERSONATE.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment env;
        public HomeController(IHostingEnvironment env)
        {
            if (env == null)
                throw new ArgumentNullException(nameof(env));

            this.env = env;
        }
        public IActionResult Index()
        {
            ImpersonateFunction.Run(
                  () => { 
                      //..... Acciones en el nuevo contexto
                  },
                  env);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
