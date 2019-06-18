using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 所有的系统
    /// </summary>
    public class AppSystems
    {
        private LanguageSystem languageSystem;//语言
        private TimeSystem timeSystem;//时间
        private NotificationSystem notificationSystem;//通知
        private AudioSystem audioSystem;//音效
        private SaveSystem saveSystem;//保存和读取
        private TaskbarSystem taskbarSystem;//任务栏

        #region 公开属性
        /// <summary>
        /// 语言的系统
        /// </summary>
        public LanguageSystem LanguageSystem
        {
            get { return languageSystem; }
        }

        /// <summary>
        /// 时间的系统
        /// </summary>
        public TimeSystem TimeSystem
        {
            get { return timeSystem; }
        }

        /// <summary>
        /// 通知的系统
        /// </summary>
        public NotificationSystem NotificationSystem
        {
            get { return notificationSystem; }
        }

        /// <summary>
        /// 音效的系统
        /// </summary>
        public AudioSystem AudioSystem
        {
            get { return audioSystem; }
        }

        /// <summary>
        /// 保存&读取的系统
        /// </summary>
        public SaveSystem SaveSystem
        {
            get { return saveSystem; }
        }

        /// <summary>
        /// 任务栏的系统
        /// </summary>
        public TaskbarSystem TaskbarSystem
        {
            get { return taskbarSystem; }
        }
        #endregion

        #region 构造方法
        public AppSystems()
        {
            languageSystem = new LanguageSystem();
            timeSystem = new TimeSystem();
            notificationSystem = new NotificationSystem();
            audioSystem = new AudioSystem();
            saveSystem = new SaveSystem();
            taskbarSystem = new TaskbarSystem();
        }
        #endregion
    }
}
