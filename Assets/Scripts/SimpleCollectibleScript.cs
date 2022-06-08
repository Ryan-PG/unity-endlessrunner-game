using UnityEngine;

public class SimpleCollectibleScript : MonoBehaviour {
    public GameObject collectEffect;

	void Start () {
		
	}
	
	void Update () {
			transform.Rotate (Vector3.up * 150 * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "boy") {
            if (collectEffect)
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
