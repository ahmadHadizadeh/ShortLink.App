using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortLink.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using ShortLink.Data;

namespace ShortLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShortLinkContext _context;

        public HomeController(ShortLinkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Product);
        }

        [Route("Product/{id}/{title}")]
        public IActionResult ShowProduct(int id, string title)
        {
            return View(_context.Product.Find(id));
        }

        [Route("p/{key}")]
        public IActionResult ReudirectShowProduct(string key)
        {
            var product = _context.Product
                .SingleOrDefault(s => s.Shortkey == key);
            if (product == null)
            {
                return NotFound();
            }

            Uri uri = new Uri("http://localhost:2894" + "/product/" +
                              product.ShortId + "/" + product.Title.Trim().Replace(" ", "-"));
            return Redirect(uri.AbsoluteUri);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}