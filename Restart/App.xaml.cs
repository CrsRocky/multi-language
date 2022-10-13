using ML.Core;
using Prism.Ioc;
using Prism.Modularity;
using PrismModule;
using Restart.Views;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Restart
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static string ApplicationIniFile => AppDomain.CurrentDomain.BaseDirectory + "Setting.ini";
        public const string ZH_CN = "zh-CN";
        public const string EN_US = "en-US";

        App()
        {
            this.Startup += new StartupEventHandler(App_Startup);//首先注册开始和退出事件
            this.Exit += new ExitEventHandler(App_Exit);
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Environment.Exit(0);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            IniFile iniFile = new(ApplicationIniFile);
            string lan = iniFile.ReadString("Application", "Language", ZH_CN);
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo(lan);//设置默认
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(lan);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(lan);//设置当前
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lan);
        }

        protected override Window CreateShell()
        {
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