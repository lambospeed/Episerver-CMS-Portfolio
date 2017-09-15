using Portfolio.Models.Blocks;
using Portfolio.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Business.Skills
{
    public class SkillHandler
    {
        private IContentRepository _contentRepository;

        public SkillHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public void AddSkill(ContentReference skillFolderReference, string skill)
        {
            AddedSkill newSkillBlock = _contentRepository.GetDefault<AddedSkill>(skillFolderReference);

            newSkillBlock.Skill = skill;
          
            IContent newSkillBlockInstance = newSkillBlock as IContent;
            newSkillBlockInstance.Name = skill;

            _contentRepository.Save(newSkillBlockInstance, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.FullAccess);
        }

        public IEnumerable<AddedSkill> LoadSkills(ContentReference skillFolderReference)
        {
            if (ContentReference.IsNullOrEmpty(skillFolderReference))
                return null;

            var filterContentForVisitor = new EPiServer.Filters.FilterContentForVisitor(
               EPiServer.Framework.Web.TemplateTypeCategories.MvcPartialView,
               string.Empty);

            var allSkills = _contentRepository.GetChildren<IContent>(skillFolderReference).ToList<IContent>();

            filterContentForVisitor.Filter(allSkills);

            return allSkills.Cast<AddedSkill>().OrderBy(skill => skill.Skill);
        }

        //public static ContentFolder AddNewSkillFolder(IContentRepository contentRepository, IContent contentItemToSkill)
        //{
        //    var rootFolderReference = contentRepository.Get<StartPage>(ContentReference.StartPage).SkillRoot;

        //    if (ContentReference.IsNullOrEmpty(rootFolderReference))
        //        return null;

        //    var newSkillFolder = contentRepository.GetDefault<ContentFolder>(rootFolderReference);

        //    newSkillFolder.Name = contentItemToSkill.Name;
        //    contentRepository.Save(newSkillFolder, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.Publish);

        //    return newSkillFolder;
        //}

        public bool CurrentUserHasSkillPublishAccess(ContentReference skillFolderReference)
        {
            if (ContentReference.IsNullOrEmpty(skillFolderReference))
                return false;

            IContent skillFolder = _contentRepository.Get<ContentFolder>(skillFolderReference);
            if (skillFolder == null)
                return false;

            return skillFolder.QueryDistinctAccess(EPiServer.Security.AccessLevel.Publish);
        }


        public bool SkillFolderIsSet(ContentReference skillFolderReference)
        {
            return !ContentReference.IsNullOrEmpty(skillFolderReference);
        }

        public void DeleteSkill(ContentReference skillReference)
        {
            if (ContentReference.IsNullOrEmpty(skillReference))
                throw new NullReferenceException();

            _contentRepository.MoveToWastebasket(
                skillReference, "inlogged user");
        }


        //public void DeleteSkill(ContentReference skillReference)
        //{
        //    if (ContentReference.IsNullOrEmpty(skillReference))
        //        throw new NullReferenceException();

        //    AddedSkill deletedSkill = _contentRepository.Get<AddedSkill>(skillReference);
        //    var skillToUpdate = deletedSkill.CreateWritableClone() as IVersionable;

        //    skillToUpdate.StopPublish = DateTime.Now;

        //    _contentRepository.Save(
        //        skillToUpdate as IContent,
        //        EPiServer.DataAccess.SaveAction.Publish,
        //        EPiServer.Security.AccessLevel.Read);
        //}

    }
}