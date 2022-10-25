using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

namespace _Scripts
{
    public class ContinuousMovement : MonoBehaviour
    {
        public XRNode inputSource;
        public float speed = 1;
        public float additionalHeight = 0.2f;
        private XROrigin rig;
        private Vector2 inputAxis;
        private CharacterController character;
   
        // Start is called before the first frame update
        void Start()
        {
            character = GetComponent<CharacterController>();
            rig = GetComponent<XROrigin>();
        }
   
        // Update is called once per frame
        void Update()
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        }

        void FollowHeadset()
        {
            character.height = rig.CameraInOriginSpaceHeight + additionalHeight;
            Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Origin.transform.position);
            character.center = new Vector3(capsuleCenter.x,character.height/2 + character.skinWidth, capsuleCenter.z);
        }
   
        private void FixedUpdate()
        {
            FollowHeadset();
            Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
            Vector3 direction = headYaw *  new Vector3(inputAxis.x, 0, inputAxis.y);
   
            character.Move(direction * Time.fixedDeltaTime * speed);
        }
    }
}
