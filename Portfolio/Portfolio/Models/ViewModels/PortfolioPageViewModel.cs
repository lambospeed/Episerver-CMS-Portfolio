using Portfolio.Models.Blocks;
using Portfolio.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;

namespace Portfolio.Models.ViewModels
{
    public class PortfolioPageViewModel : IPageViewModel<PortfolioPage>
    {
        public PortfolioPage CurrentPage { get; set; }
        public IEnumerable<AddedSkill> SkillList { get; set; }
        public IEnumerable<AddedHeader> HeaderPart { get; set; }

        public bool HasSkillPublishAccess { get; set; }
        public bool SkillFolderIsSet { get; set; }

        public bool HasHeaderPublishAccess { get; set; }
        public bool HeaderFolderIsSet { get; set; }


        public PortfolioPageViewModel(PortfolioPage currentPage)
        {
            CurrentPage = currentPage;
        }



        public IContent Section
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}