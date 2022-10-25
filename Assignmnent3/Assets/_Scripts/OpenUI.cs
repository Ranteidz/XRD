using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace _Scripts
{
    public class OpenUI : MonoBehaviour
    {
        public XRController rightController;
        public InputHelpers.Button AButton;
        public GameObject UI;
        public GameObject CharacterController;
        public float xAxisOffset;
        public float yAxisOffset = 5;
        public float zAxisOffset = 5;
        private bool _isEnabled;

        private void Update()
        {
            if (CheckIfActivated(rightController))
            {
                _isEnabled = true;
                UI.SetActive(_isEnabled);

                var characterPos = CharacterController.transform.position;

                UI.transform.position = new Vector3(characterPos.x + xAxisOffset, characterPos.y + yAxisOffset,
                    characterPos.z + zAxisOffset);
            }
            else
            {
                _isEnabled = false;
                UI.SetActive(_isEnabled);
            }
        }

        private bool CheckIfActivated(XRController controller)
        {
            controller.inputDevice.IsPressed(AButton, out var isActivated, 0.1f);
            return isActivated;
        }
    }
}