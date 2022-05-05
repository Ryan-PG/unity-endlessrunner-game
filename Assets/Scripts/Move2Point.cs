using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2Point : MonoBehaviour
{
    // This property is gonna be shown on unity inspector
    // And can be set there.
    public Transform[] points;

    // Speed of movement
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // By Lerp function
        // Lerp( FirstPosition, SecondPosition, ..., ThisObjectPosition );
        // 0 for FirstPosition and 1 for SecondPosition
        //this.transform.position = Vector3.Lerp(points[0].position, points[10].position, 0);
        // -1 < Sin < 1 ==> Plus 1                for not being upper than 2 ==> Devide by 2
        this.transform.position = Vector3.Lerp(points[0].position, points[1].position, (Mathf.Sin(speed * Time.time) + 1) / 2);

    }
}
