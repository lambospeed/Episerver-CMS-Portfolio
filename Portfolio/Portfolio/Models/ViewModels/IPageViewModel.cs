using EPiServer.Core;
using Portfolio.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData 
    {
        T CurrentPage { get; }
        IContent Section { get; }
    }
}
