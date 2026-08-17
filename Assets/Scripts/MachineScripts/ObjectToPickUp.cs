using System;
using UnityEngine;

public class ObjectToPickUp : MonoBehaviour // script attaché à la pince pour attraper la balle
{
    private bool isAttached = false;
    [SerializeField] private FixedJoint2D joint;
    public GameObject ballPick;
    [SerializeField] private StateMachine stateMachineScript;

    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.CompareTag("Ball") && isAttached == false)
        {
            stateMachineScript.currentState = StateMachine.State.Grabbing;
            Debug.Log("Touche la pince");
            Attached(collision);
            ballPick = collision.gameObject;
        }
        else
        {
            Debug.Log("rien ne touche");
        }
    }

    private void Attached(Collision2D collision)
    {

        joint.enabled = true;
        joint.connectedBody = collision.rigidbody;
        isAttached = true;
        Debug.Log(joint.connectedBody);
        Debug.Log(gameObject.name + " a été attrapé !");
        
    }

   
}
