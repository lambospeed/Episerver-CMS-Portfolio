//using System;
//using System.Linq;
//using EPiServer.Framework;
//using EPiServer.Framework.Initialization;
//using EPiServer.Core;
//using EPiServer;
//using EPiServer.ServiceLocation;

//namespace Bookshelf.Business.Skills
//{
//    [InitializableModule]
//    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
//    public class SkillInitialization : IInitializableModule
//    {
//        private bool _eventsAttached = false;

//        public void Initialize(InitializationEngine context)
//        {
//            //Add initialization logic, this method is called once after CMS has been initialized
//            if (!_eventsAttached)
//            {
//                ServiceLocator.Current.GetInstance<IContentEvents>().PublishingContent += new EventHandler<ContentEventArgs>(PublishingWritableContent);
//                _eventsAttached = true;
//            }
//        }

//        public void Preload(string[] parameters) { }

//        public void Uninitialize(InitializationEngine context)
//        {
//            //Add uninitialization logic
//            ServiceLocator.Current.GetInstance<IContentEvents>().PublishingContent -= new EventHandler<EPiServer.ContentEventArgs>(PublishingWritableContent);
//        }

//        public static void PublishingWritableContent(object sender, ContentEventArgs e)
//        {
//            var content = e.Content as IWritableContent;
//            if (content == null)
//                return;

//            content.ConfigureSkillSettings();
//        }
//    }
//}