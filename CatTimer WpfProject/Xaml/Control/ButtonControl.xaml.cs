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
    /// ButtonControl.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonControl : UserControl
    {
        /* 属性: Icon(图标)
                 Padding(间距)
                 IconWidth(图标的宽度)
                 IconHeight(图标的高度)
                 ButtonStyle(按钮的样式)
           事件: OnClick(当点击按钮的时候)*/



        public ButtonControl()
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

        #region 依赖项属性：ButtonStyle
        /// <summary>
        /// 依赖项属性：按钮的样式
        /// </summary>
        public static DependencyProperty ButtonStyleProperty;

        /// <summary>
        /// 公开属性：按钮的样式
        /// </summary>
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当ButtonStyleProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnButtonStyleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion


        #region 路由事件：Click
        /// <summary>
        /// 路由事件：ClickEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickEvent;


        /// <summary>
        /// 路由事件的属性：Click
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> Click
        {
            //添加一条事件
            add { AddHandler(ClickEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 Click 路由事件
        /// </summary>
        private void OnClick()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = ButtonControl.ClickEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion




        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static ButtonControl()
        {
            /*注册依赖项属性*/
            //注册IconProperty
            IconProperty = DependencyProperty.Register(
                "Icon", //属性的名字
                typeof(ImageBrush),//属性的类型
                typeof(ButtonControl),//这个属性属于哪个控件？
                new FrameworkPropertyMetadata(//属性的初始值和回调函数
                    //初始值
                    (ImageBrush)null,
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnIconChanged))
            );

            //注册PaddingProperty
            PaddingProperty = DependencyProperty.Register(
                "Padding", typeof(Thickness), typeof(ButtonControl),
                new FrameworkPropertyMetadata((Thickness)new Thickness(0), new PropertyChangedCallback(OnPaddingChanged)));

            //注册IconWidthProperty
            IconWidthProperty = DependencyProperty.Register(
                "IconWidth", typeof(double), typeof(ButtonControl),
                new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnIconWidthChanged)));

            //注册IconHeightProperty
            IconHeightProperty = DependencyProperty.Register(
                "IconHeight", typeof(double), typeof(ButtonControl),
                new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnIconHeightChanged)));

            //注册ButtonStyleProperty
            ButtonStyleProperty = DependencyProperty.Register(
                "ButtonStyle", typeof(Style), typeof(ButtonControl),
                new FrameworkPropertyMetadata((Style)null, new PropertyChangedCallback(OnButtonStyleChanged)));






            /*注册路由事件*/
            //注册ClickEvent
            ClickEvent = EventManager.RegisterRoutedEvent(
                "Click", //事件的名字
                RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
                typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
                typeof(ButtonControl) //这个路由事件属于哪个控件？
            );

        }

        #endregion



        #region [点击按钮动画]
        //当鼠标在[按钮]上点击的时候，触发此方法
        private void Button_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //获取"按下动画"，并播放动画
            Storyboard _storyboard = this.Resources["Button_OnMouseDown_Storyboard"] as Storyboard;
            _storyboard.Begin(this);

            //播放音效
            AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.DefaultButtonDown);
        }


        //当鼠标在[按钮]上抬起的时候，触发此方法
        private void Button_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //获取"抬起动画"，并播放动画
            Storyboard _storyboard = this.Resources["Button_OnMouseUp_Storyboard"] as Storyboard;
            _storyboard.Begin(this);

            //播放音效
            //AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.DefaultButtonUp);
        }


        //当鼠标在[按钮]上按下的时候，触发此方法
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            //触发点击事件
            OnClick();
        }
        #endregion


    }
}
