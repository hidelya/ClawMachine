using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonState : MonoBehaviour
{
    
    
    public bool isSurvol = false;
    public bool IsPressed { get; set; } = false;

    public void OnMouseEnter()
    {
        isSurvol = true;
        Debug.Log("survol");
    }

    public void OnMouseExit()
    {
        isSurvol = false;
        Debug.Log("pas survol");
    }

    public void Update()
    {
        if (isSurvol == true)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                IsPressed = true;

                Debug.Log("pressed");

            }
            else { IsPressed = false; }


        }
    }
}
