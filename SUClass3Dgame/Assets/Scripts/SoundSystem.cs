using UnityEngine;

namespace Leaf
{
    /// <summary>
    /// 音效系統
    /// </summary>
    ///  要求元件 : 在第一次套用此腳本時會添加裡面指定的物件
    [RequireComponent(typeof(AudioSource))]
    public class SoundSystem : MonoBehaviour
    {
        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }
        /// <summary>
        /// 播放音樂
        /// </summary>
        /// <param name="sound"></param>
        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }
    }
}


