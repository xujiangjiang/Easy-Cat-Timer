using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 定时器的任务
    /// （每1个定时任务，就是1个定时任务类的对象）
    /// </summary>
    public class TimeTask
    {
        //目标时间（单位：秒）（目标时间 = 当前App运行的秒数 + 延迟的秒数）
        public double destTime;

        //要执行的任务（当到达目标时间之后，触发此方法）（也就是回调函数）
        public Action callback;

        //这个任务调用的次数（-1代表无数次）
        public int callCount;

        //每次调用的时间间隔
        public float intervalTime;
    }
}
