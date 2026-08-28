using Unity.VisualScripting;
using UnityEngine;

public class Gallery : MonoBehaviour
{
    [SerializeField] GameObject gallery;
    [SerializeField] StateMachine stateMachineScript;
    public void OpenGallery()
    {
        if (stateMachineScript.currentState == StateMachine.State.Grabbing || stateMachineScript.currentState == StateMachine.State.WaitChoice)
        {

        }
        else 
        { 
            gallery.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        
    }

    public void CloseGallery() { gallery.SetActive(false); }
    
    public void ObjectDebloqued(GameObject objectBloqued)
    {
        objectBloqued.SetActive(false);
    }
}
