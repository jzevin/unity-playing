using UnityEngine;

public class Turret2 : MonoBehaviour
{
    public GameObject spawnPoint, top, projectile, muzzleFlashLight;
    public float spawnInterval, force;

    private Light lightSource;
    void Start()
    {
        InvokeRepeating("FireProjectile", 1f, spawnInterval);
        lightSource = muzzleFlashLight.GetComponent<Light>();
        lightSource.enabled = true;
        lightSource.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        top.transform.Rotate(Vector3.up, 0.15f);
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward * 2, Color.red);

        if(lightSource.intensity > 0) {
            FadeLight();
        }
    }

    private void FireProjectile()
    {
        GameObject bullet = Instantiate<GameObject>(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * force, ForceMode.Impulse);
        
        lightSource.intensity = 36;
    }

     void FadeLight()
    {
        if (lightSource != null)
        {
            lightSource.intensity -= 3f;
            if (lightSource.intensity <= 0)
            {
                lightSource.intensity = 0;
            }
        }
    }
}
