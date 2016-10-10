using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour
{
    private bool isColliding;   
    public int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        isColliding = false; // prevent calling RespawnPlayer more than 1 time (since player keeps colliding with the enemy "while dying")
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            isColliding = true;
            HealthManager.HurtPlayer(damageToGive);
        }
    }
}
