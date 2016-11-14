using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	public int playerLives;

	public void NewGame()
	{
		SceneManager.LoadScene (startLevel);
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void LevelSelect()
	{
		SceneManager.LoadScene (levelSelect);
	}
}
