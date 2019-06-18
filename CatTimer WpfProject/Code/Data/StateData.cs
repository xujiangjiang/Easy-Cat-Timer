using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 状态的数据
    /// </summary>
    public class StateData : INotifyPropertyChanged
    {
        private StateType currentState;//当前的状态



        #region 公开属性
        /// <summary>
        /// 当前的状态
        /// </summary>
        public StateType CurrentState
        {
            get { return currentState; }
            set
            {
                currentState = value;
                PropertyChange("CurrentState");
            }
        }
        #endregion

        #region 构造方法
        public StateData()
        {
            currentState = StateType.None;
        }
        #endregion



        #region 数据的双向绑定-更新方法
        /// <summary>
        /// 当属性改变的时候，就触发此方法
        /// </summary>
        /// <param name="propertyName">发生改变的属性的名字</param>
        private void PropertyChange(string propertyName)
        {
            if (PropertyChanged != null)//如果此事件被监听
            {
                //就发送通知
                //参数1：是哪个数据类的对象发生了改变？
                //参数2：发生改变的属性名
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 系统会自动监听此事件
        /// 如果此事件触发了，系统就会去通知相应的控件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
