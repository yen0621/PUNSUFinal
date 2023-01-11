using UnityEngine;

namespace Leaf
{
    /// <summary>
    ///  ���Ĩt��
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
        /// ���񭵮�
        /// </summary>
        /// <param name="sound"></param>
        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }
    }
}


