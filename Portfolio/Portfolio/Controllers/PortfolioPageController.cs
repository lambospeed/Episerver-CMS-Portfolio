using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Portfolio.Models.Pages;
using Portfolio.Models.ViewModels;
using Portfolio.Business.Skills;
using Portfolio.Business.Header;

namespace Portfolio.Controllers
{
    public class PortfolioPageController : PageControllerBase<PortfolioPage>
    {
        private SkillHandler _skillHandler;
        private HeaderHandler _headerHandler;

        public PortfolioPageController(SkillHandler skillHandler, HeaderHandler headerHandler)
        {
            _skillHandler = skillHandler;
            _headerHandler = headerHandler;
        }

        public ActionResult Index(PortfolioPage currentPage)
        {
            var model = new PortfolioPageViewModel(currentPage)
            {
                SkillList = _skillHandler.LoadSkills(currentPage.SkillFolder),
                HasSkillPublishAccess = _skillHandler.CurrentUserHasSkillPublishAccess(currentPage.SkillFolder),
                SkillFolderIsSet = _skillHandler.SkillFolderIsSet(currentPage.SkillFolder),

                HeaderPart = _headerHandler.LoadHeader(currentPage.HeaderFolder),
                HasHeaderPublishAccess = _headerHandler.CurrentUserHasHeaderPublishAccess(currentPage.HeaderFolder),
                HeaderFolderIsSet = _headerHandler.HeaderFolderIsSet(currentPage.HeaderFolder)
            };

            return View(model);
        }   
        //--------------------skills----------------------------
        [HttpPost]
        public ActionResult CreateSkill(PortfolioPage currentPage, string Skill)
        {
            _skillHandler.AddSkill(currentPage.SkillFolder, Skill);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(ContentReference skillReference)
        {
            _skillHandler.DeleteSkill(skillReference);

            return RedirectToAction("Index");
        }
        //---------------------skills   ends----------------------

        //---------------------header----------------------------
        [HttpPost]
        public ActionResult CreateHeader(PortfolioPage currentPage, string PersonImage, string FullName, string Headline, string Address, string LineOfBusiness, string Summary)
        {
            _headerHandler.AddHeader(currentPage.HeaderFolder, PersonImage, FullName, Headline, Address, LineOfBusiness, Summary);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeader(ContentReference headerReference)
        {
            _headerHandler.DeleteHeader(headerReference);

            return RedirectToAction("Index");
        }
    }
}