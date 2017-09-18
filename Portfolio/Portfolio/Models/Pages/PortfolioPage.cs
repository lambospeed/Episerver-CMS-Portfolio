using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer;
using Portfolio.Models.Blocks;
using EPiServer.Web;
using Portfolio.Business.Skills;

namespace Portfolio.Models.Pages
{
    [ContentType(DisplayName = "Portfolio Page", GUID = "81fedefb-c622-4179-8767-a121bbb3e377", Description = "")]
    public class PortfolioPage : SitePageData
    {
       
        [UIHint(UIHint.BlockFolder)]
        [Display(
           Name = "Skills folder",
           Description = "Folder used as root for skills. If not set, skill function will be disabled",
           GroupName = SystemTabNames.Settings,
           Order = 30)]
        public virtual ContentReference SkillFolder { get; set; }

        [UIHint(UIHint.BlockFolder)]
        [Display(
           Name = "Header folder",
           Description = "Folder used as root for header. If not set, header function will be disabled",
           GroupName = SystemTabNames.Settings,
           Order = 40)]
        public virtual ContentReference HeaderFolder { get; set; }

        //public void ConfigureSkillSettings()
        //{
        //    if (!ContentReference.IsNullOrEmpty(this.SkillFolder))
        //        return;

        //    var contentRepository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();
        //    var newSkillFolder = SkillHandler.AddNewSkillFolder(contentRepository, this);
        //    if (newSkillFolder == null)
        //        return;

        //    var editablePortfolioPage = this.CreateWritableClone() as PortfolioPage;

        //    editablePortfolioPage.SkillFolder = newSkillFolder.ContentLink;

        //    contentRepository.Save(editablePortfolioPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.Publish);
        //}
    }
}