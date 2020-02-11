using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class joystick3 : MonoBehaviour
{

    GraphicRaycaster gr;
    // Start is called before the first frame update

    public Transform innerCircle;
    public Transform outerCircle;

    public character character;

    private bool isActive;
    private int joystickFingerId;
    void Start()
    {
        isActive = false;
        gr = GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Touch[] touches = Input.touches;
        //print("touches" + touches.Length);

        PointerEventData ped = new PointerEventData(EventSystem.current);
        foreach (Touch t in touches)
        {
            if(t.fingerId == joystickFingerId)
            {
                manageJoystick(t);
            }

            ped.position = t.position;
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(ped, results);

            // print(results.Count);
            if (results.Count > 0)
            {
                if (!isActive)
                {
                    manageJoystick(t);
                   // isActive = true;
                }
               
            }
        
        }


           
        
    }
    Vector2 pointA;
    Vector2 pointB;
    private void manageJoystick(Touch touch)
    {
        // print("test");
        Vector3 vector = new Vector3(touch.position.x, touch.position.y, 0);
        print(vector);
       // innerCircle.position = Camera.main.WorldToScreenPoint(vector);

       
       


        if (touch.phase == TouchPhase.Began) {
            joystickFingerId = touch.fingerId;
            pointA = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
            pointB = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            innerCircle.transform.position = pointA;
            outerCircle.transform.position = pointB;
            print("began");
        }else if (touch.phase == TouchPhase.Moved && joystickFingerId !=-1)  //avoid bag 
        {

            pointB = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
            Vector2 offset = (new Vector2((pointB.x - pointA.x), 0));
            Vector2 joysticOffset = pointB - pointA;

            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            Vector2 joysticDirection = Vector2.ClampMagnitude(joysticOffset, 1.0f);
            print(direction);
            character.move(direction);
           // moveCharacter(direction);
            outerCircle.transform.position = new Vector2(pointA.x, pointA.y);
            innerCircle.transform.position = new Vector2(pointA.x + joysticDirection.x, pointA.y + joysticDirection.y);
            print("moved");
        }else if (touch.phase == TouchPhase.Ended){
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            joystickFingerId = -1;
            print("Ended");
        }


    }

  
/*    private void moveCharacter(Vector2 dir)
    {
        isMoving = true;
        character.move(dir);
    }*/
    
}
