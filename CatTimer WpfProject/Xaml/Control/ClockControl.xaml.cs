using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// ClockControl.xaml 的交互逻辑
    /// </summary>
    public partial class ClockControl : UserControl
    {
        /* 属性: 时间(Time))*/

        public ClockControl()
        {
            InitializeComponent();
        }


        #region 依赖项属性：Time
        /// <summary>
        /// 依赖项属性：时间
        /// </summary>
        public static DependencyProperty TimeProperty;

        /// <summary>
        /// 公开属性：时间
        /// </summary>
        public DayTime Time
        {
            get { return (DayTime)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当TimeProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnTimeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static ClockControl()
        {
            /*注册依赖项属性*/
            //注册TimeProperty
            TimeProperty = DependencyProperty.Register(
                "Time", //属性的名字
                typeof(DayTime),//属性的类型
                typeof(ClockControl),//这个属性属于哪个控件？
                new FrameworkPropertyMetadata(//属性的初始值和回调函数
                    //初始值
                    (DayTime)new DayTime(0),
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnTimeChanged))
            );
        }
        #endregion
    }
}
