using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// NotificationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NotificationWindow : Window
    {
        public NotificationWindow()
        {
            InitializeComponent();
        }


        /* 变量 */
        //弹出通知框的底部应该在WorkArea（工作区）的哪个位置？
        public double topFrom;

        //水平间距：通知窗口和屏幕最右边 的间距
        public int horizontalSpacing = 5;

        //用来设置动画的持续时间（单位：秒）
        private float animationTime = 0.35f;

        //通知的显示时间（单位：秒）（通知显示多少秒后消失？）
        private float showTime = 0f;


        /* 容器 */
        private double windowWidth = 400;//窗口的宽度




        /// <summary>
        /// 当通知窗口加载完毕的时候
        /// </summary>
        private void NotificationWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //打开通知窗口
            OpenNotification(sender as NotificationWindow);
        }


        /// <summary>
        /// 当点击按钮时
        /// </summary>
        private void CloseButton_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //关闭通知窗口
            CloseNotification();
        }



        #region 私有方法
        /// <summary>
        /// 显示通知窗口
        /// </summary>
        /// <param name="_notificationWindow">要显示的通知窗口</param>
        private void OpenNotification(NotificationWindow _notificationWindow)
        {
            //让[任务栏进度条]闪烁
            AppManager.AppSystems.TaskbarSystem.SetProgressTwinkling(true);

            //获取这个窗口
            NotificationWindow self = _notificationWindow;

            //如果这个窗口不为null
            if (self != null)
            {
                self.UpdateLayout();

                //获取窗口的宽度
                //windowWidth = self.Width;

                //播放提示声
                AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.Complete);

                //计算窗口多久消失
                showTime = AppManager.AppSystems.AudioSystem.CompleteAudioLength + 2f;

                /* 计算窗口出现的位置 */
                //获取工作区最右边的值
                double right = System.Windows.SystemParameters.WorkArea.Right;
                self.Top = self.topFrom - self.ActualHeight;
                self.Left = right - self.ActualWidth - horizontalSpacing;

                /* 动画 */
                DoubleAnimation animation = new DoubleAnimation();

                //animationTime，用来设置动画的持续时间
                animation.Duration =
                    new Duration(TimeSpan.FromSeconds(animationTime));
                animation.From = windowWidth;
                //设定通知从右往左弹出
                /* 注意：这里的horizontalSpacing代表离屏幕右边的距离，
                        这个值越大，那么窗口离屏幕右边越远*/
                animation.To = 0;
                animation.EasingFunction = new SineEase();
                //设定动画应用于窗体的Left属性
                self.NotificationGrid.BeginAnimation(Canvas.LeftProperty, animation);

                Task.Factory.StartNew(delegate
                {
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(showTime));
                    //Invoke到主进程中去执行
                    Invoke(self, delegate {
                        CloseNotification();//关闭通知窗口
                    });
                });
            }
        }


        /// <summary>
        /// 关闭通知窗口
        /// </summary>
        public void CloseNotification()
        {
            //停止提示声
            AppManager.AppSystems.AudioSystem.StopAudio(AudioType.Complete);

            //当点击按钮时，让通知窗口从左往右回收，
            //并且动画执行完毕后，关闭当前窗体
            double right = System.Windows.SystemParameters.WorkArea.Right;
            DoubleAnimation animation = new DoubleAnimation();
            animation.Duration =
                new Duration(TimeSpan.FromSeconds(animationTime));

            animation.Completed += (s, a) => { this.Close(); };
            animation.From = 0;
            animation.To = windowWidth;//通知从左往右收回
            animation.EasingFunction = new SineEase();
            this.NotificationGrid.BeginAnimation(Canvas.LeftProperty, animation);

            //让[任务栏进度条]停止闪烁
            AppManager.AppSystems.TaskbarSystem.SetProgressTwinkling(false);
            AppManager.AppSystems.TaskbarSystem.SetProgressState(TaskbarItemProgressState.Paused);
        }


        static void Invoke(Window win, Action a)
        {
            win.Dispatcher.Invoke(a);
        }
        #endregion
    }
}
