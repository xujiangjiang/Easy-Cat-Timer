using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 时间的数据
    /// </summary>
    public class TimeData
    {
        private DayTime currentTime;//当前的时间
        private DayTime inputTime;//用户输入的时间（用户想要倒计时多少分钟？）


        #region 公开属性
        /// <summary>
        /// 当前的时间
        /// </summary>
        public DayTime CurrentTime
        {
            get { return currentTime; }
        }

        /// <summary>
        /// 用户输入的时间（用户想要倒计时多少分钟？）
        /// </summary>
        public DayTime InputTime
        {
            get { return inputTime; }
        }
        #endregion

        #region 构造方法
        public TimeData()
        {
            currentTime = new DayTime(0);
            inputTime = new DayTime(0);
        }
        #endregion
    }
}
