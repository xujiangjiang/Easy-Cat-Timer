using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// TimingControl.xaml 的交互逻辑
    /// </summary>
    public partial class TimingControl : UserControl
    {
        /* 计时器功能 */
        /* 属性: 分钟(Minute)
                秒钟(Second)*/

        public TimingControl()
        {
            InitializeComponent();
        }



        #region 依赖项属性：Minute
        /// <summary>
        /// 依赖项属性：分
        /// </summary>
        public static DependencyProperty MinuteProperty;

        /// <summary>
        /// 公开属性：分
        /// </summary>
        public string Minute
        {
            get { return (string)GetValue(MinuteProperty); }
            set { SetValue(MinuteProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当MinuteProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnMinuteChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        #region 依赖项属性：Second
        /// <summary>
        /// 依赖项属性：秒
        /// </summary>
        public static DependencyProperty SecondProperty;

        /// <summary>
        /// 公开属性：秒
        /// </summary>
        public string Second
        {
            get { return (string)GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当SecondProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnSecondChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion


        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static TimingControl()
        {
            /*注册依赖项属性*/
            //注册MinuteProperty
            MinuteProperty = DependencyProperty.Register(
                "Minute", //属性的名字
                typeof(string),//属性的类型
                typeof(TimingControl),//这个属性属于哪个控件？
                new FrameworkPropertyMetadata(//属性的初始值和回调函数
                    //初始值
                    (string)"00",
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnMinuteChanged))
            );

            //注册SecondProperty
            SecondProperty = DependencyProperty.Register(
                "Second", typeof(string), typeof(TimingControl),
                new FrameworkPropertyMetadata((string)"00", new PropertyChangedCallback(OnSecondChanged))
            );
        }
        #endregion





        #region 控件的事件
        /// <summary>
        /// 当点击[分钟的增加]按钮时
        /// </summary>
        private void MinuteUpButton_Click(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            /* 分钟数+1 */
            AddOrLessMinute(1);
        }

        /// <summary>
        /// 当点击[分钟的减少]按钮时
        /// </summary>
        private void MinuteDownButton_Click(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            /* 分钟数-1 */
            AddOrLessMinute(-1);
        }

        /// <summary>
        /// 当点击[秒数的增加]按钮时
        /// </summary>
        private void SecondUpButton_Click(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            /* 秒数+1 */
            AddOrLessSecond(1);
        }

        /// <summary>
        /// 当点击[秒数的减少]按钮时
        /// </summary>
        private void SecondDownButton_Click(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            /* 秒数-1 */
            AddOrLessSecond(-1);
        }

        /// <summary>
        /// 当点击[开始]按钮时
        /// </summary>
        private void StartButton_Click(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //分钟数：把String转化为int
            string _minuteString = MinuteTextBlock.Text;
            int _minuteNumber = StringToInt(_minuteString);

            //秒数：把String转化为int
            string _secondString = SecondTextBlock.Text;
            int _secondNumber = StringToInt(_secondString);


            //更改时间
            int _totalSecond = _minuteNumber * 60 + _secondNumber;//倒计时的总秒数
            AppManager.AppDatas.TimeData.CurrentTime.DayToSecond = _totalSecond;
            AppManager.AppDatas.TimeData.InputTime.DayToSecond = _totalSecond;

            //让计时开始
            AppManager.AppSystems.TimeSystem.StartHandle();

            //关闭此界面
            OpenOrClose(false);
        }
        #endregion



        #region 公开方法 -[打开和关闭]
        /// <summary>
        /// 打开或者关闭 此界面
        /// </summary>
        /// <param name="_isOpen">是否打开？</param>
        public void OpenOrClose(bool _isOpen)
        {
            switch (_isOpen)
            {
                case true:
                    Open();
                    break;
                case false:
                    Close();
                    break;
            }
        }



        /// <summary>
        /// 打开 此界面
        /// </summary>
        private void Open()
        {
            //修改Ui
            MinuteTextBlock.Text = (AppManager.AppDatas.TimeData.InputTime.Hour * 60 + AppManager.AppDatas.TimeData.InputTime.Minute) + "";
            SecondTextBlock.Text = (int)(AppManager.AppDatas.TimeData.InputTime.Second) + "";

            //再修改下Ui
            AddOrLessMinute(0);
            AddOrLessSecond(0);

            //显示此控件
            this.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 关闭 此界面
        /// </summary>
        private void Close()
        { 
            //关闭此控件
            this.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region 私有方法 -[修改分钟数和秒数]
        /// <summary>
        /// 加或者减 分钟数
        /// </summary>
        /// <param name="_changeMinute">要更改的分钟数（-1或者+1）</param>
        public void AddOrLessMinute(int _changeMinute)
        {
            //获取当前的分钟数
            string _minuteString = MinuteTextBlock.Text;

            //把String转化为int
            int _minuteNumber = StringToInt(_minuteString);

            //分钟数+1或者分钟数-1
            _minuteNumber += _changeMinute;

            //分钟数要限制在0-99之间
            _minuteNumber = Tools.Clamp(_minuteNumber, 0, 99);

            //把int转为string
            string _newMinuteString = "";//新的分钟数
            if (_minuteNumber.ToString().Length <= 1)
            {
                _newMinuteString += "0";
            }
            _newMinuteString += _minuteNumber;

            //更新Ui
            MinuteTextBlock.Text = _newMinuteString;
        }

        /// <summary>
        /// 加或者减 秒数
        /// </summary>
        /// <param name="_changeSecond">要更改的秒数（-1或者+1）</param>
        public void AddOrLessSecond(int _changeSecond)
        {
            //获取当前的秒数
            string _secondString = SecondTextBlock.Text;

            //把String转化为int
            int _secondNumber = StringToInt(_secondString);

            //秒数+1或者秒数-1
            _secondNumber += _changeSecond;

            //秒数要限制在0-60之间
            _secondNumber = Tools.Clamp(_secondNumber, 0, 60);

            //把int转为string
            string _newSecondString = "";//新的分钟数
            if (_secondNumber.ToString().Length <= 1)
            {
                _newSecondString += "0";
            }
            _newSecondString += _secondNumber;

            //更新Ui
            SecondTextBlock.Text = _newSecondString;
        }
        #endregion

        #region 私有方法 -[其他]
        /// <summary>
        /// 字符串转数字
        /// </summary>
        private int StringToInt(string _string)
        {
            int _number = 0;
            switch (_string.ToString().Length)
            {
                case 1:
                    _number = Int32.Parse(_string[0].ToString());
                    break;
                case 2:
                    _number = Int32.Parse(_string[0].ToString()) * 10 + Int32.Parse(_string[1].ToString());
                    break;
            }


            return _number;
        }
        #endregion

        #region 私有方法 -[只能输入数字]
        /* 请参考：https://blog.csdn.net/u011695973/article/details/80984040 
           在XAML中，TextBox组件上必须这样设置：
           <TextBox 
           InputMethod.IsInputMethodEnabled="False"
           PreviewTextInput="txt_PreviewTextInput"
           PreviewKeyDown="txt_PreviewKeyDown"/>
        */

        /// <summary>
        /// 文本框文本输入事件
        /// </summary>
        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9]+");//采用正则表达式

            e.Handled = re.IsMatch(e.Text);
        }

        /// <summary>
        /// 键盘按键事件
        /// 禁用粘贴
        /// </summary>
        private void txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyStates == Keyboard.GetKeyStates(Key.LeftCtrl) || e.KeyStates == Keyboard.GetKeyStates(Key.RightCtrl) || e.KeyStates == Keyboard.GetKeyStates(Key.V))
                e.Handled = true;
            else if (e.KeyStates == Keyboard.GetKeyStates(Key.Space))
                e.Handled = true;
            else
                e.Handled = false;
        }
        #endregion
    }
}
