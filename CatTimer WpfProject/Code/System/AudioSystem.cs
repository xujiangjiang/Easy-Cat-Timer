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
        private MediaPlayer completeSoundPlayer;//[完成]的音效
        private SoundPlayer defaultButtonDownSoundPlayer;//[普通按钮按下]的音效
        private SoundPlayer defaultButtonUpSoundPlayer;//[普通按钮抬起]的音效
        private List<SoundPlayer> catUpSoundPlayers;//[猫咪站起来]的音效
        private List<SoundPlayer> catDownSoundPlayers;//[猫咪坐下]的音效


        #region 公开属性

        /// <summary>
        /// [完成]音效的长度（单位：秒）
        /// </summary>
        public float CompleteAudioLength
        {
            get { return (float)completeSoundPlayer.NaturalDuration.TimeSpan.TotalSeconds; }
        }

        #endregion

        #region 构造方法
        public AudioSystem()
        {
            //[完成]的音效
            completeSoundPlayer = new MediaPlayer();
            completeSoundPlayer.Open(new Uri(System.Environment.CurrentDirectory+"/Asset/Audio/Complete.wav", UriKind.Absolute));
            completeSoundPlayer.Volume = 1;

            //[普通按钮按下]+[普通按钮抬起]的音效
            defaultButtonDownSoundPlayer = new SoundPlayer(Properties.Resources.DefaultButtonDown);
            defaultButtonUpSoundPlayer = new SoundPlayer(Properties.Resources.DefaultButtonUp);

            //[猫咪站起来]的音效
            catUpSoundPlayers = new List<SoundPlayer>();
            catUpSoundPlayers.Add(new SoundPlayer(Properties.Resources.CatUp_01));
            catUpSoundPlayers.Add(new SoundPlayer(Properties.Resources.CatUp_02));
            catUpSoundPlayers.Add(new SoundPlayer(Properties.Resources.CatUp_03));

            //[猫咪坐下]的音效
            catDownSoundPlayers= new List<SoundPlayer>();
            catDownSoundPlayers.Add(new SoundPlayer(Properties.Resources.CatDown_01));
            catDownSoundPlayers.Add(new SoundPlayer(Properties.Resources.CatDown_02));
            catDownSoundPlayers.Add(new SoundPlayer(Properties.Resources.CatDown_03));



            //加载音频（提前加载音频）
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

        #region 公开方法
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="_audioType">音效类型</param>
        public void PlayAudio(AudioType _audioType)
        {
            //如果用户设置的是不播放音效，就不执行之后的代码了
            if (AppManager.AppDatas.SettingData.IsHaveVoice == false)return;


            //播放声音
            switch (_audioType)
            {
                case AudioType.Complete:
                    completeSoundPlayer.Stop();
                    completeSoundPlayer.Play();
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
                    completeSoundPlayer.Stop();
                    break;
            }
        }
        #endregion
    }
}
