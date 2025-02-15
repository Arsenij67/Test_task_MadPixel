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

            //TODO SAVE Music Value
            musicOff.gameObject.SetActive(true);
            musicOn.gameObject.SetActive(false);

            //TODO OPEN STICKY ADV
            YG2.StickyAdActivity(true);
        }

        private void CloseSettingMenu() => inGameUIManager.CloseSetting();
        private void ShowRewardAdv()
        {
            YG2.RewardedAdvShow(rewardID, RestartGame);
        }
        private void RestartGame() => inGameUIManager.inGameManager.RestartGame();
        private void BackToMenu() => inGameUIManager.inGameManager.BackToMenu();
        private void ChangeMusic() {
            if (musicOff.gameObject.activeSelf) MusicSwitcher(false);
            else MusicSwitcher(true);
        }

        private void MusicSwitcher(bool value) {

            musicOff.gameObject.SetActive(!inGameUIManager.inGameManager.audioSwitcher.IsOn);
            musicOn.gameObject.SetActive(inGameUIManager.inGameManager.audioSwitcher.IsOn);
            inGameUIManager
                .inGameManager
                .audioSwitcher
                .SwitchVolume(value);
   
        }

    }
}