using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ReceivingPurchase : MonoBehaviour
{
    private void Awake()
    {
        YG2.ConsumePurchases(true);
    }
    private void OnEnable()
    {
        
        YG2.onPurchaseSuccess += SuccessPurchased;
        YG2.onPurchaseFailed += FailedPurchased;
    }

    private void OnDisable()
    {
        YG2.onPurchaseSuccess -= SuccessPurchased;
        YG2.onPurchaseFailed -= FailedPurchased;
    }

    private void SuccessPurchased(string id)
    {
        // Ваш код для обработки покупки, например:
        string coinsKey = "coins";
        int coins = YG2.GetState(coinsKey);

        if (id == "noAds")
            YG2.SetState(coinsKey, coins + 50);
        ClosePurchaseWindow();
        
    }

    public void OpenPurchaseWindow()
    {
        Debug.Log(999);
        transform.gameObject.SetActive(true);
    }

    public void ClosePurchaseWindow()
    {
        transform.gameObject.SetActive(false);
    }

    private void FailedPurchased(string id)
    {
        
    }

}
