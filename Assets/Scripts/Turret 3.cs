using System.Collections.Generic;
using UnityEngine;

public class Turret3 : MonoBehaviour
{
    public int maxInstances = 500;
    public GameObject projectile, spawnPoint;

    public float rotation, destroyDistance, projectileForce, fireRateChance;

    GameObject spawner;

    private List<GameObject> activeInstances = new List<GameObject>();


    void Start()
    {

        spawner = gameObject;
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }
        if (Input.GetMouseButtonUp(2) || activeInstances.Count > maxInstances)
        {
            RemoveAllInstances();
        }
        spawner.transform.Rotate(Vector3.up * Time.fixedDeltaTime * 10);

        if (Random.Range(0f, 1f) < fireRateChance)
        {
            Fire();
        }

        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward * 2, Color.red);
    }
    private void Fire()
    {
        GameObject instance = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
        instance.transform.Rotate(Vector3.right * rotation);
        activeInstances.Add(instance);
        Rigidbody rb = instance.GetComponent<Rigidbody>();
        // rb.useGravity = false;
        // instance.GetComponent<Collider>().enabled = false;
        rb.AddForce(spawner.transform.forward * projectileForce, ForceMode.Impulse);
    }

    private void CheckInstancesDistance()
    {
        activeInstances.RemoveAll(instance =>
        {
            if (instance == null || Vector3.Distance(instance.transform.position, Vector3.zero) > destroyDistance)
            {
                if (instance != null)
                {
                    Destroy(instance);
                }
                return true;
            }
            return false;
        });
    }

    private void RemoveAllInstances()
    {
        activeInstances.ForEach(instance =>
        {
            if (instance != null)
            {
                Destroy(instance);
            }
        });
        activeInstances.Clear();
    }
}
