using YG;
using UnityEngine;
using UnityEngine.UI;
namespace Game.UI {
    public class SettingMenu :MenuWindow {

        [SerializeField] InGameUIManager inGameUIManager;

      
        [SerializeField] Button restartButton;
        [SerializeField] Button backToMenuButton;

        [SerializeField] private string rewardID = "RestartGame";
        [SerializeField] Button okButton;
        [SerializeField] Button closeButton;
        [Header("music")]
        [SerializeField] Button musicButton;
        [SerializeField] Image musicOff;
        [SerializeField] Image musicOn;
        public override void Init(bool isOpen = false) {
            base.Init(isOpen);
            okButton.onClick.AddListener(CloseSettingMenu);
            closeButton.onClick.AddListener(CloseSettingMenu);
            restartButton.onClick.AddListener(ShowRewardAdv);
            backToMenuButton.onClick.AddListener(BackToMenu);
            musicButton.onClick.AddListener(ChangeMusic);


            //TODO OPEN STICKY ADV
            YG2.StickyAdActivity(YG2.saves.isAdvActive);
        }

        private void CloseSettingMenu() => inGameUIManager.CloseSetting();
        private void ShowRewardAdv()
        {
           YG2.RewardedAdvShow(rewardID, RestartGame);
        }
        private void RestartGame() => inGameUIManager.inGameManager.RestartGame();
        private void BackToMenu() => inGameUIManager.inGameManager.BackToMenu();
        private void ChangeMusic() {
            MusicSwitcher(!musicOff.gameObject.activeSelf);
        }

        private void MusicSwitcher(bool value) {

            musicOff.gameObject.SetActive(value);
            musicOn.gameObject.SetActive(!value);
            inGameUIManager
                .inGameManager
                .audioSwitcher
                .SwitchVolume(!value);
   
        }

    }
}