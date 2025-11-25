
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class SalamController : Controller
    {
        [Route("Salam")]
        public string Index()
        {
            return "Ini Controller salam!";
        }

        [Route("Welcome/{name}/{job}")]
        public string Welcome(string name, string job)
        {
            return HtmlEncoder.Default.Encode($"Hello, nama saya {name} & job {job}");
        }

        public IActionResult About()
        {
            ViewData["nama"] = "Ihsan Miftahul Huda";
            ViewData["divisi"] = "Education & Training";
            ViewData["role"] = "Trainer";

            return View();
        }

    }
}