using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class LadderZone : MonoBehaviour {

	private PlatformerCharacter2D thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlatformerCharacter2D> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			thePlayer.onLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			thePlayer.onLadder = false;
		}
	}
}
