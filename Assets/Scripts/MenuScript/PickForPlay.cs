using System.Collections;
using UnityEngine;

public class PickForPlay : MonoBehaviour
{
    public bool isAttached { get; set; } = false;
    [SerializeField] private FixedJoint2D joint;
    public GameObject ballPick;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (isAttached == false)
        {
            Debug.Log("Touche la pince");
            ballPick = collision.gameObject;
            Attached(collision);

            if (ballPick.CompareTag("Play")) 
            {
                StartCoroutine(PlayAfterDelay());
            }
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

    IEnumerator PlayAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MachineScene");
    }
}


