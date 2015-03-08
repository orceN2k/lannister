using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {

	public float maxSpeed = 10f;
	private bool facingRight = true;

	private Animator animator;
	
	public Transform groundCheck;
	public LayerMask whatIsGround;	
	private bool grounded = false;
	private bool canDoubleJump = false;
	private float groundRadius = 0.2f;
	public float jumpForce = 700f;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool ("Ground", grounded);

		animator.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis("Horizontal");

		animator.SetFloat ("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
	
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip();
		}
	}

	void Update(){
		// Jump function
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if(grounded) {
				animator.SetBool("Ground", false);
				rigidbody2D.AddForce(new Vector2(0, jumpForce));
				canDoubleJump = true;
			} else {
				if (canDoubleJump){
					canDoubleJump = false;
					rigidbody2D.AddForce(new Vector2(0, jumpForce));
				}
			}
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
