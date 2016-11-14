using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class LifeManager : MonoBehaviour {

	// public int startingLives;   we read from the player prefs instead
	private int lifeCounter;

	private Text theText;
	public GameObject gameOverScreen;
	public PlatformerCharacter2D player;

	public string mainMenu;
	public float waitAfterGameOver;

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();
		lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
		player = FindObjectOfType<PlatformerCharacter2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (lifeCounter == 0) 
		{
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}				
		theText.text = "x " + lifeCounter;

		RestartGameIfGameOver ();
	}

	void RestartGameIfGameOver ()
	{
		if (gameOverScreen.activeSelf) {
			waitAfterGameOver -= Time.deltaTime;
		}
		if (waitAfterGameOver < 0) {
			SceneManager.LoadScene (mainMenu);
		}
	}

	public void GiveLife()
	{
		lifeCounter++;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}

	public void TakeLife()
	{
		lifeCounter--;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}

}