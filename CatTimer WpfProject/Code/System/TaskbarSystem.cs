using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 任务栏系统
    /// </summary>
    public class TaskbarSystem
    {
        private TimeTask _twinklingTask = null;//闪烁的任务



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
            float _time = 0.45f;//每隔多少秒闪烁一次？

            //停止闪烁任务
            StopTwinklingTask();

            //如果要让进度条闪烁
            if (_isTwinkling == true)
            {
                _twinklingTask = AppManager.Timer.AddTimeTask(() =>
                {
                    if (AppManager.MainWindow.taskbarItemInfo.ProgressState != TaskbarItemProgressState.None)
                    {
                        AppManager.MainWindow.taskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
                    }
                    else
                    {
                        AppManager.MainWindow.taskbarItemInfo.ProgressState = TaskbarItemProgressState.Paused;
                    }
                }, 0f, -1, _time);
            }
        }

        /// <summary>
        /// 停止闪烁任务
        /// </summary>
        private void StopTwinklingTask()
        {
            if (_twinklingTask != null)
            {
                AppManager.Timer.RemoveTimeTask(_twinklingTask);
                _twinklingTask = null;
            }
        }
        #endregion
    }
}
