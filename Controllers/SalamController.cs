
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    [Route("Salam")]
    public class SalamController : Controller
    {
        public string Index()
        {
            return "Ini Controller salam!";
        }

        [Route("Welcome/{name}/{job}")]
        public string Welcome(string name, string job)
        {
            return HtmlEncoder.Default.Encode($"Hello, nama saya {name} & job {job}");
        }

    }
}