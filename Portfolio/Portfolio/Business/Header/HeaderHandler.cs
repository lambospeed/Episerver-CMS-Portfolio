using Portfolio.Models.Blocks;
using EPiServer;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Business.Header
{
    public class HeaderHandler
    {
        private IContentRepository _contentRepository;

        public HeaderHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public void AddHeader(ContentReference headerFolderReference, string pic, string fullname, string address, string headline, string business, string summary)
        {
            AddedHeader newHeaderBlock = _contentRepository.GetDefault<AddedHeader>(headerFolderReference);
            newHeaderBlock.PersonImage = pic;
            newHeaderBlock.FullName = fullname;
            newHeaderBlock.Headline = headline;
            newHeaderBlock.Address = address;
            newHeaderBlock.LineOfBusiness = business;
            newHeaderBlock.Summary = summary;
            IContent newHeaderBlockInstance = newHeaderBlock as IContent;
            newHeaderBlockInstance.Name = fullname;
            _contentRepository.Save(newHeaderBlockInstance, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.Publish);
        }

        public IEnumerable<AddedHeader> LoadHeader(ContentReference headerFolderReference)
        {
            if (ContentReference.IsNullOrEmpty(headerFolderReference))
                return null;

            var filterContentForVisitor = new EPiServer.Filters.FilterContentForVisitor(
                    EPiServer.Framework.Web.TemplateTypeCategories.MvcPartialView,
                    string.Empty);

            var allHeaders = _contentRepository.GetChildren<IContent>(headerFolderReference).ToList();
            filterContentForVisitor.Filter(allHeaders);

            return allHeaders.Cast<AddedHeader>();
        }

        public bool CurrentUserHasHeaderPublishAccess(ContentReference headerFolderReference)
        {
            if (ContentReference.IsNullOrEmpty(headerFolderReference))
                return false;

            IContent headerFolder = _contentRepository.Get<ContentFolder>(headerFolderReference);
            if (headerFolder == null)
                return false;

            return headerFolder.QueryDistinctAccess(EPiServer.Security.AccessLevel.Publish);
        }

        public bool HeaderFolderIsSet(ContentReference headerFolderReference)
        {
            return !ContentReference.IsNullOrEmpty(headerFolderReference);
        }

        public void DeleteHeader(ContentReference headerReference)
        {
            if (ContentReference.IsNullOrEmpty(headerReference))
                throw new NullReferenceException();

            _contentRepository.MoveToWastebasket(
                 headerReference, "inlogged user");
        }

    }
}