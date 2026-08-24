using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class StretchingPince : MonoBehaviour
{


    [SerializeField] private GameObject controllerRail;
    [SerializeField] private GameObject pince;
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private float descenteMax = 5f;
    public float descenteSpeed { get; set;} = 2f;


    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject bigButton;

    [SerializeField] private StateMachine stateMachine;

    private float initialPincePosition;

    public bool isDown = false;

    public void StartDescente()
    {
        isDown = false;
        initialPincePosition = pince.transform.position.y;
        lineRenderer.enabled = true;
        StartCoroutine(DescenteCoroutine());
    }

    IEnumerator DescenteCoroutine()
    {
        float targetY = initialPincePosition - descenteMax;
        while (pince.transform.position.y > targetY)
        {

            Debug.Log("descente");
            pince.transform.position += Vector3.down * descenteSpeed * Time.deltaTime;
            Vector3 susPos = controllerRail.transform.position;
            lineRenderer.SetPosition(0, susPos);
            Vector3 pincePos = pince.transform.position;
            lineRenderer.SetPosition(1, pincePos);
            yield return null;
        }

        while (pince.transform.position.y < initialPincePosition)
        {
            pince.transform.position += Vector3.up * descenteSpeed * Time.deltaTime;
            Vector3 susPos = controllerRail.transform.position;
            lineRenderer.SetPosition(0, susPos);
            Vector3 pincePos = pince.transform.position;
            lineRenderer.SetPosition(1, pincePos);
            yield return null;
        }
        
        //leftButton.GetComponent<ButtonState>().enabled = true;
        //rightButton.GetComponent<ButtonState>().enabled = true;
        lineRenderer.enabled = false;
        isDown = true;

        



    }

}
