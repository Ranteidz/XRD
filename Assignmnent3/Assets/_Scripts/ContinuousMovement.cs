using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

namespace _Scripts
{
    public class ContinuousMovement : MonoBehaviour
    {
        public XRNode inputSource;
        public float speed = 1;
        public float additionalHeight = 0.2f;
        private CharacterController character;
        private Vector2 inputAxis;
        private XROrigin rig;

        // Start is called before the first frame update
        private void Start()
        {
            character = GetComponent<CharacterController>();
            rig = GetComponent<XROrigin>();
        }

        // Update is called once per frame
        private void Update()
        {
            var device = InputDevices.GetDeviceAtXRNode(inputSource);
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        }

        private void FixedUpdate()
        {
            FollowHeadset();
            var headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
            var direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

            character.Move(direction * Time.fixedDeltaTime * speed);
        }

        private void FollowHeadset()
        {
            character.height = rig.CameraInOriginSpaceHeight + additionalHeight;
            var capsuleCenter = transform.InverseTransformPoint(rig.Origin.transform.position);
            character.center =
                new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
        }
    }
}