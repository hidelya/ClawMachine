using System;
using UnityEngine;

public class ObjectToPickUp : MonoBehaviour // script attaché à la pince pour attraper la balle
{
    public bool isAttached { get; set; } = false;
    [SerializeField] private FixedJoint2D joint;
    public GameObject ballPick;
    [SerializeField] private StateMachine stateMachineScript;
    [SerializeField] Quaternion rotationObj;
    [SerializeField] private GameObject anchor;


    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.CompareTag("Ball") && isAttached == false)
        {
            Debug.Log("Touche la pince");
            ballPick = collision.gameObject;
            Attached(collision);
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
