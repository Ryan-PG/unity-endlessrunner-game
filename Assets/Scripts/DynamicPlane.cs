using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log(this.transform.parent.position);
            this.transform.parent.position += new Vector3(0, 0, 40);
            Debug.Log(this.transform.parent.position);
        }
    }
}
