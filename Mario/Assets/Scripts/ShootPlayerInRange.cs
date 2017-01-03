using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class ShootPlayerInRange : MonoBehaviour
{

    public float playerRange;
    public GameObject enemyStar;
    private PlatformerCharacter2D player;
    public Transform launchPoint;
    public float waitBetweenShots;
    private float shotCounter;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlatformerCharacter2D>();
        shotCounter = waitBetweenShots;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

	    shotCounter -= Time.deltaTime;

	    if (shotCounter < 0)
	    {
            // moving right & player on that side & player within range
            if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange)
            {
                Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            }

            if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange)
            {
                Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            }
            shotCounter = waitBetweenShots;
        }       
    }
}
