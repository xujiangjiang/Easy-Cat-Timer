using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 声音的系统
    /// </summary>
    public class AudioSystem
    {
        private MediaPlayer completeMediaPlayer = new MediaPlayer();//[完成]的音效（音频播放器：用来播放音频文件）
        private MediaPlayer defaultButtonDownMediaPlayer = new MediaPlayer();//[普通按钮按下]的音效
        private MediaPlayer defaultButtonUpMediaPlayer = new MediaPlayer();//[普通按钮抬起]的音效
        private MediaPlayer addOrLessNumberMediaPlayer = new MediaPlayer();//[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
        private MediaPlayer catUpMediaPlayer = new MediaPlayer();//[猫咪站起来]的音效
        private MediaPlayer catDownMediaPlayer = new MediaPlayer();//[猫咪坐下]的音效
        private MediaPlayer volumeTestMediaPlayer = new MediaPlayer();//[音量测试]的音效



        #region 公开属性
        /// <summary>
        /// [完成]音效的长度（单位：秒）
        /// </summary>
        public float CompleteAudioLength
        {
            get
            {
                float _value = 7.0f;

                try
                {
                    _value = (float) completeMediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                }
                catch (Exception e)
                {
                    _value = 7.0f;
                }

                return _value;
            }
        }
        #endregion

        #region 构造方法
        public AudioSystem()
        {
            //[普通按钮按下]+[普通按钮抬起]的音效
            defaultButtonDownMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/Asset/Audio/DefaultButtonDown.wav", UriKind.Absolute));
            defaultButtonUpMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/Asset/Audio/DefaultButtonUp.wav", UriKind.Absolute));

            //[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
            addOrLessNumberMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/Asset/Audio/AddOrLessNumber.wav", UriKind.Absolute));

            //[猫咪站起来]+[猫咪坐下]的音效
            catUpMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/Asset/Audio/CatUp.wav", UriKind.Absolute));
            catDownMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/Asset/Audio/CatDown.wav", UriKind.Absolute));

            //[音量测试]的音效
            volumeTestMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/Asset/Audio/VolumeTest.wav", UriKind.Absolute));

            //[完成]的音效
            completeMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/Asset/Audio/Complete.wav", UriKind.Absolute));
        }
        #endregion

        #region 公开方法 -[播放+停止 音频]
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="_audioType">音效类型</param>
        public void PlayAudio(AudioType _audioType)
        {
            //如果用户设置的是不播放音效，就不执行之后的代码了
            if (AppManager.AppDatas.SettingData.Volume <= 0)return;


            //容器：要播放的音频控件？
            MediaPlayer _currentMediaPlayer = null;

            //判断要播放哪个音频控件？
            switch (_audioType)
            {
                case AudioType.Complete:
                    _currentMediaPlayer = completeMediaPlayer;
                    break;

                case AudioType.CatUp:
                    catDownMediaPlayer.Stop();
                    _currentMediaPlayer = catUpMediaPlayer;
                    break;
                case AudioType.CatDown:
                    catUpMediaPlayer.Stop();
                    _currentMediaPlayer = catDownMediaPlayer;
                    break;

                case AudioType.DefaultButtonDown:
                    _currentMediaPlayer = defaultButtonDownMediaPlayer;
                    break;
                case AudioType.DefaultButtonUp:
                    _currentMediaPlayer = defaultButtonUpMediaPlayer;
                    break;

                case AudioType.AddOrlessNumber:
                    _currentMediaPlayer = addOrLessNumberMediaPlayer;
                    break;
                case AudioType.VolumeTest:
                    _currentMediaPlayer = volumeTestMediaPlayer;
                    break;
            }


            //播放声音
            if (_currentMediaPlayer != null)
            {
                _currentMediaPlayer.Volume = AppManager.AppDatas.SettingData.Volume / 100.0f;//设置音量
                _currentMediaPlayer.Stop();//停止
                _currentMediaPlayer.Play();//播放
            }
        }

        /// <summary>
        /// 停止音效
        /// </summary>
        /// <param name="_audioType">音效类型</param>
        public void StopAudio(AudioType _audioType)
        {
            //停止声音
            switch (_audioType)
            {
                case AudioType.Complete:
                    completeMediaPlayer.Stop();
                    break;
            }
        }
        #endregion

        #region 公开方法 -[其他]
        /// <summary>
        /// 当[音量]发生改变时，触发此方法
        /// </summary>
        public void OnVolumeChange(int _newVolume)
        {
            //修改[音频播放器]的音量
            completeMediaPlayer.Volume = _newVolume/100.0f;
        }
        #endregion
    }
}
