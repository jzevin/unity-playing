using UnityEngine;

public class MoveLinearVelocity : MonoBehaviour
{
    public float rotationSpeed = 100;
    public float moveSpeed = 2;

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void RotatePlayer()
    {
        // Rotate the player
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * Input.GetAxis("Horizontal"));
    }

    void MovePlayer()
    {
        // Move the player
        transform.position += transform.forward * Time.deltaTime * moveSpeed * Input.GetAxis("Vertical");
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the player collides with an object tagged "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, -transform.position.z);
        }

    }
}
