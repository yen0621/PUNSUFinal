using UnityEngine;

namespace Leaf
{
    /// <summary>
    ///  音效系統
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundSystem : MonoBehaviour
    {
        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="sound"></param>
        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }
    }
}


