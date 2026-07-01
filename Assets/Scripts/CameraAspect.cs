using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    public float targetAspect = 16f / 9f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        float currentAspect = (float)Screen.width / Screen.height;

        if (currentAspect < targetAspect)
        {
            cam.orthographicSize *= targetAspect / currentAspect;
        }
    }
}