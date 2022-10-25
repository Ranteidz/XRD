using UnityEngine;

namespace _Scripts
{
    public class CollectCoin : MonoBehaviour
    {
        public int coins;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Coin"))
            {
                coins = coins + 1;
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }

            InformationUIController.SetCoinsCollected(coins);
        }
    }
}