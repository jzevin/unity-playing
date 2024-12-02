using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform top; // Reference to the "Top" GameObject
    public float rotationSpeed = 10f;


    void Start()
    {
        top.Rotate(Vector3.forward, -90);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the top part of the turret based on user input (e.g., mouse movement)
        float horizontalInput = Input.GetAxis("Mouse X");
        top.Rotate(Vector3.forward, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}