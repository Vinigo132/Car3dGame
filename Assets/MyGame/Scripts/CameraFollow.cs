using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = new Vector3(0, 10, -15);

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + target.rotation * offset;
        transform.LookAt(target.position + target.forward * 15f);
    }
}
