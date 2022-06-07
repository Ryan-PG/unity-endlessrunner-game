using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlane : MonoBehaviour
{
    public Transform[] points; // Dynamic Objects' coordinates
    public GameObject[] prefabs; // GameObjects that is being used as enemy and score
    public GameObject[] blockObjects; // GameObjects shown in the plane

    // Start is called before the first frame update
    void Start()
    {
        blockObjects = new GameObject[points.Length];
        spawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        // For preventing empty area, we use camera tag and not actor tag
        // For this, one of these objects must have RigidBody
        // We give RigidBody to EndPoint and freeze its position
        //if (other.transform.CompareTag("actor"))
        if (other.transform.CompareTag("MainCamera"))
        {
            //Debug.Log(this.transform.parent.position);
            //Debug.Log("HELLLLO");
            this.transform.parent.position += new Vector3(0, 0, 367.929f); // 377.979 - 10.05
            spawnObjects();
            //Debug.Log(this.transform.parent.position);
        }
    }

    private void spawnObjects()
    {
        for (int i=0; i<points.Length; i++)
        {
            int randomObject = Random.Range(0, 4);
            if (randomObject != 0)
            {
                blockObjects[i] = GameObject.Instantiate(prefabs[randomObject], points[i].position, Quaternion.identity);
            }
        }
    }
}
