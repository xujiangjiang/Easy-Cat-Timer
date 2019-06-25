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
    /// SettingUiControl.xaml 的交互逻辑
    /// </summary>
    public partial class SettingUiControl : UserControl
    {
        /* 属性: 倒计时时长(单位：分钟)(CountdownTime)
                是否有声音？(IsHaveVoice)
                语言(Language)*/



        public SettingUiControl()
        {
            InitializeComponent();
        }





        #region 依赖项属性：IsHaveVoice
        /// <summary>
        /// 依赖项属性：是否有声音？
        /// </summary>
        public static DependencyProperty IsHaveVoiceProperty;

        /// <summary>
        /// 公开属性：是否有声音？
        /// </summary>
        public bool IsHaveVoice
        {
            get { return (bool)GetValue(IsHaveVoiceProperty); }
            set { SetValue(IsHaveVoiceProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当IsHaveVoiceProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnIsHaveVoiceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion

        #region 依赖项属性：Language
        /// <summary>
        /// 依赖项属性：语言
        /// </summary>
        public static DependencyProperty LanguageProperty;

        /// <summary>
        /// 公开属性：语言
        /// </summary>
        public LanguageType Language
        {
            get { return (LanguageType)GetValue(LanguageProperty); }
            set { SetValue(LanguageProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当LanguageProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnLanguageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion




        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static SettingUiControl()
        {
            /*注册依赖项属性*/
            //注册IsHaveVoiceProperty
            IsHaveVoiceProperty = DependencyProperty.Register(
                "IsHaveVoice", //属性的名字
                typeof(bool),//属性的类型
                typeof(SettingUiControl),//这个属性属于哪个控件？
                new FrameworkPropertyMetadata(//属性的初始值和回调函数
                    //初始值
                    (bool)true,
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnIsHaveVoiceChanged))
            );

            //注册LanguageProperty
            LanguageProperty = DependencyProperty.Register(
                "Language", typeof(LanguageType), typeof(SettingUiControl),
                new FrameworkPropertyMetadata((LanguageType)LanguageType.Chinese, new PropertyChangedCallback(OnLanguageChanged)));

        }
        #endregion




        #region [事件方法]
        //当UI显示/关闭的时候，触发此方法
        private void SettingUiControl_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //获取组件
            SettingUiControl _settingUiControl = (SettingUiControl)sender;


            //做一些处理
            _settingUiControl.LanguageToggleControl.IsChecked = false;//关闭语言组
            SetLanguageImage(AppManager.AppDatas.SettingData.Language);//设置语言的图片
        }


        //当点击[中文]按钮的时候，触发此方法
        private void ChineseButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            /*做一些处理*/
            this.LanguageToggleControl.IsChecked = false;//关闭语言组
            SetLanguageImage(LanguageType.Chinese);//设置语言的图片
            AppManager.AppSystems.SaveSystem.Save();//保存
        }

        //当点击[英文]按钮的时候，触发此方法
        private void EnglishButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            /*做一些处理*/
            this.LanguageToggleControl.IsChecked = false;//关闭语言组
            SetLanguageImage(LanguageType.English);//设置语言的图片
            AppManager.AppSystems.SaveSystem.Save();//保存
        }



        //当点击[很大的关闭]按钮的时候，触发此方法
        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            //关闭设置界面
            AppManager.MainWindow.SettingToggleControl.IsChecked = false;
        }

        //当按下[很大的关闭]按钮的时候，触发此方法
        private void CloseButton_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //播放音效
            AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.DefaultButtonDown);
        }
        //当抬起[很大的关闭]按钮的时候，触发此方法
        private void CloseButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //播放音效
            //AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.DefaultButtonUp);
        }


        //当点击[声音]的复选框时
        private void IsHaveAudioCheckBoxControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //修改声音的值
            AppManager.AppDatas.SettingData.IsHaveVoice = this.IsHaveAudioCheckBoxControl.IsChecked;

            //如果是[有声音]，那么就播放点击音效
            if (AppManager.AppDatas.SettingData.IsHaveVoice == true)
            {
                AppManager.AppSystems.AudioSystem.PlayAudio(AudioType.DefaultButtonDown);
            }

            //保存
            AppManager.AppSystems.SaveSystem.Save();
        }





        /* 按钮 */
        //当鼠标进入[工作人员按钮]时
        private void StaffButton_OnMouseEnter(object sender, MouseEventArgs e)
        {
            OpenOrCloseStaff(true);//显示工作人员的界面
        }
        //当鼠标移出[工作人员按钮]时
        private void StaffButton_OnMouseLeave(object sender, MouseEventArgs e)
        {

            OpenOrCloseStaff(false);//关闭工作人员的界面
        }


        //当鼠标点击[Github按钮]时
        private void GithubButton_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //调用系统默认的浏览器
            System.Diagnostics.Process.Start("https://github.com/xujiangjiang/Easy-Cat-Timer");
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 设置[语言]的图片
        /// </summary>
        private void SetLanguageImage(LanguageType _languageType)
        {
            Language = _languageType;
            ImageBrush _imageBrush = null;


            if (Language == LanguageType.Chinese)
            {
                //如果是中文，就返回中文的图片
                if (AppManager.MainApp != null)
                {
                    _imageBrush = AppManager.MainApp.Resources["Setting.Chinese.ImageBrush"] as ImageBrush;
                }
            }
            else if (Language == LanguageType.English)
            {
                //返回英文的图片
                if (AppManager.MainApp != null)
                {
                    _imageBrush = AppManager.MainApp.Resources["Setting.English.ImageBrush"] as ImageBrush;
                }
            }


            LanguageToggleControl.Icon = _imageBrush;



            //更改语言
            AppManager.AppSystems.LanguageSystem.SetLanguage(Language);
        }


        /// <summary>
        /// 打开或者关闭 [工作人员名单]
        /// </summary>
        /// <param name="_isOpen"></param>
        private void OpenOrCloseStaff(bool _isOpen)
        {
            this.StaffPopup.IsOpen = _isOpen; //关闭Popup控件
        }

        #endregion


    }
}
