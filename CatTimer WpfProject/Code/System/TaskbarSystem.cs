using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;
using System.Windows.Threading;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 任务栏系统
    /// </summary>
    public class TaskbarSystem
    {
        private DispatcherTimer twinklingTimer;//闪烁的计时器


        #region 构造方法
        public TaskbarSystem()
        {
            //设置定时器
            twinklingTimer = new DispatcherTimer();//定时器：类似于Unity中的SuperInvoke插件
            twinklingTimer.Interval = new TimeSpan(0,0,0,0,385);//定时器的间隔时间（0.385秒）：每隔多少秒，调用一次代码？
            twinklingTimer.Tick += TwinklingTimerOnTick;//要调用的代码
        }
        #endregion



        #region 公开方法 -[状态和值]
        /// <summary>
        /// 设置 [任务栏进度条]的进度和状态
        /// （取值范围：0-1）
        /// </summary>
        /// <param name="_value">进度条的进度</param>
        /// <param name="_progressState">进度条的颜色（绿色、红色、黄色）</param>
        public void SetProgressValueAndState(double _value, TaskbarItemProgressState _progressState = TaskbarItemProgressState.Paused)
        {
            // 修改颜色
            SetProgressState(_progressState);

            // 修改进度
            SetProgressValue(_value);
        }



        /// <summary>
        /// 设置 [任务栏进度条]的状态（颜色）
        /// </summary>
        /// <param name="_progressState">进度条的颜色（绿色、红色、黄色）</param>
        public void SetProgressState(TaskbarItemProgressState _progressState)
        {
            // 修改颜色
            AppManager.MainWindow.taskbarItemInfo.ProgressState = _progressState;
        }

        /// <summary>
        /// 设置 [任务栏进度条]的进度
        /// （取值范围：0-1）
        /// </summary>
        /// <param name="_value">进度条的进度</param>
        public void SetProgressValue(double _value)
        {
            // 修改进度
            _value = Tools.Clamp(_value, 0, 1);
            AppManager.MainWindow.taskbarItemInfo.ProgressValue = _value;
        }
        #endregion

        #region 公开方法 -[其他]
        /// <summary>
        /// 进度条是否闪烁？
        /// </summary>
        /// <param name="_isTwinkling">是否闪烁？</param>
        public void SetProgressTwinkling(bool _isTwinkling)
        {
            //停止闪烁任务
            StopTwinklingTask();

            //如果要让进度条闪烁
            if (_isTwinkling == true)
            {
                //开启[闪烁]计时器
                twinklingTimer.Start();
            }
        }

        /// <summary>
        /// 停止闪烁任务
        /// </summary>
        private void StopTwinklingTask()
        {
            //关闭[闪烁]计时器
            twinklingTimer.Stop();
        }
        #endregion


        #region 私有方法 -[注册计时器事件]
        // [闪烁]的定时器 的Tick事件：当定时器每次达到间隔时间时，都会触发一次Tick事件
        private void TwinklingTimerOnTick(object sender, EventArgs e)
        {
            if (AppManager.MainWindow.taskbarItemInfo.ProgressState != TaskbarItemProgressState.None)
            {
                AppManager.MainWindow.taskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
            }
            else
            {
                AppManager.MainWindow.taskbarItemInfo.ProgressState = TaskbarItemProgressState.Paused;
            }
        }
        #endregion
    }
}
