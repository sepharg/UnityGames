using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnemyStarController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public GameObject impactEffect;
    public int damageToGive = 1;

    private Rigidbody2D myRigidBody2D;
    private PlatformerCharacter2D player;

    // Use this for initialization
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlatformerCharacter2D>();

        if (player.transform.position.x < transform.position.x) // if player is to the left of where the star is
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody2D.velocity = new Vector2(speed, myRigidBody2D.velocity.y);
        myRigidBody2D.angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager.HurtPlayer(damageToGive);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        DestroyObject(gameObject);
    }
}
