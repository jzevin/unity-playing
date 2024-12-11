using UnityEngine;
using UnityEngine.UIElements;

public class PlayerC : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform collectionPoint;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckForBoxCastCollision();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
    }

    void CheckForBoxCastCollision()
    {
        Debug.DrawRay(transform.position, transform.forward * 2f, Color.red, 2f);
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, new Vector3(0.5f, 0.5f, 0.5f), transform.forward, out hit, transform.rotation, 2f))
        {
            ICollectable collectable = hit.collider.GetComponent<ICollectable>();
            if (collectable != null){
                Debug.Log(hit.transform.name);
                collectable.Collect(collectionPoint);
            }

        } else {
                transform.GetComponentInChildren<ICollectable>()?.Throw(transform.forward);
            }
        
    }
}
