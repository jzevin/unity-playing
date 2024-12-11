using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{

    private Rigidbody rb;
    private int currentInvocations = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Collect(Transform parent)
    {
        rb.useGravity = false;
        rb.Sleep();
        transform.position = parent.position;
        transform.SetParent(parent);
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
        rb.AddForce(direction * 2.5f, ForceMode.Impulse);
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