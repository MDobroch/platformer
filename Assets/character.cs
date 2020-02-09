using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {
	public float maxSpeed = 10f;
	//public Vector2 speed = new Vector2(10, 0);
	public float jumpForce = 5f;
	//float yVel;



	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;


	//private float vSpeed;

	private Vector3 position;

	private  Rigidbody2D rb;
	private bool doJump;
	private bool doMove;


//	[Range(1, 10)]
//	public float jumpVelocity;

	// Use this for initialization
	void Start () {

		position = transform.position;

		rb = GetComponent<Rigidbody2D>();

	}

		// Update is called once per frame
		void FixedUpdate () {

		//Input.GetAxis("horyzontal");

	//		if(Input.GetAxis("Horizontal") >0 || Input.GetAxis("Horizontal") <0)
	//	{
			//move(new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y)); // KOSTYL DETECTED
		//}

			if(doMove){
				move(new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y));
				doMove = false;
			}

			if(doJump){
				jump();
				doJump=false;
			}
			

			//move(new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y));  // keyboard check
		//	if (Input.GetAxis("Vertical") > 0)
		//	{
		//		jump();
		//	}

			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);




			if (Mathf.Abs(position.x - transform.position.x) > 0.00001f)   // KOSTYL DETECTED
			{

				if (position.x < transform.position.x && !facingRight)
				{

					//moving right
					Flip();
				}
				else if (position.x > transform.position.x && facingRight)
				{

					Flip();
				}
				position.x = transform.position.x;
			}



		}
	bool firstTimeJump = true; //KOSTYL delete later
	//bool firtstTimeMove = true; // KOSTYL For keyboard
	void Update()
	{

			if(firstTimeJump && Input.GetKeyDown("w")){
				//doMove = true;
				doJump=true;
				firstTimeJump = false;
			}
			if(!firstTimeJump && Input.GetKeyUp("w")){
				firstTimeJump = true;
			}

			

			if(( Input.GetAxis("Horizontal") >0 || Input.GetAxis("Horizontal") <0))
		{
			//firstTimeJump = false;
			doMove = true;
		
			//move(new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y)); // KOSTYL DETECTED
		}

				if (Input.GetAxis("Vertical") > 0)
			{
	
				//doJump = true;
			}


	//	if(doMove){
	//		move(new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y)); // KOSTYL DETECTED
	//	}

	//	if(doJump){
			
	//	}
	//	yVel = rb.velocity.y;
	//s	print(yVel);

		/*		//Input.GetAxis("horyzontal");
				move(new Vector2(Input.GetAxis("Horizontal"), 0));  // keyboard check
				if (Input.GetAxis("Vertical") > 0)
				{
					jump();
				}*/
	}


	

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}	


	public  void jump()
	{
		if(!grounded){
			//print("Ungrounded force" + jumpForce);
		}
		if (grounded) {
			rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
			print(rb.velocity);

		}
	}

	public void move(Vector2 direction)
	{
		float yVel = rb.velocity.y;
		Vector2 yVelocity = new Vector2(direction.x*12f,  yVel);
		//rb.AddForce(direction * speed, ForceMode2D.Impulse);
		rb.velocity = yVelocity;
	}

	


	//some way to detect collisions with objects

/*
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "floor") {
			grounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "floor")
		{
			grounded = false;
		}
	}*/


}