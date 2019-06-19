# Easy Cat Timer

Easy Cat Timer是一个非常简单计时器（倒计时）软件。

![主界面](ReadMeImage/MainWindow.png)

<br/>

<br/>

## 下载

2019年7月2日之后，你可以在Steam商店里，下载这款软件。



最新版本：  v0.0.1 (2019年06月20日)

下载地址：[点击下载v0.0.1版本](https://github.com/xujiangjiang/Easy-Cat-Timer/releases/download/v0.0.1/CatTimer.v0.0.1.zip)

Steam地址：https://store.steampowered.com/app/1054580/Easy_Cat_Timer/

<br/>

<br/>

## 特色

Easy Cat Timer是一个使用C#语言编写的WPF应用（.NET Framework），可运行在Windows平台。



**软件特色：**

- 非常简单（只有倒计时的功能）
- 非常可爱



**在这个简单的项目中，大概有这些部分：**

| 名字       | 描述                                                         |
| ---------- | ------------------------------------------------------------ |
| 定时器     | 在.Net中，如何完成一个计时功能？                             |
| 动画       | 在项目中，用到了2种不同的动画书写方式。<br />一种是直接在C#代码里书写，一种是在XAML里书写。 |
| 数据绑定   | 把数据类绑定在XAML中，并且进行双向数据同步。                 |
| 字体       | 如何在WPF中，使用非系统内嵌的字体。                          |
| 通知窗口   | 如何在屏幕右下角弹出自定义的通知窗口。<br />这一部分参考了这位大大的代码：<br />https://blog.csdn.net/catshitone/article/details/75089069<br />但是我不是用的窗口位移，而是让窗口里的元素位移。<br />窗口位移只适用于使用单个显示器的情况，如果用户是双显示器可能会看出瑕疵：） |
| 保存和读取 | 在WPF里，用WPF自带的Settings.settings实现保存和加载功能（存档功能）。 |

<br/>

<br/>

## 项目结构

**文件夹说明：**

| 文件夹      | 描述                                                         |
| ----------- | ------------------------------------------------------------ |
| Asset       | 这个文件夹里，是项目中用到的所有资源。<br />包括了图片 、字体和声音文件。 |
| Code        | 这个文件夹里，是项目中用到的所有C#脚本。                     |
| Xaml        | 这个文件夹里，是项目中用到的所有.xaml文件。<br />包括了自定义控件、资源词典、以及样式。 |
| ReadMeIamge | 这个文件夹里，装的是README.md文档中要用到的图片。<br />（直接删掉也没关系哒！~） |



**重要文件说明：**

| 文件                    | 描述                                                 |
| ----------------------- | ---------------------------------------------------- |
| MainWindow.xaml         | 主界面                                               |
| NotificationWindow.xaml | 通知界面                                             |
| AppManager.cs           | 管理类  (用于管理所有的窗口、逻辑、以及数据类的对象) |
| TimeSystem.cs           | 计时器功能                                           |
| SaveSystem.cs           | 保存加载功能                                         |
| LanguageSystem.cs       | 多语言功能                                           |
| AudioSystem.cs          | 音效功能                                             |























