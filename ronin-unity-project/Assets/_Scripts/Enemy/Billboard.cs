using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _cam;

    void LateUpdate()
    {
		transform.LookAt(transform.position + _cam.forward);
    }

    public void SetCamera(Transform cameraTransform)
    {
        _cam = cameraTransform;
    }
}
