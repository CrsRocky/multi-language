using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace BindingApp
{
    public class ResourceServiceSingleton : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly ResourceServiceSingleton _current = new ResourceServiceSingleton();
        public static ResourceServiceSingleton Current => _current;

        private readonly Properties.Resources resources = new Properties.Resources();
        public Properties.Resources Resources => resources;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ChangedCulture(string name)
        {
            Properties.Resources.Culture = CultureInfo.GetCultureInfo(name);
            this.RaisePropertyChanged("Resources");
        }
    }
}