using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 通知系统
    /// </summary>
    public class NotificationSystem
    {
        /* 变量 */
        //所有的通知窗口
        private static List<NotificationWindow> notificationWindows
            = new List<NotificationWindow>();

        //垂直间距：2个通知窗口之间的间距
        private int verticalSpacing = 10;

        //水平间距：通知窗口和屏幕最右边 的间距
        private int horizontalSpacing = 10;




        /// <summary>
        /// 显示一个通知窗口
        /// （显示一条通知）
        /// </summary>
        public void ShowNotification()
        {
            //new 一个通知窗口
            NotificationWindow notificationWindow = new NotificationWindow();

            //当窗口关闭时，触发什么方法？
            notificationWindow.Closed += NotificationWindow_Closed;

            //计算窗口的底部位置（窗口的底部在屏幕的什么位置？）
            notificationWindow.topFrom = GetTopFrom();
            notificationWindow.horizontalSpacing = horizontalSpacing;

            //把窗口添加到列表中
            notificationWindows.Add(notificationWindow);

            //显示窗口
            notificationWindow.Show();
        }




        #region 私有方法
        /// <summary>
        /// 当[通知窗口]关闭时，触发此方法
        /// </summary>
        private void NotificationWindow_Closed(object sender, EventArgs e)
        {
            //把此通知窗口从列表中移出
            var closedDialog = sender as NotificationWindow;
            notificationWindows.Remove(closedDialog);
        }


        /// <summary>
        /// 用来获取弹出通知框的底部应该在WorkArea（工作区）的哪个位置
        /// </summary>
        private double GetTopFrom()
        {
            //屏幕的高度-底部TaskBar的高度。
            double topFrom =
                System.Windows.SystemParameters.WorkArea.Bottom - 45;
            bool isContinueFind =
                notificationWindows.Any(o => o.topFrom == topFrom);

            while (isContinueFind)
            {
                //此处141是NotifyWindow的高
                //如果你希望通知窗口之间的间距变大，就把这个verticalSpacing的值，变大点
                topFrom = topFrom - 141 - verticalSpacing;//此处141是NotifyWindow的高
                isContinueFind =
                    notificationWindows.Any(o => o.topFrom == topFrom);
            }

            if (topFrom <= 0)
                topFrom =
                    System.Windows.SystemParameters.WorkArea.Bottom - 45;

            return topFrom;
        }
        #endregion
    }
}
