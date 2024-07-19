using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform PlayerTransform;

    [SerializeField] private Vector3 CameraPosition;

    [SerializeField] private float CameraChangePositionSpeed = 7f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(CameraPosition.x + PlayerTransform.position.x, CameraPosition.y + PlayerTransform.position.y, CameraPosition.z + PlayerTransform.position.z), CameraChangePositionSpeed * Time.deltaTime);
    }
}
