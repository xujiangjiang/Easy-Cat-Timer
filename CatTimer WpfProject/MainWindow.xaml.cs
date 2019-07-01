using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        //当窗口初始化时，触发此方法
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //赋值
            AppManager.MainWindow = this;

            //初始化
            AppManager.Start();
        }



        #region 拖动窗口

        /// <summary>
        /// 当在窗口顶部的矩形中，按下鼠标左键的时候：拖动窗口的时候
        /// </summary>
        private void WindowTitleBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//拖动窗口
        }




        /// <summary>
        /// 当点击[关闭窗口]的按钮时
        /// </summary>
        private void CloseWindowButton_Click(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.Close();//关闭此窗口
        }

        /// <summary>
        /// 当点击[最小化窗口]的按钮时
        /// </summary>
        private void MinimumWindowButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.WindowState = WindowState.Minimized; //最小化此窗口
        }
        #endregion

        #region 注册事件 -[其他]
        //当点击了[键盘上的按键]时
        private void MainWindow_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            //如果点击的是[回车]键，并且[计时（设定时间）]的界面是开启的
            if (e.KeyStates == Keyboard.GetKeyStates(Key.Return) && AppManager.MainWindow.TimingUserControl.Visibility == Visibility.Visible)
            {

                //播放音效
                AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.DefaultButtonUp);

                //开始计时
                AppManager.MainWindow.TimingUserControl.StartTimer();
            }
        }
        #endregion
    }
}
