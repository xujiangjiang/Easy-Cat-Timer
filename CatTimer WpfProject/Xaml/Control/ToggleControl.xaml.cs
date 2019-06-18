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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// ToggleControl.xaml 的交互逻辑
    /// </summary>
    public partial class ToggleControl : UserControl
    {
        /* 属性: Icon(图标)
                 Padding(间距)
                 IconWidth(图标的宽度)
                 IconHeight(图标的高度)
                 IsChecked(是否选中？)
           事件: OnClick(当点击按钮的时候)*/



        public ToggleControl()
        {
            InitializeComponent();
        }




        #region 依赖项属性：Icon
        /// <summary>
        /// 依赖项属性：图标
        /// </summary>
        public static DependencyProperty IconProperty;

        /// <summary>
        /// 公开属性：图标
        /// </summary>
        public ImageBrush Icon
        {
            get { return (ImageBrush)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当IconProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnIconChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        #region 依赖项属性：Padding
        /// <summary>
        /// 依赖项属性：间距
        /// </summary>
        public static DependencyProperty PaddingProperty;

        /// <summary>
        /// 公开属性：间距
        /// </summary>
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当PaddingProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnPaddingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion

        #region 依赖项属性：IconWidth
        /// <summary>
        /// 依赖项属性：图标的宽度
        /// </summary>
        public static DependencyProperty IconWidthProperty;

        /// <summary>
        /// 公开属性：图标的宽度
        /// </summary>
        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当IconWidthProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnIconWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        #region 依赖项属性：IconHeight
        /// <summary>
        /// 依赖项属性：图标的宽度
        /// </summary>
        public static DependencyProperty IconHeightProperty;

        /// <summary>
        /// 公开属性：图标的宽度
        /// </summary>
        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当IconHeightProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnIconHeightChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        #region 依赖项属性：IsChecked
        /// <summary>
        /// 依赖项属性：是否选中？
        /// </summary>
        public static DependencyProperty IsCheckedProperty;

        /// <summary>
        /// 公开属性：是否选中？
        /// </summary>
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当IsCheckedProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnIsCheckedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion


        #region 路由事件：Checked
        /// <summary>
        /// 路由事件：CheckedEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent CheckedEvent;


        /// <summary>
        /// 路由事件的属性：Checked
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> Checked
        {
            //添加一条事件
            add { AddHandler(CheckedEvent, value); }

            //移除一条事件
            remove { RemoveHandler(CheckedEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 Checked 路由事件
        /// </summary>
        private void OnChecked()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = ToggleControl.CheckedEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：Unchecked
        /// <summary>
        /// 路由事件：UncheckedEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent UncheckedEvent;


        /// <summary>
        /// 路由事件的属性：Unchecked
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> Unchecked
        {
            //添加一条事件
            add { AddHandler(UncheckedEvent, value); }

            //移除一条事件
            remove { RemoveHandler(UncheckedEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 Unchecked 路由事件
        /// </summary>
        private void OnUnchecked()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(false, false);

            //设置这是哪个路由事件？
            args.RoutedEvent = ToggleControl.UncheckedEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion




        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static ToggleControl()
        {
            /*注册依赖项属性*/
            //注册IconProperty
            IconProperty = DependencyProperty.Register(
                "Icon", //属性的名字
                typeof(ImageBrush),//属性的类型
                typeof(ToggleControl),//这个属性属于哪个控件？
                new FrameworkPropertyMetadata(//属性的初始值和回调函数
                    //初始值
                    (ImageBrush)null,
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnIconChanged))
            );

            //注册PaddingProperty
            PaddingProperty = DependencyProperty.Register(
                "Padding", typeof(Thickness), typeof(ToggleControl),
                new FrameworkPropertyMetadata((Thickness)new Thickness(0), new PropertyChangedCallback(OnPaddingChanged)));

            //注册IconWidthProperty
            IconWidthProperty = DependencyProperty.Register(
                "IconWidth", typeof(double), typeof(ToggleControl),
                new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnIconWidthChanged)));

            //注册IconHeightProperty
            IconHeightProperty = DependencyProperty.Register(
                "IconHeight", typeof(double), typeof(ToggleControl),
                new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnIconHeightChanged)));

            //注册IsCheckedProperty
            IsCheckedProperty = DependencyProperty.Register(
                "IsChecked", typeof(bool), typeof(ToggleControl),
                new FrameworkPropertyMetadata((bool)false, new PropertyChangedCallback(OnIsCheckedChanged)));





            /*注册路由事件*/
            //注册CheckedEvent
            CheckedEvent = EventManager.RegisterRoutedEvent(
                "Checked", //事件的名字
                RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
                typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
                typeof(ToggleControl) //这个路由事件属于哪个控件？
            );

            //注册UncheckedEvent
            UncheckedEvent = EventManager.RegisterRoutedEvent(
                "Unchecked", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<bool>),typeof(ToggleControl)
            );

        }



        #endregion




        #region [点击按钮动画]
        //当鼠标在[复选框]上点击的时候，触发此方法
        private void CheckBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //获取"按下动画"，并播放动画
            Storyboard _storyboard = this.Resources["Button_OnMouseDown_Storyboard"] as Storyboard;
            _storyboard.Begin(this);

            //播放音频
            AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.DefaultButtonDown);
        }

        //当鼠标在[复选框]上抬起的时候，触发此方法
        private void CheckBox_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //获取"抬起动画"，并播放动画
            Storyboard _storyboard = this.Resources["Button_OnMouseUp_Storyboard"] as Storyboard;
            _storyboard.Begin(this);
        }



        //当鼠标在[复选框]被选中的时候，触发此方法
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            //触发事件
            OnChecked(); 
        }

        //当鼠标在[复选框]未选中的时候，触发此方法
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            //触发事件
            OnUnchecked();
        }
        #endregion
    }
}
