using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public enum button
    {
        Left,
        Right
    }

    [SerializeField] private button position;
    [SerializeField] private GameObject pince;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;



    private bool isSurvol = false;

    private void OnMouseEnter()
    {
        isSurvol = true;
    }

    private void OnMouseExit()
    {
        isSurvol = false;
    }
    private void Update()
    {
        if (isSurvol == true && position == button.Left)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                Debug.Log("gauche");
                Vector3 nouvellePos = pince.transform.position + Vector3.left * speed * Time.deltaTime;

                // 2. Bloque la valeur X entre minX et maxX
                nouvellePos.x = Mathf.Clamp(nouvellePos.x, minX, maxX);

                // 3. Applique la position limitée
                pince.transform.position = nouvellePos;

            }
        }
        else if (isSurvol == true && position == button.Right)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                Debug.Log("droite");
                Vector3 nouvellePos = pince.transform.position + Vector3.right * speed * Time.deltaTime;

                // 2. Bloque la valeur X entre minX et maxX
                nouvellePos.x = Mathf.Clamp(nouvellePos.x, minX, maxX);

                // 3. Applique la position limitée
                pince.transform.position = nouvellePos;
            }
        }


    }

}
