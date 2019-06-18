using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 定时器的类（类似于Unity的SuperInvoke插件）
    /// </summary>
    public class Timer
    {
        private double realtimeSinceStartup = 0;//从App启动开始，到现在为止，一共运行了多少秒？（包括暂停和停止的时间）

        /* 定时器任务 */
        private List<TimeTask> timeTasks = new List<TimeTask>();//所有的定时器任务
        private List<TimeTask> tempAddTimeTasks = new List<TimeTask>();//要添加的定时任务
        private List<TimeTask> tempRemoveTimeTasks = new List<TimeTask>();//要添加的定时任务


        /* 容器 */
        private DateTime startDateTime;//App启动时的时间


        #region 构造方法
        public Timer()
        {
            //获取当前的时间
            startDateTime = DateTime.Now;

            //注册 CompositionTarget.Rendering 事件
            //在 WPF 开发中，WPF 会尽可能的保证 1 秒钟运行 60 帧。每一帧的时候，WPF 都会调用一次 CompositionTarget.Rendering 事件。
            CompositionTarget.Rendering += Update;
        }
        #endregion

        #region 帧更新（类似于Unity的Update）
        /// <summary>
        /// 帧更新（类似于Unity的Update）
        /// (在 WPF 开发中，WPF 会尽可能的保证 1 秒钟运行 60 帧)
        /// </summary>
        private void Update(object sender, EventArgs e)
        {
            /* 计算从App启动开始，到现在为止，一共运行了多少秒？ */
            realtimeSinceStartup = (DateTime.Now - startDateTime).TotalSeconds;



            /* 把临时列表中的定时任务，添加到列表中 */
            for (int i = 0; i < tempAddTimeTasks.Count; i++)
            {
                timeTasks.Add(tempAddTimeTasks[i]);
            }
            tempAddTimeTasks.Clear();

            /* 把临时列表中的定时任务，从列表中删除 */
            for (int i = 0; i < tempRemoveTimeTasks.Count; i++)
            {
                timeTasks.Remove(tempRemoveTimeTasks[i]);
            }
            tempRemoveTimeTasks.Clear();



            /* 判断每一个定时任务，是否到达了目标时间，
               如果到时间了，就调用定时任务对象中的回调函数。 */
            for (int i = 0; i < timeTasks.Count; i++)
            {
                TimeTask _task = timeTasks[i];

                //如果当前的游戏运行时间，大于任务的目标时间
                if (realtimeSinceStartup >= _task.destTime)
                {
                    //调用任务中的回调函数
                    Action _callback = _task.callback;
                    if (_callback != null)
                    {
                        try
                        {
                            _callback(); //调用回调函数
                        }
                        catch (Exception exception)
                        {
                            //如果有异常，就什么处理都不做
                        }
                    }


                    /* 判断是否要移除任务 */
                    //如果只有一次了，就移除这个任务
                    if (_task.callCount == 1)
                    {
                        //移出已完成的任务（从任务列表中移出）
                        timeTasks.Remove(_task);

                        //修改索引（因为移出了一个任务）
                        i -= 1;
                    }

                    //如果是永久循环，就修改下目标时间
                    else if (_task.callCount == -1)
                    {
                        _task.destTime += _task.intervalTime;
                    }

                    //如果是其他次数
                    else
                    {
                        //次数-1
                        _task.callCount -= 1;

                        //然后把目标时间修改一下
                        //（新的目标时间 = 原来的目标时间 + 间隔时间）
                        _task.destTime += _task.intervalTime;
                    }
                }
            }
        }
        #endregion

        #region 公开方法
        /// <summary>
        /// 添加1个定时任务
        /// </summary>
        /// <param name="_callback">定时任务的回调函数（当定时任务完成时，触发此事件）</param>
        /// <param name="_delayTime">要延迟的时间（多少秒之后，进行调用？）</param>
        /// <param name="_callCount">要执行的次数（-1代表无数次）</param>
        /// <param name="_intervalTime">每次调用的间隔时间</param>
        public TimeTask AddTimeTask(Action _callback, float _delayTime, int _callCount=1, float _intervalTime=0f)
        {
            //新建1个计时任务
            TimeTask _task = new TimeTask();
            _task.destTime = realtimeSinceStartup + _delayTime;
            _task.callback = _callback;
            _task.callCount = _callCount;
            _task.intervalTime = _intervalTime;

            //把计时任务，添加到临时列表中
            tempAddTimeTasks.Add(_task);


            return _task;
        }

        /// <summary>
        /// 删除1个定时任务（停止1个定时任务）
        /// </summary>
        /// <param name="_timeTask">要删除的定时任务</param>
        /// <returns>是否删除成功？</returns>
        public bool RemoveTimeTask(TimeTask _timeTask)
        {
            //先在列表中查找
            for (int i = 0; i < timeTasks.Count; i++)
            {
                if (_timeTask == timeTasks[i])
                {
                    //添加到要删除的列表中
                    tempRemoveTimeTasks.Add(_timeTask);

                    return true;
                }
            }

            //如果列表中没有找到，就在临时列表中查找
            for (int i = 0; i < tempAddTimeTasks.Count; i++)
            {
                if (_timeTask == tempAddTimeTasks[i])
                {
                    //添加到要删除的列表中
                    tempRemoveTimeTasks.Add(_timeTask);

                    return true;
                }
            }

            //如果2个列表中都没找到
            return false;
        }

        #endregion
    }
}
