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
        }

        //当点击[英文]按钮的时候，触发此方法
        private void EnglishButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            /*做一些处理*/
            this.LanguageToggleControl.IsChecked = false;//关闭语言组
            SetLanguageImage(LanguageType.English);//设置语言的图片
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




        /* 滑动条 */
        //当鼠标进入[音量滑动条]时
        private void VolumeSlider_OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.VolumePopup.IsOpen = true; //打开Popup控件
        }

        //当鼠标离开[音量滑动条]时
        private void VolumeSlider_OnMouseLeave(object sender, MouseEventArgs e)
        {
            this.VolumePopup.IsOpen = false; //关闭Popup控件
        }

        //当[音量滑动条]的值 改变时
        private void VolumeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 设置[语言]的图片
        /// </summary>
        private void SetLanguageImage(LanguageType _languageType)
        {
            ImageBrush _imageBrush = null;


            if (_languageType == LanguageType.Chinese)
            {
                //如果是中文，就返回中文的图片
                if (AppManager.MainApp != null)
                {
                    _imageBrush = AppManager.MainApp.Resources["Setting.Chinese.ImageBrush"] as ImageBrush;
                }
            }
            else if (_languageType == LanguageType.English)
            {
                //返回英文的图片
                if (AppManager.MainApp != null)
                {
                    _imageBrush = AppManager.MainApp.Resources["Setting.English.ImageBrush"] as ImageBrush;
                }
            }


            LanguageToggleControl.Icon = _imageBrush;



            //更改语言
            AppManager.AppSystems.LanguageSystem.SetLanguage(_languageType);
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
