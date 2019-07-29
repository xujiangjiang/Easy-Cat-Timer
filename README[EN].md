# Easy Cat Timer

Easy Cat Timer is a very simple timer (countdown) software.

（ [中文 ](README.md)请戳这里）

![主界面](ReadMeImage/MainWindow.png)

<br/>

<br/>

## Download

After July 2, 2019, you can download the software in the Steam store.

<br/>

Latest version:   v1.0.1.0 (July 30, 2019)

Download link：[Click to download v1.0.1.0 version](https://github.com/xujiangjiang/Easy-Cat-Timer/releases/download/v1.0.1.0/Easy.Cat.Timer.v1.0.1.0.zip)

Steam link：https://store.steampowered.com/app/1054580/Easy_Cat_Timer/

<br/>

<br/>

## **Feature**

Easy Cat Timer is a WPF application written in C# (.NET Framework) that runs on the Windows platform.

<br/>

**Software features：**

- Very simple (only countdown function)
- Very cute
- Support two languages: Chinese, English
- Have detailed script comments（Currently only Chinese，Will add English as soon as possible）

<br/>

**This simple project contains these parts:**

| Name                     | Description                                                  |
| ------------------------ | ------------------------------------------------------------ |
| Timer                    | How to complete a timing function in .Net?                   |
| Animation                | In the project, two different animation writing methods were used.<br />One is written directly in C# code, and the other is written in XAML. |
| Data binding             | Bind data classes to XAML and perform two-way data synchronization. |
| Font                     | How to use non-system embedded fonts in WPF.                 |
| Notification window      | How to pop up a custom notification window in the lower right corner of the screen.<br />Reference:<br />https://blog.csdn.net/catshitone/article/details/75089069<br />Here we didn't let the window move, but let the elements in the window move.<br />Window movement is only applicable to the case of using a single display. <br />If the user is a dual display, then the flaw may be seen ：） |
| Save and load            | In WPF, use WPF's own Settings.settings to save and load (archive). |
| Different shaped windows | How to make a grotesque window?<br />There are 2 windows (main window, notification window) in this software.<br />The main window is a square with rounded corners, <br />and the notification window is an irregular shape. |

<br/>

<br/>

## Project structure

**Folder description:**

| Folder      | Description                                                  |
| ----------- | ------------------------------------------------------------ |
| Asset       | This folder is all the resources used in the project.<br />Includes images, fonts, and sound files. |
| Code        | This folder is all the C# scripts used in the project.       |
| Xaml        | This folder is all the .xaml files used in the project.<br />Includes custom controls, resource dictionaries, and styles. |
| ReadMeIamge | This folder is the image to be used in the README.md document.<br />(It’s okay to delete it directly!~) |

<br/>

**Important File description:**

| File                    | Description                                                  |
| ----------------------- | ------------------------------------------------------------ |
| MainWindow.xaml         | Main window                                                  |
| NotificationWindow.xaml | Notification window                                          |
| AppManager.cs           | Management class (used to manage all windows, logic, and data class objects) |
| TimeSystem.cs           | Timer function                                               |
| SaveSystem.cs           | Save and load function                                       |
| LanguageSystem.cs       | Multi-language function                                      |
| AudioSystem.cs          | Sound function                                               |

<br/>

<br/>

## Update log

**v0.0.1.1（2019.06.25）：**

1. Add taskbar progress bar（Blinks when finished, turns red when paused）
2. Put the Staff panel outside the window
3. Fix: Sometimes the countdown is completed, there is no sound (it is suspected that the sound file is being [garbage collected] by the system)
4. Now, when the mouse enters the Staff panel, the Staff panel is displayed. (This is to prevent: the Staff panel flashes madly when the Staff panel appears at the edge of the screen)
5. Now you can't type “-” and “.” in the TextBox.

<br>

**v1.0.0.0（2019.07.01）：**

1. Optimization: When setting the number of minutes and seconds, you can increase (or decrease) the number of minutes (or seconds) if you keep pressing the button.  *——Thanks：Felix*
2. Fix: scrolling the mouse wheel in the TextBox when setting the time will cause the number to scroll  *——Thanks：Felix、小木*
3. Optimization: When setting the time, if the number of seconds is 0, then if you reduce the number of seconds again, the number of seconds will change to 59. The number of minutes is the same.  *——Thanks：Felix*
4. Optimization: Change the Timer class to wpf's DispatcherTimer class
5. Optimization: In the time setting interface, press Enter to start timing  *——Thanks：小木*
6. Fix: Now any right mouse button click is invalid (only the left mouse button can click the button)

<br/>

**v1.0.1.0（2019.07.30）：**

1. Optimization: When setting the time, you can adjust the time by scrolling the middle mouse button——*Thanks：小木*
  2. Optimization: you can adjust the volume——*Thanks：[TBR] Flaming、乐乐*

<br/>











