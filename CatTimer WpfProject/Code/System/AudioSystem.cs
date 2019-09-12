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
        /*
         * 因为我们使用的是SoundPlayer类进行音频的播放。
           因此，无法调整音量。
           所以，我们把音频文件，进行音量调整。
           每个音频有5个音频文件，分别是：
            (1) 音量为100%的音频文件（文件名是Volume1.0）
            (2) 音量为80%的音频文件（文件名是Volume0.8）
            (3) 音量为60%的音频文件（文件名是Volume0.6）
            (4) 音量为40%的音频文件（文件名是Volume0.4）
            (5) 音量为20%的音频文件（文件名是Volume0.2）


           为什么不用MediaPlayer类呢？
            (1) 因为MediaPlayer类依赖于WMP(Windows Media Player)软件，有些没有安装WMP软件的用户会报错
            (2) 我们曾经使用过MediaPlayer类，请参考Github中的v1.0.1.0版本，但是效果不是很好，而且经常会被垃圾回收掉
         */



        private MediaPlayer completeMediaPlayer;//[完成]的音效
        private SoundPlayer defaultButtonDownSoundPlayer;//[普通按钮按下]的音效
        private SoundPlayer defaultButtonUpSoundPlayer;//[普通按钮抬起]的音效
        private SoundPlayer addOrlessNumberSoundPlayer;//[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
        private List<SoundPlayer> catUpSoundPlayers;//[猫咪站起来]的音效
        private List<SoundPlayer> catDownSoundPlayers;//[猫咪坐下]的音效



        #region 公开属性
        /// <summary>
        /// [完成]音效的长度（单位：秒）
        /// </summary>
        public float CompleteAudioLength
        {
            get { return 7.0f; }
        }
        #endregion

        #region 构造方法
        public AudioSystem()
        {
            /* 构造SoundPlayer的对象 */
            //[完成]的音效
            completeMediaPlayer = new MediaPlayer();
            completeMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory+"/Asset/Audio/Complete.wav", UriKind.Absolute));

            //[普通按钮按下]+[普通按钮抬起]的音效
            defaultButtonDownSoundPlayer = new SoundPlayer();
            defaultButtonUpSoundPlayer = new SoundPlayer();

            //[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
            addOrlessNumberSoundPlayer = new SoundPlayer();

            //[猫咪站起来]的音效
            catUpSoundPlayers = new List<SoundPlayer>();
            catUpSoundPlayers.Add(new SoundPlayer());
            catUpSoundPlayers.Add(new SoundPlayer());
            catUpSoundPlayers.Add(new SoundPlayer());

            //[猫咪坐下]的音效
            catDownSoundPlayers= new List<SoundPlayer>();
            catDownSoundPlayers.Add(new SoundPlayer());
            catDownSoundPlayers.Add(new SoundPlayer());
            catDownSoundPlayers.Add(new SoundPlayer());


            /* 根据音量，选择对应的音频 */
            SetSoundPlayer(AppManager.AppDatas.SettingData.Volume);

        }
        #endregion

        #region 公开方法-[播放+停止 音效]
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="_audioType">音效类型</param>
        public void PlayAudio(AudioType _audioType)
        {
            //如果用户设置的是不播放音效，就不执行之后的代码了
            if (AppManager.AppDatas.SettingData.Volume <= 0)return;


            //播放声音
            switch (_audioType)
            {
                case AudioType.Complete:
                    completeMediaPlayer.Volume = AppManager.AppDatas.SettingData.Volume / 100.0f;
                    completeMediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/Asset/Audio/Complete/Complete(Volume1.0).wav", UriKind.Absolute));
                    completeMediaPlayer.Stop();
                    completeMediaPlayer.Play();
                    break;

                case AudioType.CatUp:
                    int _catUpIndex = Tools.GetRandom(0, catUpSoundPlayers.Count);//随机一个音频播放
                    catUpSoundPlayers[_catUpIndex].Play();
                    break;
                case AudioType.CatDown:
                    int _catDownIndex = Tools.GetRandom(0, catDownSoundPlayers.Count);//随机一个音频播放
                    catDownSoundPlayers[_catDownIndex].Play();
                    break;

                case AudioType.DefaultButtonDown:
                    defaultButtonDownSoundPlayer.Play();
                    break;
                case AudioType.DefaultButtonUp:
                    defaultButtonUpSoundPlayer.Play();
                    break;

                case AudioType.AddOrlessNumberSoundPlayer:
                    addOrlessNumberSoundPlayer.Play();
                    break;
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

        #region 公开方法-[事件]
        /// <summary>
        /// 当音量更改时，触发此方法
        /// </summary>
        /// <param name="_volume">音量大小(0-100)</param>
        public void OnVolumeChange(int _volume)
        {
            SetSoundPlayer(_volume);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 根据音量，设置
        /// </summary>
        /// <param name="volume"></param>
        private void SetSoundPlayer(int _volume)
        {
            /* 设置[音效] */
            switch (_volume)
            {
                /* 如果音量为100 */
                case 100:
                    //[普通按钮按下]+[普通按钮抬起]的音效
                    defaultButtonDownSoundPlayer.Stream = Properties.Resources.DefaultButtonDown_Volume1_0_;
                    defaultButtonUpSoundPlayer.Stream = Properties.Resources.DefaultButtonUp_Volume1_0_;

                    //[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
                    addOrlessNumberSoundPlayer.Stream = Properties.Resources.AddOrLessNumber_Volume1_0_;

                    //[猫咪站起来]的音效
                    catUpSoundPlayers[0].Stream = Properties.Resources.CatUp_01_Volume1_0_;
                    catUpSoundPlayers[1].Stream = Properties.Resources.CatUp_02_Volume1_0_;
                    catUpSoundPlayers[2].Stream = Properties.Resources.CatUp_03_Volume1_0_;

                    //[猫咪坐下]的音效
                    catDownSoundPlayers[0].Stream = Properties.Resources.CatDown_01_Volume1_0_;
                    catDownSoundPlayers[1].Stream = Properties.Resources.CatDown_02_Volume1_0_;
                    catDownSoundPlayers[2].Stream = Properties.Resources.CatDown_03_Volume1_0_;
                    break;


                /* 如果音量为80 */
                case 80:
                    //[普通按钮按下]+[普通按钮抬起]的音效
                    defaultButtonDownSoundPlayer.Stream = Properties.Resources.DefaultButtonDown_Volume0_8_;
                    defaultButtonUpSoundPlayer.Stream = Properties.Resources.DefaultButtonUp_Volume0_8_;

                    //[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
                    addOrlessNumberSoundPlayer.Stream = Properties.Resources.AddOrLessNumber_Volume0_8_;

                    //[猫咪站起来]的音效
                    catUpSoundPlayers[0].Stream = Properties.Resources.CatUp_01_Volume0_8_;
                    catUpSoundPlayers[1].Stream = Properties.Resources.CatUp_02_Volume0_8_;
                    catUpSoundPlayers[2].Stream = Properties.Resources.CatUp_03_Volume0_8_;

                    //[猫咪坐下]的音效
                    catDownSoundPlayers[0].Stream = Properties.Resources.CatDown_01_Volume0_8_;
                    catDownSoundPlayers[1].Stream = Properties.Resources.CatDown_02_Volume0_8_;
                    catDownSoundPlayers[2].Stream = Properties.Resources.CatDown_03_Volume0_8_;
                    break;


                /* 如果音量为60 */
                case 60:
                    //[普通按钮按下]+[普通按钮抬起]的音效
                    defaultButtonDownSoundPlayer.Stream = Properties.Resources.DefaultButtonDown_Volume0_6_;
                    defaultButtonUpSoundPlayer.Stream = Properties.Resources.DefaultButtonUp_Volume0_6_;

                    //[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
                    addOrlessNumberSoundPlayer.Stream = Properties.Resources.AddOrLessNumber_Volume0_6_;

                    //[猫咪站起来]的音效
                    catUpSoundPlayers[0].Stream = Properties.Resources.CatUp_01_Volume0_6_;
                    catUpSoundPlayers[1].Stream = Properties.Resources.CatUp_02_Volume0_6_;
                    catUpSoundPlayers[2].Stream = Properties.Resources.CatUp_03_Volume0_6_;

                    //[猫咪坐下]的音效
                    catDownSoundPlayers[0].Stream = Properties.Resources.CatDown_01_Volume0_6_;
                    catDownSoundPlayers[1].Stream = Properties.Resources.CatDown_02_Volume0_6_;
                    catDownSoundPlayers[2].Stream = Properties.Resources.CatDown_03_Volume0_6_;
                    break;


                /* 如果音量为40 */
                case 40:
                    //[普通按钮按下]+[普通按钮抬起]的音效
                    defaultButtonDownSoundPlayer.Stream = Properties.Resources.DefaultButtonDown_Volume0_4_;
                    defaultButtonUpSoundPlayer.Stream = Properties.Resources.DefaultButtonUp_Volume0_4_;

                    //[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
                    addOrlessNumberSoundPlayer.Stream = Properties.Resources.AddOrLessNumber_Volume0_4_;

                    //[猫咪站起来]的音效
                    catUpSoundPlayers[0].Stream = Properties.Resources.CatUp_01_Volume0_4_;
                    catUpSoundPlayers[1].Stream = Properties.Resources.CatUp_02_Volume0_4_;
                    catUpSoundPlayers[2].Stream = Properties.Resources.CatUp_03_Volume0_4_;

                    //[猫咪坐下]的音效
                    catDownSoundPlayers[0].Stream = Properties.Resources.CatDown_01_Volume0_4_;
                    catDownSoundPlayers[1].Stream = Properties.Resources.CatDown_02_Volume0_4_;
                    catDownSoundPlayers[2].Stream = Properties.Resources.CatDown_03_Volume0_4_;
                    break;


                /* 如果音量为20 */
                case 20:
                    //[普通按钮按下]+[普通按钮抬起]的音效
                    defaultButtonDownSoundPlayer.Stream = Properties.Resources.DefaultButtonDown_Volume0_2_;
                    defaultButtonUpSoundPlayer.Stream = Properties.Resources.DefaultButtonUp_Volume0_2_;

                    //[增加或减少][分钟数或者秒钟数]的音效（设定时间的界面）
                    addOrlessNumberSoundPlayer.Stream = Properties.Resources.AddOrLessNumber_Volume0_2_;

                    //[猫咪站起来]的音效
                    catUpSoundPlayers[0].Stream = Properties.Resources.CatUp_01_Volume0_2_;
                    catUpSoundPlayers[1].Stream = Properties.Resources.CatUp_02_Volume0_2_;
                    catUpSoundPlayers[2].Stream = Properties.Resources.CatUp_03_Volume0_2_;

                    //[猫咪坐下]的音效
                    catDownSoundPlayers[0].Stream = Properties.Resources.CatDown_01_Volume0_2_;
                    catDownSoundPlayers[1].Stream = Properties.Resources.CatDown_02_Volume0_2_;
                    catDownSoundPlayers[2].Stream = Properties.Resources.CatDown_03_Volume0_2_;
                    break;
            }




            /* 设置[完成]的音乐 */
            completeMediaPlayer.Volume = _volume / 100.0f;




            /* 加载音频（提前加载音频）*/
            defaultButtonDownSoundPlayer.Load();
            defaultButtonUpSoundPlayer.Load();
            for (int i = 0; i < catUpSoundPlayers.Count; i++)
            {
                catUpSoundPlayers[i].Load();
            }
            for (int i = 0; i < catDownSoundPlayers.Count; i++)
            {
                catDownSoundPlayers[i].Load();
            }
        }
        #endregion
    }
}
