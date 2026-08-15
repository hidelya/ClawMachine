using System.Collections;
using UnityEngine;

public class AnimationBall : MonoBehaviour
{
    [SerializeField] private GameObject pince;
    [SerializeField] private GameObject ControllerRail;
    private ObjectToPickUp attachedBall;
    private stretchingPince scriptStretchingPince;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject center;


    private void Update()
    {
        attachedBall = pince.GetComponent<ObjectToPickUp>(); // Balle attaché à la pince
        scriptStretchingPince = ControllerRail.GetComponent<stretchingPince>();
        if (attachedBall.ballPick != null && scriptStretchingPince.isRemonte == true)
        {
            pince.GetComponent<FixedJoint2D>().enabled = false;

            Rigidbody2D rb = attachedBall.ballPick.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            Vector3 ciblePosition = center.transform.position; // Position de la cible (centre)
            StartCoroutine(DeplacerVersCible(ciblePosition));
            StartCoroutine(DepopBall(attachedBall.ballPick));

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

        attachedBall.ballPick.transform.position = ciblePosition;

    }

    IEnumerator DepopBall(GameObject ballActuelle)
    {
        yield return new WaitForSeconds(1.5f);
        attachedBall.ballPick.SetActive(false);
    }
}
