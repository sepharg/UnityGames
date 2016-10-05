using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float speed = 5f;
    public bool moveRight;
    private Rigidbody2D rb;

    // Wall check to turn around when hitting it
    public Transform wallCheck;
    public float wallCheckRadius = .2f;
    public LayerMask whatIsWall;
    private bool hittingWall;

    // Edge check to not fall down edges
    private bool notAtEdge;
    public Transform edgeCheck;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
	void Update ()
	{

	    hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
	    notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
	    if (hittingWall || !notAtEdge)
	    {
	        Flip();
	    }

	    if (moveRight)
	    {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
	    else
	    {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        moveRight = !moveRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
