using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPince : MonoBehaviour
{

    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject pince;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;


    private void Update()
    {
        if (leftButton.GetComponent<ButtonState>().IsPressed)
        {

            Debug.Log("gauche");
            Vector3 nouvellePos = pince.transform.position + Vector3.left * speed * Time.deltaTime;

            // 2. Bloque la valeur X entre minX et maxX
            nouvellePos.x = Mathf.Clamp(nouvellePos.x, minX, maxX);

            // 3. Applique la position limitée
            pince.transform.position = nouvellePos;


        }
        else if (rightButton.GetComponent<ButtonState>().IsPressed)
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
