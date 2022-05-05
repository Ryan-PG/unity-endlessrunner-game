using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCharacter;
    private Vector3 cameraPosition;
    private Vector3 characterPosition;
    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        // These method call just once for knowing the positions and also the distance
        cameraPosition = this.transform.position;
        characterPosition = mainCharacter.transform.position;
        distance = characterPosition - cameraPosition;
    }

    // Update is called once per frame
    void Update()
    {

        
        
        
    }

    private void LateUpdate()
    {

        // Set Camera Position
        // For locking camera on character we must do it constanly and '''' AFTER CHARACTER MOVEMENT ''''
        // then we do it here in LateUpdate method
        // Because we want to do it just when character moves and also after Updates done
        characterPosition = mainCharacter.transform.position; // At first we must always know mainCharacter's Position
        cameraPosition = characterPosition - distance; // This equation comes from the distance equation in Start method
        this.transform.position = cameraPosition; // Attach cameraPosition to this(camera).transform.position

    }
}
