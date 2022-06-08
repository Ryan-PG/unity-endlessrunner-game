using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlane : MonoBehaviour
{
    public Transform[] assidePoints; // Dynamic Objects' coordinates
    public GameObject[] assidePrefabs; // GameObjects that is being used as enemy and score
    private GameObject[] assideBlockObjects; // GameObjects shown in the plane

    public Transform[] mainPoints; // Dynamic Objects' coordinates
    public GameObject[] mainPrefabs; // GameObjects that is being used as enemy and score
    private GameObject[] mainBlockObjects; // GameObjects shown in the plane

    public Transform heartPosintion;
    public GameObject heart;
    private GameObject heartObject;

    // Start is called before the first frame update
    void Start()
    {
        assideBlockObjects = new GameObject[assidePoints.Length];
        mainBlockObjects = new GameObject[mainPoints.Length];
        heartObject = new GameObject();
        SpawnObjects();
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
            DestroyObjects();
            this.transform.parent.position += new Vector3(0, 0, 367.929f); // 377.979 - 10.05
            SpawnObjects();
            //Debug.Log(this.transform.parent.position);
        }
    }

    private void SpawnObjects()
    {
        // Spawn Cars
        for (int i=0; i<assidePoints.Length; i++)
        {
            int randomObject = Random.Range(0, assidePrefabs.Length);
            //int randomObject = 1;
            if (randomObject != 0 && assidePrefabs[randomObject] != null)
            {
                assideBlockObjects[i] = GameObject.Instantiate(assidePrefabs[randomObject], assidePoints[i].position, Quaternion.identity);
            }
        }

        // Spawn Coins and Blocks
        for (int i = 0; i < mainPoints.Length; i++)
        {
            int randomObject = Random.Range(0, mainPrefabs.Length);
            if (randomObject != 0 && assidePrefabs[randomObject] != null)
            {
                mainBlockObjects[i] = GameObject.Instantiate(mainPrefabs[randomObject], mainPoints[i].position, Quaternion.identity);
            }
        }

        if (Random.Range(0, 2) == 1)
        {
            heartObject = GameObject.Instantiate(heart, heartPosintion.position, Quaternion.identity);
        }

    }

    private void DestroyObjects()
    {
        // Destroy Cars
        foreach (GameObject gameObject in assideBlockObjects)
        {
            if (gameObject != null)
            Destroy(gameObject);
        }

        // Destroy Coins and Blocks
        foreach (GameObject gameObject in mainBlockObjects)
        {
            if (gameObject != null)
                Destroy(gameObject);
        }

        // Destroy Heart
        if (heartObject != null)
            Destroy(heartObject);
    }
}
