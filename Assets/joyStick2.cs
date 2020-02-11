using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joyStick2 : MonoBehaviour
{

    public Transform innerCircle;
    public Transform outerCircle;
    BoxCollider2D joystickZone;
    public int joystickFingerId;
    public Dictionary<int, Touch> ActiveTouches;


    public character player;

    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        joystickZone = GetComponent<BoxCollider2D>();
        ActiveTouches = new Dictionary<int, Touch>();
    }

    // Update is called once per frame
    void FixedUpdate()

    {

        Touch[] touches = Input.touches;
        // print(touches.Length);

        foreach (Touch touch in touches) {
            print(touch.fingerId);
            Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);

            if (joystickZone == Physics2D.OverlapPoint(touchPos)) {
                handleJoystickZone(touch);

            }
            else
            {
                handleButtonZone(touch);
            }


           /* if (touch.phase == TouchPhase.Began && joystickZone == Physics2D.OverlapPoint(touchPos))
            {
                joystickFingerId = touch.fingerId;
                handleJoystickZone(touch);
            }
            else if (touch.phase == TouchPhase.Moved && joystickZone == Physics2D.OverlapPoint(touchPos))
            {
                handleJoystickZone(touch);
            } else
            {
                if (touch.fingerId == joystickFingerId)
                {
                    print("button");
                    handleButtonZone(touch);
                }

            }*/


/*                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                print(touch.phase );
                if (joystickZone == Physics2D.OverlapPoint(touchPos))
                {
                    print("overlap");
                    //handle joystick zone
                    handleJoystickZone(touch);
                }
                else
                {
                    handleButtonZone(touch);

                    //handle button zone
                }
                // ActiveTouches.Add(touch.fingerId, touch);
            }*/
                
                /*else if(touch.phase == TouchPhase.Moved)
            {
                print("Moved");

                if (joystickZone == Physics2D.OverlapPoint(touchPos))
                {
                    //handle joystick zone
                    handleJoystickZone(touch);
                }
                else
                {
                    handleButtonZone(touch);

                    //handle button zone
                }
            }*/
     /*       else if (touch.phase == TouchPhase.Ended)
            {
                print("remove");
             //  ActiveTouches.Remove(touch.fingerId);
            }*/
           

        }


        //print(touches.Length);
        //print(ActiveTouches);
        /*     foreach (Touch t in ActiveTouches)
             {

                     print(t.fingerId);
             }
           //  ActiveTouches.Clear();*/

    /*    ActiveTouches.
        foreach(Touch touch in ActiveTouches)
        {

        }*/



/*
        if (touches.Length > 0){ 
            foreach(Touch touch in touches)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                if (joystickZone == Physics2D.OverlapPoint(touchPos)){
                    //handle joystick zone
                    handleJoystickZone(touch);
                }
                else
                {
                    handleButtonZone(touch);

                    //handle button zone
                }


            }
        // Touch touch = Input.GetTouch(0);

*//*           // Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
          //  Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (joystickZone == Physics2D.OverlapPoint(touchPos))
            {
                print("hurra!");
            }
            else { 
            
                //handle button
            }

        *//*

        }*/



        /*   if (touch.position.x <= Camera.main.scaledPixelWidth * 0.8f)


           if(touch.phase ==
           {
               print("Hurra");
           }*/



    }

    private void handleJoystickZone(Touch touch)
    {
        joystickFingerId = touch.fingerId;

        Vector2 startTouchPoint;
        Vector2 movedTouchPoint;

        Vector2 touchInWorld = Camera.main.ScreenToWorldPoint(touch.position);



        if (touch.phase == TouchPhase.Began )
        {
            //print("began");
            startTouchPoint = touch.position;
            print(startTouchPoint);
           // Vector2 touchInWorld = Camera.main.ScreenToWorldPoint(startTouchPoint);
            innerCircle.transform.position = new Vector3(touchInWorld.x, touchInWorld.y, 0);
            outerCircle.transform.position = new Vector3(touchInWorld.x, touchInWorld.y, 0);
            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            //outerCircle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(startTouchPoint.x, startTouchPoint.y, 0));
        
        }
        else if(touch.phase == TouchPhase.Moved)
        {
            movedTouchPoint = touch.position;
            Vector2 movedInWorld = Camera.main.ScreenToWorldPoint(movedTouchPoint);
            innerCircle.transform.position = new Vector3(movedInWorld.x, movedInWorld.y, 0);

        }else if(touch.phase == TouchPhase.Ended)
        {
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

       
   
 /*       isMoving = false;
        if (Input.GetMouseButtonDown(0))
        {

            pointA = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            innerCircle.transform.position = pointA * -1;
            innerCircle.transform.position = pointA * -1;

        }

        if (Input.GetMouseButton(0))
        {
            *//*        if (Input.mousePosition.x > Camera.main.scaledPixelWidth / 2)
                    {
                        return;
                    }*//*
            touchStart = true;
            // pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        }
        else
        {
            touchStart = false;
        }

        if (touchStart)
        {
            *//*     if (Input.mousePosition.x > Camera.main.scaledPixelWidth / 2)
                 {
                     return;
                 }*//*
            Vector2 offset = (new Vector2((pointB.x - pointA.x), 0));
            Vector2 joysticOffset = pointB - pointA;

            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            Vector2 joysticDirection = Vector2.ClampMagnitude(joysticOffset, 1.0f);
            print(direction);
            moveCharacter(direction);
            outerCircle.transform.position = new Vector2(pointA.x, pointA.y);
            innerCircle.transform.position = new Vector2(pointA.x + joysticDirection.x, pointA.y + joysticDirection.y);
            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {

            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }*/

    }

    private void handleButtonZone(Touch touch)
    {
        //innerCircle.GetComponent<SpriteRenderer>().enabled = false;
        //outerCircle.GetComponent<SpriteRenderer>().enabled = false;
       // innerCircle.GetComponent<SpriteRenderer>().enabled = false;
       // outerCircle.GetComponent<SpriteRenderer>().enabled = false;
    
    //do nothing 
}


    void moveCharacter(Vector2 direction)
    {
        isMoving = true;


        player.move(direction);

    }


}
