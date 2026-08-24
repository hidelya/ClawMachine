using Unity.VisualScripting;
using UnityEngine;

public class Gallery : MonoBehaviour
{
    [SerializeField] GameObject gallery;
    public void OpenGallery()
    {
        gallery.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        
    }

    public void CloseGallery() { gallery.SetActive(false); }
    
    public void ObjectDebloqued(GameObject objectBloqued)
    {
        objectBloqued.SetActive(false);
    }
}
