using UnityEngine;
namespace Game.Audio
{
    public class AudioSwitcher : MonoBehaviour
    {
        private static AudioSwitcher _instance = null;
        public bool IsOn = true;
        public static AudioSwitcher Instance
        {
            get
            {
                // ���� ��������� �� ����������, ������� ����� ������
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
            // ���� ��� ���������� ���������, ���������� ���� ������
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
            IsOn = value;
            AudioListener.volume = value ? 1 : 0; // ������������� ��������� � 0 ��� 1 �� ������ ��������
        }
    }
}