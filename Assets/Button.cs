using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    public character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void onPointerDown() {
        character.jump();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
