using TMPro;
using UnityEngine;

public class InformationUIController : MonoBehaviour
{
    private static TMP_Text coinTextObj;
    private static TMP_Text timeElapsedTextObj;
    private static readonly string coinsCollectedText = "Coins collected: ";
    private static readonly string timeElapsedText = "Time elapsed - ";
    private float startTime;

    private void Start()
    {
        coinTextObj = GameObject.Find("CoinsTMP").GetComponent<TMP_Text>();
        coinTextObj.SetText(coinsCollectedText);
        timeElapsedTextObj = GameObject.Find("TimeTMP").GetComponent<TMP_Text>();
        timeElapsedTextObj.SetText(timeElapsedText);
        startTime = Time.time;
    }

    private void Update()
    {
        SetElapsedTime();
    }

    public static void SetCoinsCollected(int coinsCollected)
    {
        coinTextObj.SetText(coinsCollectedText + coinsCollected);
    }

    private void SetElapsedTime()
    {
        var t = Time.time - startTime;
        var minutes = ((int) t / 60).ToString();
        var seconds = (t % 60).ToString("f2");

        timeElapsedTextObj.SetText(timeElapsedText + minutes + ":" + seconds);
    }
}