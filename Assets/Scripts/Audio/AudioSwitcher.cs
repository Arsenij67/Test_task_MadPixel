using UnityEngine;
namespace Game.Audio
{
    public class AudioSwitcher : MonoBehaviour
    {
        private static AudioSwitcher _instance;
        public static AudioSwitcher Instance
        {
            get
            {
                // Если экземпляр не существует, создаем новый объект
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(AudioSwitcher).Name);
                    _instance = singletonObject.AddComponent<AudioSwitcher>();
                    DontDestroyOnLoad(singletonObject);
                }
                return _instance;
            }
        }

        private void Awake()
        {
            // Если уже существует экземпляр, уничтожаем этот объект
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        public void SwitchVolume(bool value)
        {
            AudioListener.volume = value ? 1 : 0; // Устанавливаем громкость в 0 или 1 на основе значения
        }
    }
}