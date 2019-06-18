namespace CatTimer_WpfProject
{
    /// <summary>
    /// 语言的类型
    /// </summary>
    public enum LanguageType : byte
    {
        None,
        English,//英语
        Chinese//中文
    }

    /// <summary>
    /// 状态的类型
    /// </summary>
    public enum StateType : byte
    {
        None,
        Run,//运行
        Pause,//暂停
        Stop//停止
    }


    /// <summary>
    /// 音效的类型
    /// </summary>
    public enum AudioType : byte
    {
        None,
        Complete,//完成音效
        CatUp,//猫咪站起来
        CatDown,//猫咪坐下
        DefaultButtonDown,//普通按钮按下
        DefaultButtonUp,//普通按钮抬起
    }
}