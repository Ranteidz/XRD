using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

public class OpenUI : MonoBehaviour
{
    public XRController rightController;
    public InputHelpers.Button AButton;
    public GameObject UI;
    public GameObject CharacterController;
    private bool isEnabled = false;
    public float xAxisOffset=0;
    public float yAxisOffset=0;
    public float zAxisOffset=0;
  
    void Update()
    {
        if (CheckIfActivated(rightController))
        {
            isEnabled = true;
            UI.SetActive(isEnabled);

            Vector3 characterPos = CharacterController.transform.position;

            UI.transform.position = new Vector3(characterPos.x+xAxisOffset,characterPos.y+yAxisOffset,characterPos.z+zAxisOffset);
        }
        else
        {
            isEnabled = false;
            UI.SetActive(isEnabled);
        }
    }

    bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, AButton, out bool isActivated,0.1f);
        Debug.Log(isActivated);
        return isActivated;
    }
}
