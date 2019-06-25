using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 时间的系统
    /// </summary>
    public class TimeSystem
    {
        private TimeTask timeTask;//计时器任务


        #region 公开方法
        /// <summary>
        /// 开始倒计时
        /// </summary>
        public void StartHandle()
        {
            //修改标识符
            AppManager.AppDatas.StateData.CurrentState = StateType.Run;

            //运行
            timeTask = AppManager.Timer.AddTimeTask(() =>
            {
                /* 判断是否进行倒计时？ */
                if (AppManager.AppDatas.StateData.CurrentState != StateType.Run) return;


                /* 如果已经是0秒了，就停止此任务 */
                if (AppManager.AppDatas.TimeData.CurrentTime.DayToSecond <= 0)
                {
                    //停止此任务
                    StopHandle();

                    //更新[任务栏进度条]
                    AppManager.AppSystems.TaskbarSystem.SetProgressValueAndState(1,TaskbarItemProgressState.Paused);

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
                        (_inputTimeSeconds-_currentTimeSeconds)/_inputTimeSeconds);//目前进度 = 当前用了多少秒 / 总时间
                }
            }, 1f, -1, 1f);
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

            //删除任务
            if (timeTask!=null)
            {
                AppManager.Timer.RemoveTimeTask(timeTask);
                timeTask = null;
            }          
        }
        #endregion
    }
}
