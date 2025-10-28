using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target to Follow")]
    public Transform target;             // drag Bobby here in the Inspector

    [Header("Follow Settings")]
    [Range(0f, 20f)] public float cameraSpeed = 6f; // higher = snappier follow

    [Header("World Bounds")]
    public float minX = -20f;
    public float maxX = 120f;
    public float minY = -5f;
    public float maxY = 30f;

    void Reset()
    {
        // keep 2D camera at z = -10
        Vector3 p = transform.position;
        transform.position = new Vector3(p.x, p.y, -10f);
    }

    void FixedUpdate()
    {
        if (!target) return;

        // smooth follow
        Vector3 desired = new Vector3(target.position.x, target.position.y, -10f);
        Vector3 smoothed = Vector3.Lerp(transform.position, desired, cameraSpeed * Time.fixedDeltaTime);

        // clamp inside level
        float clampX = Mathf.Clamp(smoothed.x, minX, maxX);
        float clampY = Mathf.Clamp(smoothed.y, minY, maxY);

        transform.position = new Vector3(clampX, clampY, -10f);
    }
}
