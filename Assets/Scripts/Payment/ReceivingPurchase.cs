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
    
        string advKey = "isAdvActived";

        bool isActived = YG2.saves.isAdvActive;

        if (id == "noAds")
        {
            if (isActived)
            {
                YG2.saves.isAdvActive = false;
                YG2.SaveProgress();
            }
        }
        ClosePurchaseWindow();
        
    }

    public void OpenPurchaseWindow()
    {
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
