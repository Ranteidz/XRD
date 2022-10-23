using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For testing
public class movement : MonoBehaviour {

    public string AxisHorizontal = "Horizontal";
    public string AxisVertical = "Vertical";

    public string RotationAxisHorizontal = "Horizontal";

    public float Speed = 10f;
    public float RotationSpeed = 10f;
    private Rigidbody rigid;
    
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis(AxisHorizontal);
        float Vertical = Input.GetAxis(AxisVertical);
        float rotation = Input.GetAxis(RotationAxisHorizontal);
        Vector3 Direction = new Vector3(Horizontal, 0, Vertical);
        if (Mathf.Abs(Horizontal) >= 0.1f)
        {
            rigid.AddForce(Horizontal * transform.right*Speed, ForceMode.VelocityChange);
        }
        if (Mathf.Abs(Vertical) >= 0.1f)
        {
            rigid.AddForce(Vertical * transform.forward*Speed, ForceMode.VelocityChange);
        }
        if (Mathf.Abs(rotation) >= 0.1f)
        {
            transform.Rotate(new Vector3(0f, rotation * RotationSpeed, 0f));
        }
    }

}
