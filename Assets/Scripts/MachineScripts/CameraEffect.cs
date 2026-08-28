using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public void ZoomCamera()
    {
        Camera.main.orthographicSize = 8f;
    }

    public void DezoomCamera()
    {
        Camera.main.orthographicSize = 11f;
    }
}
