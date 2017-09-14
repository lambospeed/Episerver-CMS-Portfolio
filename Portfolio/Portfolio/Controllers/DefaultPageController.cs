using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Portfolio.Models.Pages;
using Portfolio.Models.ViewModels;
using System;

namespace Portfolio.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : PageController<SitePageData>
    {
        public ViewResult Index(SitePageData currentPage)
        {
            var model = CreateModel(currentPage);
            return View(string.Format("~/Views/{0}/Index.cshtml", currentPage.GetOriginalType().Name), model);
        }

        /// <summary>
        /// Creates a PageViewModel where the type parameter is the type of the page.
        /// </summary>
        /// <remarks>
        /// Used to create models of a specific type without the calling method having to know that type.
        /// </remarks>
        private static IPageViewModel<SitePageData> CreateModel(SitePageData page)
        {
            var type = typeof(DefaultPageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<SitePageData>;
        }
    }
}