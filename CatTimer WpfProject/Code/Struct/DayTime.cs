/* 类名：DayTime.cs
 * 作者：絮大王
 * 邮箱：sukiup@163.com
 * 时间：2019年3月6日15:33:34 */

using System;
using System.ComponentModel;

/// <summary>
/// 每天的时间：时、分、秒
/// </summary>
public class DayTime : INotifyPropertyChanged
{
    private int hour;//时
    private int minute;//分
    private float second;//秒
    private float dayToSecond;//把 [时:分:秒] 转化为 [秒]  （这1天一共有多少秒）

    #region 公开属性

    /// <summary>
    /// 时
    /// </summary>
    public int Hour
    {
        get { return hour; }
        set { AddOrRemoveSeconds((value - hour) * 60 * 60); }
    }

    /// <summary>
    /// 分
    /// </summary>
    public int Minute
    {
        get { return minute; }
        set { AddOrRemoveSeconds((value - minute) * 60); }
    }

    /// <summary>
    /// 秒
    /// </summary>
    public float Second
    {
        get { return second; }
        set { AddOrRemoveSeconds(value - second); }
    }

    /// <summary>
    /// 把 [时:分:秒] 转化为 [秒]
    ///（这1天一共有多少秒）
    /// </summary>
    public float DayToSecond
    {
        get { return dayToSecond; }
        set { SecondToDay(value); }
    }


    /// <summary>
    /// 把时间转换为 [分钟:秒钟]
    /// </summary>
    public string TimeToHourString
    {
        get
        {
            string _time = "";

            //分
            if ((Hour * 60 + Minute).ToString().Length <= 1)
            {
                _time += "0";
            }
            _time += Hour * 60 + Minute + ":";

            //秒
            if (((int)Second).ToString().Length <= 1)
            {
                _time += "0";
            }
            _time += (int)Second;

            return _time;
        }
        set
        {
            PropertyChange("TimeToHourString");
        }
    }

    #endregion 公开属性

