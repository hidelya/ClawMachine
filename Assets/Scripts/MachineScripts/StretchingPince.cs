using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class stretchingPince : MonoBehaviour
{
    

    [SerializeField] private GameObject controllerRail;
    [SerializeField] private GameObject pince;
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private float descenteMax = 5f;
    [SerializeField] private float descenteSpeed = 5f;


    [SerializeField] private MovementScript left;
    [SerializeField] private MovementScript right;

    [SerializeField] private ButtonState scriptButtonState;

    public bool isRemonte = true;

    private float initialPincePosition;

    private void Update()
    {
        if (scriptButtonState.IsPressed == true && isRemonte == true)
        {
            isRemonte = false;
            initialPincePosition = pince.transform.position.y;
            Debug.Log("biggg");
            lineRenderer.enabled = true;

            left.enabled = false;
            right.enabled = false;


            StartCoroutine(DescenteCoroutine());

        }

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

        left.enabled = true;
        right.enabled = true;
        lineRenderer.enabled = false;
        isRemonte = true;

    }

}
