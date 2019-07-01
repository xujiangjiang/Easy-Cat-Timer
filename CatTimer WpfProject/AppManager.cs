/* 项目：猫咪计时器(Easy Cat Timer)
   制作者：絮大王、瓜指导
   美术：絮大王
   程序：絮大王
   邮箱：sukiup@163.com
   完成时间：v0.0.1版本 2019年6月18日13:01:51*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// App的管理类 (入口类)
    /// </summary>
    public static class AppManager
    {
        private static App mainApp;//App的逻辑
        private static MainWindow mainWindow;//窗口的逻辑

        /* 数据 */
        private static AppDatas appDatas = new AppDatas();//App中的所有数据

        /* 子系统 */
        private static AppSystems appSystems = new AppSystems();//App中的所有系统



        #region 公开属性
        /// <summary>
        /// App的逻辑
        /// </summary>
        public static App MainApp
        {
            get { return mainApp; }
            set { mainApp = value; }
        }

        /// <summary>
        /// 窗口的逻辑
        /// </summary>
        public static MainWindow MainWindow
        {
            get { return mainWindow; }
            set { mainWindow = value; }
        }

        /// <summary>
        /// App中的所有的数据
        /// </summary>
        public static AppDatas AppDatas
        {
            get { return appDatas; }
        }


        /// <summary>
        /// App中的所有系统
        /// </summary>
        public static AppSystems AppSystems
        {
            get { return appSystems; }
        }
        #endregion


        #region 初始化
        /// <summary>
        /// 初始化程序
        /// </summary>
        public static void Start()
        {
            //数据绑定赋值
            MainWindow.DataContext = AppDatas;

            //读取读取数据
            AppSystems.SaveSystem.Load();

        }
        #endregion
    }
}
