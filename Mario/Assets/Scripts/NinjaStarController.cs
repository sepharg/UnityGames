using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class NinjaStarController : MonoBehaviour
{
    public float speed;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    public int points = 20;
    public int damageToGive = 1;

    private Rigidbody2D rigidBody;
    private PlatformerCharacter2D player;

    // Use this for initialization
	void Start ()
	{
	    rigidBody = GetComponent<Rigidbody2D>();
	    player = FindObjectOfType<PlatformerCharacter2D>();

	    if (player.transform.localScale.x < 0)
	    {
	        speed = -speed;
	    }
	}

    // Update is called once per frame
	void Update () {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") && other.CompareTag("Enemy"))
        {
            var enemyHealthManager = other.GetComponent<EnemyHealthManager>();
            if (enemyHealthManager != null) // enemies with health system
            {
                enemyHealthManager.GiveDamage(damageToGive);
            }
            else // single hit enemies
            {
                Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
                DestroyObject(other.gameObject);
                ScoreManager.AddPoints(points);
            }
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        DestroyObject(gameObject);
    }
}
