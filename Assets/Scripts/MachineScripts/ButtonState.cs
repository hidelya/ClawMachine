using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonState : MonoBehaviour
{
    public enum button
    {
        Left,
        Right,
        Big
    }

    [SerializeField] private button buttonType;
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
        if (isSurvol == true && buttonType == button.Big)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                IsPressed = true;

                Debug.Log("pressed");

            }
            else { IsPressed = false; }

        }
        if (isSurvol == true && buttonType == button.Left || buttonType == button.Right)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                IsPressed = true;

                Debug.Log("pressed");

            }
            else { IsPressed = false; }

        }
    }
}
