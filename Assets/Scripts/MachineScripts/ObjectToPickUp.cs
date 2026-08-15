using UnityEngine;

public class ObjectToPickUp : MonoBehaviour
{
    private bool isAttached = false;
    [SerializeField] private FixedJoint2D joint;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Pince"))
        {
            Debug.Log("Touche la pince");
            Attached(collision);
        }
        else
        {
            Debug.Log("rien ne toucje");
        }
    }

    private void Attached(Collision2D collision)
    {
        joint.enabled = true;
        joint.connectedBody = collision.rigidbody;
        isAttached = true;
        Debug.Log(joint.connectedBody);
    }
}
