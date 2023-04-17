using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody playerRB;

    private Vector3 offset;
    private float baseDistance;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
        baseDistance = offset.magnitude;
        offset = offset.normalized;
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        float currentDistance = GetDistance();
        Vector3 target =
            player.transform.position
            + (currentDistance * offset);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            target,
            ref velocity,
            0.5f);

        Camera.main.nearClipPlane =
            0.6f * Vector3.Magnitude(
                transform.position - player.transform.position);

    }

    private float GetDistance()
    {
        // distance = m*speed + baseDistance
        float speed = playerRB.velocity.magnitude;
        float distance = speed + baseDistance;

        return distance;
    }
}