using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class InformationUIController : MonoBehaviour
    {
        private static TMP_Text _coinTextObj;
        private static TMP_Text _timeElapsedTextObj;
        private static readonly string coinsCollectedText = "Coins collected: ";
        private static readonly string timeElapsedText = "Time elapsed - ";
        private float _startTime;

        private void Start()
        {
            _coinTextObj = GameObject.Find("CoinsTMP").GetComponent<TMP_Text>();
            _coinTextObj.SetText(coinsCollectedText);
            _timeElapsedTextObj = GameObject.Find("TimeTMP").GetComponent<TMP_Text>();
            _timeElapsedTextObj.SetText(timeElapsedText);
            _startTime = Time.time;
        }

        private void Update()
        {
            SetElapsedTime();
        }

        public static void SetCoinsCollected(int coinsCollected)
        {
            _coinTextObj.SetText(coinsCollectedText + coinsCollected);
        }

        private void SetElapsedTime()
        {
            var t = Time.time - _startTime;
            var minutes = ((int) t / 60).ToString();
            var seconds = (t % 60).ToString("f2");

            _timeElapsedTextObj.SetText(timeElapsedText + minutes + ":" + seconds);
        }
    }
}