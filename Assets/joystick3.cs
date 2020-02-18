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
    private bool isMoving;
    private int joystickFingerId;
    public float offset = 20f;
    void Start()
    {
        isActive  = false;
        isMoving = false;
        gr = GetComponent<GraphicRaycaster>();
        innerCircle.GetComponent<Image>().enabled = false;
        outerCircle.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
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
        // print(vector);
        // innerCircle.position = Camera.main.WorldToScreenPoint(vector);





        if (touch.phase == TouchPhase.Began && joystickFingerId == -1) { //avoid bag 
            joystickFingerId = touch.fingerId;
            // pointA = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x+Camera.main.pixelRect.x, touch.position.y));
            pointA = new Vector2(touch.position.x, touch.position.y);
            pointB = new Vector2(touch.position.x, touch.position.y);
            // pointB = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
            // innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            //outerCircle.GetComponent<SpriteRenderer>().enabled = true;

            innerCircle.transform.position = pointA;
            outerCircle.transform.position = pointB;
            innerCircle.GetComponent<Image>().enabled = true;
            outerCircle.GetComponent<Image>().enabled = true;
            // outerCircle.transform.position = pointB;
           // print("began");
        } else if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && joystickFingerId != -1 )  //avoid bag 
        {

          //  print("point B" + pointB);
            pointB = new Vector2(touch.position.x, touch.position.y);
            //pointB = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x + Camera.main.pixelRect.x, touch.position.y+Camera.main.pixelRect.y));


            //pointB = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
            Vector2 offset = (new Vector2((pointB.x - pointA.x), 0));
            Vector2 joysticOffset = pointB - pointA;

            Vector2 direction = Vector2.ClampMagnitude(offset, 100f);
            Vector2 joysticDirection = Vector2.ClampMagnitude(joysticOffset, 100.0f);
            //print(direction);
            isMoving = true;
            character.move(direction);
            //  character.move(joysticDirection);
            // moveCharacter(direction);
            outerCircle.transform.position = new Vector2(pointA.x, pointA.y);
            innerCircle.transform.position = new Vector2(pointA.x + joysticDirection.x, pointA.y + joysticDirection.y);
         //   print("moved");
        } else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
            innerCircle.GetComponent<Image>().enabled = false;
            outerCircle.GetComponent<Image>().enabled = false;
            // innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            //  outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            joystickFingerId = -1;
          //  print("Ended");
        }


    }

  
/*    private void moveCharacter(Vector2 dir)
    {
        isMoving = true;
        character.move(dir);
    }*/
    
}
