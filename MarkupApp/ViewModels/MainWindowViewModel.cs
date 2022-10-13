using ML.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismModule.Views;
using System.Globalization;
using System.Threading;

namespace MarkupApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand LanguageChangeCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            LanguageChangeCommand = new DelegateCommand(LanguageChange);
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        void LanguageChange()
        {
            string lan = "en-US";
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo(lan);//设置默认
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(lan);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(lan);//设置当前
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lan);

            ResourceService.Instance.CurrentUICulture = new System.Globalization.CultureInfo(lan);
        }
    }
}