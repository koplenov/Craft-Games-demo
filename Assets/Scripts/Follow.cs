using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float smooth = 5.0f;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position, target.position,
            Time.deltaTime * smooth);
    }
}