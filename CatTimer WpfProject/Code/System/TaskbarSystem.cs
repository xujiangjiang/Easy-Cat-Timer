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
        /// <summary>
        /// 设置 [任务栏进度条]的进度
        /// （取值范围：0-1）
        /// </summary>
        /// <param name="_value">进度条的进度</param>
        /// <param name="_progressState">进度条的颜色（绿色、红色、黄色）</param>
        public void SetProgressValue(double _value, TaskbarItemProgressState _progressState = TaskbarItemProgressState.Paused)
        {
            // 修改颜色
            AppManager.MainWindow.taskbarItemInfo.ProgressState = _progressState;

            // 修改进度
            _value = Tools.Clamp(_value, 0, 1);
            AppManager.MainWindow.taskbarItemInfo.ProgressValue = _value;
        }
    }
}
