using ML.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismModule.Views;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Restart.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Restart Application";

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
            ApplicationRestart();
        }

        void ApplicationRestart()
        {
            IniFile iniFile = new IniFile(App.ApplicationIniFile);
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentUICulture;
            switch (cultureInfo.Name)
            {
                case App.ZH_CN:
                    iniFile.WriteString("Application", "Language", App.EN_US);
                    break;

                case App.EN_US:
                    iniFile.WriteString("Application", "Language", App.ZH_CN);
                    break;
            }
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Application.Current.Shutdown();
        }
    }
}