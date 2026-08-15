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


    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject bigButton;

    public bool isRemonte = true;

    private float initialPincePosition;

    private void Update()
    {
        if (bigButton.GetComponent<ButtonState>().IsPressed && isRemonte == true)
        {
            isRemonte = false;
            initialPincePosition = pince.transform.position.y;
            Debug.Log("biggg");
            lineRenderer.enabled = true;

            leftButton.GetComponent<ButtonState>().enabled = false;
            rightButton.GetComponent<ButtonState>().enabled = false;


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

        leftButton.GetComponent<ButtonState>().enabled = true;
        rightButton.GetComponent<ButtonState>().enabled = true;
        lineRenderer.enabled = false;
        isRemonte = true;

    }

}
