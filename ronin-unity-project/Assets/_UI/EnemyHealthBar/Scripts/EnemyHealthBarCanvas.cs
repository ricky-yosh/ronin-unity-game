using UnityEngine;

public class EnemyHealthBarCanvas : MonoBehaviour
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
