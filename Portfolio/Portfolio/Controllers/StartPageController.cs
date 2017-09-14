using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Portfolio.Models.Pages;
using Portfolio.Models.ViewModels;

namespace Portfolio.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            DefaultPageViewModel<StartPage> model = new DefaultPageViewModel<StartPage>(currentPage);

            return View(model);
        }
    }
}