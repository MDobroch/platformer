using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform character;
    public Vector3 vector;
    public float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(character.transform.position.x, character.transform.position.y, transform.position.z);
        //print(vector);

       // character.transform.position = Vector3.Lerp(character.transform.position, vector, smoothSpeed * Time.deltaTime);
    
    }
}
