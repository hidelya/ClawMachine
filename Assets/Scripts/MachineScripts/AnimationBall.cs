using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class AnimationBall : MonoBehaviour
{
    [SerializeField] private GameObject pince;
    [SerializeField] private GameObject ControllerRail;
    public ObjectToPickUp attachedBall;
    private StretchingPince scriptStretchingPince;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject center;
    [SerializeField] private StateMachine stateMachineScript;
    [SerializeField] private PlayerStats playerStatsScript;
    public bool isAnimationFinished = false;

    [SerializeField] private Vector3 position;

    [SerializeField] private GameObject objectOnBallPrefab;
    private List<GameObject> objectsList = new List<GameObject>();

    


    public void StartAnimation()
    {
        isAnimationFinished = false;
        attachedBall = pince.GetComponent<ObjectToPickUp>(); // Balle attaché à la pince
        scriptStretchingPince = ControllerRail.GetComponent<StretchingPince>();
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
            StartCoroutine(Depop(attachedBall.ballPick));
            
           
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
            attachedBall.ballPick.GetComponent<Collider2D>().enabled = false;

            attachedBall.ballPick.layer = LayerMask.NameToLayer("UI");
            attachedBall.ballPick.transform.position = Vector3.MoveTowards(attachedBall.ballPick.transform.position, ciblePosition, speed * Time.deltaTime);
            attachedBall.ballPick.transform.localScale = Vector3.MoveTowards(attachedBall.ballPick.transform.localScale, new Vector3(2, 2, 2), speed * Time.deltaTime);
            

            yield return null;
        }
        isAnimationFinished = true;

        yield return null;

        attachedBall.ballPick.transform.position = ciblePosition;
        attachedBall.ballPick.transform.localScale = new Vector3(2, 2, 2);
        

    }

    IEnumerator Depop(GameObject ballActuelle)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(ballActuelle);
        
        Debug.Log("Animation finished, ball deactivated");


    }

    

    public void ObjectOpen()
    {
        
            Debug.Log("Boucle while");
            GameObject newObject = Instantiate(objectOnBallPrefab, position, Quaternion.identity);
            objectsList.Add(objectOnBallPrefab);
            //objectSpawn = true;
    }

    
}
