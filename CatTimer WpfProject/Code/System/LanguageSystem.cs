using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 语言的系统
    /// </summary>
    public class LanguageSystem
    {
        /// <summary>
        /// 设置语言
        /// </summary>
        /// <param name="_language">语言</param>
        public void SetLanguage(LanguageType _language)
        {
            AppManager.AppDatas.SettingData.Language = _language;

            string _dictionaryFilePath = "";
            switch (_language)
            {
                case LanguageType.Chinese:
                    _dictionaryFilePath = "/CatTimer WpfProject;component/Xaml/Dictionary/ChineseTextDictionary.xaml";
                    break;

                case LanguageType.English:
                    _dictionaryFilePath = "/CatTimer WpfProject;component/Xaml/Dictionary/EnglishTextDictionary.xaml";
                    break;
            }

            //创建1个新的资源字典
            ResourceDictionary _resourceDictionary = new ResourceDictionary();

            //设置资源字典的资源
            _resourceDictionary.Source = new Uri(_dictionaryFilePath, UriKind.Relative);

            //替换资源字典（替换App.xaml中的TextDictionary）
            AppManager.MainApp.Resources.MergedDictionaries[6] = _resourceDictionary;
        }
    }
}
