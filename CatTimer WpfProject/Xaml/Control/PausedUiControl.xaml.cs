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
    /// PausedUiControl.xaml 的交互逻辑
    /// </summary>
    public partial class PausedUiControl : UserControl
    {
        /* 属性: Clock1(第1个时间)
                Clock2(第2个时间)
                IsShowColck1(是否显示第1个时间?)
                IsShowColck2(是否显示第2个时间?)*/


        public PausedUiControl()
        {
            InitializeComponent();
        }





        #region 依赖项属性：Clock
        /// <summary>
        /// 依赖项属性：第1个时间
        /// </summary>
        public static DependencyProperty ClockProperty;

        /// <summary>
        /// 公开属性：第1个时间
        /// </summary>
        public DayTime Clock
        {
            get { return (DayTime)GetValue(ClockProperty); }
            set { SetValue(ClockProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当Clock1Property依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnClockChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static PausedUiControl()
        {
            /*注册依赖项属性*/
            //注册Clock1Property
            ClockProperty = DependencyProperty.Register(
                "Clock", //属性的名字
                typeof(DayTime),//属性的类型
                typeof(PausedUiControl),//这个属性属于哪个控件？
                new FrameworkPropertyMetadata(//属性的初始值和回调函数
                    //初始值
                    (DayTime)new DayTime(0),
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnClockChanged))
            );
        }

        #endregion




        #region 公开方法
        /// <summary>
        /// 打开或者关闭 暂停界面？
        /// </summary>
        /// <param name="_isOpen">是否打开？</param>
        public void OpenOrClose(bool _isOpen)
        {
            if (_isOpen == true)
            {
                Open();
            }
            else
            {
                Close();
            }
        }


        /// <summary>
        /// 显示
        /// </summary>
        private void Open()
        {
            //显示
            this.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// 关闭
        /// </summary>
        private void Close()
        {
            //关闭
            this.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
