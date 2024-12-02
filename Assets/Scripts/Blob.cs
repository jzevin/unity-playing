using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    
    private Vector3 rotation = new Vector3(-90, 0, 0);
    private int random = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        random = SwitchRandom(random);
        switch (random)
        {
            case 0:
                rotation = new Vector3(-90, 0, 0);
                break;
            case 1:
                rotation = new Vector3(-90, 180, 0);
                break;
            case 2:
                rotation = new Vector3(-90, 90, 0);
                break;
            case 3:
                rotation = new Vector3(-90, -90, 0);
                break;
        }
        rb.MovePosition(rb.position + -transform.up * speed * Time.deltaTime);
        rb.MoveRotation(Quaternion.Euler(rotation));

        if(transform.position.y < -0.5)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    int SwitchRandom(int currentRandom)
    {
        if(Random.Range(0, 100) < 5)
        {
            return Random.Range(0, 4);
        } else
        {
            return currentRandom;
        }
    }
}