    #region 构造方法

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="_hour">时</param>
    /// <param name="_minute">分</param>
    /// <param name="_second">秒</param>
    public DayTime(int _hour, int _minute, float _second)
    {
        hour = 0;
        minute = 0;
        second = 0;

        //计算一共有多少秒
        dayToSecond = _hour * 60 * 60 + _minute * 60 + _second;

        //把 [秒] 转化为 [时:分:秒]
        SecondToDay(dayToSecond);
    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="_dayToSecond">这1天一共有多少秒？</param>
    public DayTime(float _dayToSecond)
    {
        hour = 0;
        minute = 0;
        second = 0;
        dayToSecond = _dayToSecond;

        //把 [秒] 转化为 [时:分:秒]
        SecondToDay(_dayToSecond);
    }

    public override string ToString()
    {
        return hour + ":" + minute + ":" + second;
    }

    #endregion 构造方法

    #region 公开方法

    /// <summary>
    /// 添加/减少 秒数
    /// </summary>
    /// <param name="changeSeconds">要改变的秒数（+代表增加，-代表减少）</param>
    public void AddOrRemoveSeconds(float changeSeconds)
    {
        dayToSecond += changeSeconds;
        SecondToDay(dayToSecond);
    }

    #endregion 公开方法

    #region 私有方法

    /// <summary>
    /// 把 [秒] 转化为 [时:分:秒]
    /// </summary>
    /// <param name="_dayToSecond">这一天一共有多少秒?</param>
    private void SecondToDay(float _dayToSecond)
    {
        hour = (int)(_dayToSecond / 60.0f / 60.0f);
        minute = (int)((_dayToSecond - hour * 60 * 60) / 60.0f);
        second = _dayToSecond - hour * 60 * 60 - minute * 60;

        dayToSecond = _dayToSecond;

        /*通知UI进行更新*/
        TimeToHourString = "";
    }

    #endregion 私有方法

    #region 静态方法-[DateTime转DayTime]

    /// <summary>
    /// 把DateTime对象 转换为 DayTime对象
    /// </summary>
    /// <param name="dateTime">要转换的DateTime对象</param>
    /// <returns>转换后的DayTime对象</returns>
    public static DayTime DateTimeToDayTime(DateTime dateTime)
    {
        DayTime dayTime = new DayTime(
            dateTime.Hour,
            dateTime.Minute,
            dateTime.Second + dateTime.Millisecond / 1000);

        return dayTime;
    }

    /// <summary>
    /// 把DayTime对象 转换为 DateTime对象
    /// </summary>
    /// <param name="dateTime">要转换的DayTime对象</param>
    /// <returns>转换后的DateTime对象</returns>
    public static DateTime DateTimeToDayTime(int year, int month, int day, DayTime dayTime)
    {
        DateTime dateTime = new DateTime(
            year, //年
            month, //月
            day, //日
            dayTime.Hour, //时
            dayTime.Minute, 0); //分

        dateTime.AddSeconds(dayTime.Second); //秒

        return dateTime;
    }

    #endregion 静态方法-[DateTime转DayTime]

    #region 静态方法-[时间转换]

    /// <summary>
    /// 计算当前的这天，一共有多少秒
    /// </summary>
    /// <param name="dateTime">日期数据</param>
    /// <returns>这一天一共有多少秒</returns>
    public static float DateTime_DayToSecond(DateTime dateTime)
    {
        float dayToSecond = dateTime.Hour * 60 * 60 +
                            dateTime.Minute * 60 +
                            dateTime.Second +
                            dateTime.Millisecond / 1000.0f;

        return dayToSecond;
    }

    #endregion 静态方法-[时间转换]

    #region 重写运算符 -[DayTime与DayTime的比较]

    /// <summary>
    /// 重写">"符号的逻辑
    /// </summary>
    public static bool operator >(DayTime d1, DayTime d2)
    {
        bool isD1Max = false;//是否是d1更大？

        /*进行判断*/
        if (d1.DayToSecond > d2.DayToSecond)
        {
            isD1Max = true;
        }

        /*返回值*/
        return isD1Max;
    }

    /// <summary>
    /// 重写"<"符号的逻辑
    /// </summary>
    public static bool operator <(DayTime d1, DayTime d2)
    {
        bool isD1Min = false;//是否是d1更小？

        /*进行判断*/
        if (d1.DayToSecond < d2.DayToSecond)
        {
            isD1Min = true;
        }

        /*返回值*/
        return isD1Min;
    }

    /// <summary>
    /// 重写">="符号的逻辑
    /// </summary>
    public static bool operator >=(DayTime d1, DayTime d2)
    {
        return d1.DayToSecond >= d2.DayToSecond;
    }

    /// <summary>
    /// 重写"<="符号的逻辑
    /// </summary>
    public static bool operator <=(DayTime d1, DayTime d2)
    {
        return d1.DayToSecond <= d2.DayToSecond;
    }

    /// <summary>
    /// 重写"!="符号的逻辑
    /// </summary>
    public static bool operator !=(DayTime d1, DayTime d2)
    {
        return d1.DayToSecond != d2.DayToSecond;
    }

    /// <summary>
    /// 重写"=="符号的逻辑
    /// </summary>
    public static bool operator ==(DayTime d1, DayTime d2)
    {
        return d1.DayToSecond <= d2.DayToSecond;
    }

    #endregion 重写运算符 -[DayTime与DayTime的比较]

    #region 重写运算符 -[DayTime与DateTime的比较]

    /// <summary>
    /// 重写">"符号的逻辑
    /// </summary>
    public static bool operator >(DayTime day, DateTime date)
    {
        float dateDayToSecond = DateTime_DayToSecond(date);

        return day.DayToSecond > dateDayToSecond;
    }

    /// <summary>
    /// 重写"<"符号的逻辑
    /// </summary>
    public static bool operator <(DayTime day, DateTime date)
    {
        float dateDayToSecond = DateTime_DayToSecond(date);

        return day.DayToSecond < dateDayToSecond;
    }

    /// <summary>
    /// 重写">="符号的逻辑
    /// </summary>
    public static bool operator >=(DayTime day, DateTime date)
    {
        float dateDayToSecond = DateTime_DayToSecond(date);

        return day.DayToSecond >= dateDayToSecond;
    }

    /// <summary>
    /// 重写"<="符号的逻辑
    /// </summary>
    public static bool operator <=(DayTime day, DateTime date)
    {
        float dateDayToSecond = DateTime_DayToSecond(date);

        return day.DayToSecond <= dateDayToSecond;
    }

    #endregion 重写运算符 -[DayTime与DateTime的比较]

    #region 数据的双向绑定-更新方法

    /// <summary>
    /// 当属性改变的时候，就触发此方法
    /// </summary>
    /// <param name="propertyName">发生改变的属性的名字</param>
    private void PropertyChange(string propertyName)
    {
        if (PropertyChanged != null)//如果此事件被监听
        {
            //就发送通知
            //参数1：是哪个数据类的对象发生了改变？
            //参数2：发生改变的属性名
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// 系统会自动监听此事件
    /// 如果此事件触发了，系统就会去通知相应的控件
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion 数据的双向绑定-更新方法
}