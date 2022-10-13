using MarkupApp.Res;
using MarkupApp.Views;
using ML.Core;
using Prism.Ioc;
using Prism.Modularity;
using PrismModule;
using System.Windows;

namespace MarkupApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            ResourceService.Instance.Add(Resource.ResourceManager);
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<PrismModuleModule>();
        }
    }
}