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
using System.Windows.Shell;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// YellowCatControl.xaml 的交互逻辑
    /// </summary>
    public partial class YellowCatControl : UserControl
    {
        public YellowCatControl()
        {
            InitializeComponent();
        }


        /* 变量 */
        private bool isPauseButton = true;//猫咪的按钮是否是[暂停]按钮？如果为true，表示当前是暂停按钮；如果为false，表示当前是恢复按钮


        #region 公开属性
        /// <summary>
        /// 当前猫咪的按钮是否是[暂停]按钮？
        /// 如果为true，表示当前是暂停按钮；如果为false，表示当前是恢复按钮
        /// </summary>
        public bool IsPauseButton
        {
            get { return isPauseButton; }
            set
            {
                isPauseButton = value; 

                //更改按钮的文字
                if (value == true)
                {
                    PauseBorder.Opacity = 1;
                    ResumeBorder.Opacity = 0;
                }
                else
                {
                    PauseBorder.Opacity = 0;
                    ResumeBorder.Opacity = 1;
                }
            }
        }
        #endregion


        #region [注册的的事件]
        //当点击猫咪按钮的时候，触发此方法
        private void CatButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            /* 通知窗口 相关 */
            AppManager.AppSystems.NotificationSystem.CloseAllNotification();//关闭所有的通知窗口

            /* 如果当前的按钮是[暂停按钮] */
            if (IsPauseButton == true)
            {
                // 就打开暂停界面，并且让倒计时暂停
                AppManager.AppSystems.TimeSystem.PauseHandle();
                AppManager.MainWindow.PausedUiUserControl.OpenOrClose(true);

                // 然后把猫咪的按钮，变成[恢复按钮]
                IsPauseButton = false;

                // 进度条变红
                AppManager.AppSystems.TaskbarSystem.SetProgressState(TaskbarItemProgressState.Error);
            }

            /* 如果当前的按钮是[恢复按钮] */
            else
            {
                // 就关闭暂停界面，并且让倒计时继续
                AppManager.AppSystems.TimeSystem.UnPauseHandle();
                AppManager.MainWindow.PausedUiUserControl.OpenOrClose(false);

                // 然后把猫咪的按钮，变成[暂停按钮]
                IsPauseButton = true;

                // 进度条变黄
                AppManager.AppSystems.TaskbarSystem.SetProgressState(TaskbarItemProgressState.Paused);
            }

            //播放音效
            AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.DefaultButtonUp);

        }


        //当鼠标进入[猫咪身体]时
        private void CatGrid_OnMouseEnter(object sender, MouseEventArgs e)
        {
            //播放音效
            AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.CatUp);
        }

        //当鼠标移出[猫咪身体]时
        private void CatGrid_OnMouseLeave(object sender, MouseEventArgs e)
        {
            //播放音效
            AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.CatDown);
        }
        #endregion


    }
}
