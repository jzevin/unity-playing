using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed, jumpForce;

    Rigidbody rb;

    float hAxis,vAxis;

    bool shouldJump = false;

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vAxis = Input.GetAxis("Vertical");
        hAxis = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump")) {
            shouldJump = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 vForce = new Vector3(hAxis * speed * Time.fixedDeltaTime, rb.linearVelocity.y, vAxis * speed * Time.fixedDeltaTime);
        rb.linearVelocity = vForce;

        if(shouldJump) {
            Jump();
            shouldJump = false;
        }
        
    }

    void Jump() {
        rb.AddForce(0, jumpForce, 0);
    }
}
