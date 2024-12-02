using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject source;
    public Color[] colors;

    [Range(0.25f, 1f)]
    public float randomScaleRange;

    public int maxObjects;

    public float spawnInterval;

    List<GameObject> objects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // GameObject.Find("Cube").GetComponent<MeshRenderer>().material.color = colors[1];
        InvokeRepeating("makeObj", 1f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonUp(0))
        // {
        //     CancelInvoke("makeObj");
        // }
        if(objects.Count > maxObjects) {
            Destroy(objects[0]);
            objects.RemoveAt(0);
        }
    }

    private void makeObj()
    {
        GameObject instance = Instantiate<GameObject>(
            source, transform.position, Quaternion.identity, transform
        );

        Color color = colors[Random.Range(0, colors.Length)];
        instance.GetComponent<MeshRenderer>().material.color = color;
        
        instance.transform.localScale = new Vector3(randomScaleRange, randomScaleRange, randomScaleRange);
        // instance.transform.eulerAngles = new Vector3(randomScaleRange * 30, 0f, 0f);

        objects.Add(instance);
    }
}
