using UnityEngine;
using UnityEngine.InputSystem;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private StateMachine stateMachineScript;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (optionMenu.activeSelf)
            {
                optionMenu.SetActive(false);
            }
            else
            {
                optionMenu.SetActive(true);
                stateMachineScript.currentState = StateMachine.State.InOption;
            }
            
        }
    
    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
