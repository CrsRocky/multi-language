using ML.Core;
using Prism.Ioc;
using Prism.Modularity;
using PrismModule.ViewModels;
using PrismModule.Views;

namespace PrismModule
{
    public class PrismModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ResourceService.Instance.Add(Res.Resource.ResourceManager);
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}