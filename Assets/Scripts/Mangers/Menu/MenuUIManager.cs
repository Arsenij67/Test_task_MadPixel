using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
namespace Menu {
    public class MenuUIManager :MonoBehaviour {

        public MenuManager menuManager;
        [SerializeField] private TMP_Text langText;
        [SerializeField] Button playGameButton;
        [SerializeField] private GameReadyApi gameReadyAPI;
        public void Init() {
            playGameButton.onClick.AddListener(PlayGame);
            langText.text = YG2.envir.language;
           
      
        }
        private void Start()
        {
            gameReadyAPI.OnLoadingAPIReady();
        }
        private void PlayGame() => menuManager.PlayGame();
    }
}