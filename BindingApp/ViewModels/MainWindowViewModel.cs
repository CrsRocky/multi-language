using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace BindingApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Binding Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string current = "zh-CN";

        public DelegateCommand LanguageChangeCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            LanguageChangeCommand = new DelegateCommand(LanguageChange);
        }

        void LanguageChange()
        {
            if (current == "zh-CN")
            {
                ResourceServiceSingleton.Current.ChangedCulture("en-US");
                current = "en-US";
            }
            else
            {
                ResourceServiceSingleton.Current.ChangedCulture("zh-CN");
                current = "zh-CN";
            }
        }
    }
}