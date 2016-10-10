using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxPlayerHealth;
    public static int playerHealth;
    private bool isDead;
    private Text text;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (playerHealth <= 0 && !isDead)
	    {
	        playerHealth = 0; // in case we get a negative value
	        levelManager.RespawnPlayer(true);
	        isDead = true;
	    }
	    text.text = playerHealth.ToString();
	}

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
    }

    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
        isDead = false;
    }
}
