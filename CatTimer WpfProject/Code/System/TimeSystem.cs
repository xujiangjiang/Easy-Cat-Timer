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
    /// 时间的系统
    /// </summary>
    public class TimeSystem
    {
        private DispatcherTimer timer;//计时器


        #region 构造方法
        public TimeSystem()
        {
            //设置定时器
            timer = new DispatcherTimer();//定时器：类似于Unity中的SuperInvoke插件
            timer.Interval = new TimeSpan(0, 0, 1);//定时器的间隔时间（1秒）：每隔多少秒，调用一次代码？
            timer.Tick += TimerOnTick;//要调用的代码
        }
        #endregion

        #region 公开方法
        /// <summary>
        /// 开始倒计时
        /// </summary>
        public void StartHandle()
        {
            //修改标识符
            AppManager.AppDatas.StateData.CurrentState = StateType.Run;

            //开始运行计时器
            timer.Start();
        }


        /// <summary>
        /// 取消暂停倒计时
        /// </summary>
        public void UnPauseHandle()
        {
            //修改标识符
            AppManager.AppDatas.StateData.CurrentState = StateType.Run;
        }


        /// <summary>
        /// 暂停倒计时
        /// </summary>
        public void PauseHandle()
        {
            //修改标识符
            AppManager.AppDatas.StateData.CurrentState = StateType.Pause;
        }


        /// <summary>
        /// 停止倒计时
        /// </summary>
        public void StopHandle()
        {
            //修改标识符
            AppManager.AppDatas.StateData.CurrentState = StateType.Stop;

            //停止计时器
            timer.Stop();
        }
        #endregion


        #region 私有方法 -[定时器的事件]
        // 定时器的Tick事件：当定时器每次达到间隔时间时，都会触发一次Tick事件
        private void TimerOnTick(object sender, EventArgs e)
        {
            /* 判断是否进行倒计时？ */
            if (AppManager.AppDatas.StateData.CurrentState != StateType.Run) return;


            /* 如果已经是0秒了，就停止此任务 */
            if (AppManager.AppDatas.TimeData.CurrentTime.DayToSecond <= 0)
            {
                //停止此任务
                StopHandle();

                //更新[任务栏进度条]
                AppManager.AppSystems.TaskbarSystem.SetProgressValueAndState(1, TaskbarItemProgressState.Paused);

                //弹出通知
                AppManager.AppSystems.NotificationSystem.ShowNotification();
            }
            else
            {
                /* 如果要进行，就让时间减1秒 */
                AppManager.AppDatas.TimeData.CurrentTime.AddOrRemoveSeconds(-1);

                /* 更新[任务栏进度条] */
                float _currentTimeSeconds = AppManager.AppDatas.TimeData.CurrentTime.DayToSecond;//当前倒计时的时间
                float _inputTimeSeconds = AppManager.AppDatas.TimeData.InputTime.DayToSecond;//用户输入的时间
                AppManager.AppSystems.TaskbarSystem.SetProgressValueAndState(
                    (_inputTimeSeconds - _currentTimeSeconds) / _inputTimeSeconds);//目前进度 = 当前用了多少秒 / 总时间
            }
        }
        #endregion
    }

}
