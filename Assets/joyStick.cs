using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joyStick : MonoBehaviour
{
    /*[SerializeField]
    public character player; */
    
  
    public character player;

    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform innerCircle;
    public Transform outerCircle;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


    }


    private void FixedUpdate()
    {
        isMoving = false;
        if (Input.GetMouseButtonDown(0))
        {

            pointA = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            innerCircle.transform.position = pointA * -1;
            innerCircle.transform.position = pointA * -1;

        }

        if (Input.GetMouseButton(0))
        {
            /*        if (Input.mousePosition.x > Camera.main.scaledPixelWidth / 2)
                    {
                        return;
                    }*/
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
            /*     if (Input.mousePosition.x > Camera.main.scaledPixelWidth / 2)
                 {
                     return;
                 }*/
            Vector2 offset = (new Vector2((pointB.x - pointA.x), 0));
            Vector2 joysticOffset = pointB - pointA;

            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            Vector2 joysticDirection = Vector2.ClampMagnitude(joysticOffset, 1.0f);

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
        }
    }

    void moveCharacter(Vector2 direction) {
        isMoving = true;


        player.move(direction);

        //player.GetComponent<Rigidbody2D>.velocity = direction;
        //player.moveMe(direction);
        //player.Translate(direction * speed * Time.deltaTime);
       // player.Translate(direction * speed * Time.deltaTime);
    }


    public bool getIsMoving()
    {
        return isMoving;
    }
}
