using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{

    private Rigidbody rb;
    private int currentInvocations = 0;
    private Vector3 newPosition;
    private bool ShouldCollect = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(ShouldCollect && transform.position != newPosition)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 20f);
            // make a condition to check if the object is close enough to the parent
            if(Vector3.Distance(transform.position, newPosition) < 0.1f)
            {
                Debug.Log("Collected");
                transform.position = newPosition;
                ShouldCollect = false;
            }
        }
    }
    
    public void Collect(Transform parent)
    {
        rb.useGravity = false;
        rb.Sleep();
        newPosition = parent.position;
        transform.SetParent(parent);
        ShouldCollect = true;
    }
    

    public void Drop()
    {   
        rb.useGravity = true;
        transform.SetParent(null);
    }

    public void Throw(Vector3 direction)
    {
        rb.useGravity = true;
        transform.SetParent(null);
        rb.AddForce(direction * 3f, ForceMode.Impulse);
        InvokeRepeating(nameof(BringToStopSlowly), 1f, .1f);
    }

    private void BringToStop()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void BringToStopSlowly()
    {
        rb.linearVelocity -= rb.linearVelocity * 0.2f;
        rb.angularVelocity -= rb.angularVelocity * 0.2f;
        currentInvocations++;
        Debug.Log(currentInvocations);
        if (rb.linearVelocity.magnitude < 0.1f)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            CancelInvoke(nameof(BringToStopSlowly));
        }
    }
}