using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] public GameObject KeyCollider;
    private bool isDoorOpen;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Key") && !isDoorOpen)
        {
            OpenDoor();
            isDoorOpen = true;
        }
    }

    private void OpenDoor()
    {
        gameObject.transform.Rotate(0, 0, 90);
    }
}