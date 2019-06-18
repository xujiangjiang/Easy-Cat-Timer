using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //当程序启动完成时，触发此方法
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            AppManager.MainApp = this;
        }
    }
}
