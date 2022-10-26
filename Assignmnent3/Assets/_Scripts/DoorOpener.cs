using UnityEngine;

namespace _Scripts
{
    public class DoorOpener : MonoBehaviour
    {
        private bool _isDoorOpen;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Key") && !_isDoorOpen)
            {
                OpenDoor();
                _isDoorOpen = true;
                Object.Destroy(collision.gameObject);
            }
        }

        private void OpenDoor()
        {
            gameObject.transform.Rotate(0, 0, 90);
        }
    }
}