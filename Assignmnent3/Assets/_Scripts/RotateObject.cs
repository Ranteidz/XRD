using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * 50f * Time.deltaTime);
    }
}