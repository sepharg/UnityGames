using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour
{
    public int damageToGive;
    public float bounceOnEnemy;
    private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start ()
	{
	    myRigidbody2D = transform.parent.GetComponent<Rigidbody2D>(); // get the player´s rigid body.
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemyHealthManager = other.GetComponent<EnemyHealthManager>();
            enemyHealthManager.GiveDamage(damageToGive);
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, bounceOnEnemy);
        }
    }
}
