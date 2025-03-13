using TMPro;
using System.Runtime.InteropServices;
using UnityEngine;

public class LanguageDeterminator : MonoBehaviour
{

    private static LanguageDeterminator instance;

    [DllImport("__Internal")]
    private static extern string GetLang();

    [SerializeField] private TextMeshProUGUI textLang;

    private string currLang;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else 
        {
            Destroy(gameObject);
        }
        currLang = GetLang();
        textLang.text = currLang;
    }
}
