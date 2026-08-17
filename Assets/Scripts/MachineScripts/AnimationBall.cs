using System.Collections;
using UnityEngine;

public class AnimationBall : MonoBehaviour
{
    [SerializeField] private GameObject pince;
    [SerializeField] private GameObject ControllerRail;
    public ObjectToPickUp attachedBall;
    private stretchingPince scriptStretchingPince;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject center;
    [SerializeField] private StateMachine stateMachineScript;
    public bool isAnimationFinished = false;


    public void StartAnimation()
    {
        isAnimationFinished = false;
        attachedBall = pince.GetComponent<ObjectToPickUp>(); // Balle attaché à la pince
        scriptStretchingPince = ControllerRail.GetComponent<stretchingPince>();
        Vector3 ciblePosition = center.transform.position;
        if (attachedBall.ballPick != null && !isAnimationFinished)
        {
            pince.GetComponent<FixedJoint2D>().enabled = false;
            Rigidbody2D rb = attachedBall.ballPick.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            // Position de la cible (centre)
            Debug.Log("Avant la coroutine");
            StartCoroutine(DeplacerVersCible(ciblePosition));
            Debug.Log("Après la coroutine");
            StartCoroutine(DepopBall(attachedBall.ballPick));
            
            

        }
        else
        {
            Debug.Log("No ball attached to the pince.");
        }
    }
    IEnumerator DeplacerVersCible(Vector3 ciblePosition)
    {

        while (Vector3.Distance(attachedBall.ballPick.transform.position, ciblePosition) > 0.01f)
        {

            attachedBall.ballPick.transform.position = Vector3.MoveTowards(attachedBall.ballPick.transform.position, ciblePosition, speed * Time.deltaTime);
            attachedBall.ballPick.transform.localScale = Vector3.MoveTowards(attachedBall.ballPick.transform.localScale, new Vector3(5f, 5f, 5f), speed * Time.deltaTime);

            yield return null;
        }
        isAnimationFinished = true;
        yield return null;

        //attachedBall.ballPick.transform.position = ciblePosition;

    }

    IEnumerator DepopBall(GameObject ballActuelle)
    {
        yield return new WaitForSeconds(1.5f);
        attachedBall.ballPick.SetActive(false);
        isAnimationFinished = true;
        Debug.Log("Animation finished, ball deactivated");
        
    }
}
