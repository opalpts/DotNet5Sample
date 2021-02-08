using DotNet5Sample.Core.Context;
using DotNet5Sample.Core.Repositories;
using DotNet5Sample.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHome _home;
        public HomeController(IHome home)
        {
            _home = home;
        }

        public IEnumerable<DetailViewModels.OfferViewModel> GetTable()
        {
            var data = _home.GetTable();
            return data;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
