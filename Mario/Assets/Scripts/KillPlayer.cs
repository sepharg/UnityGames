using System;
using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    private LevelManager _levelManager;
    private Animator _animator;
    private bool isColliding;

    public int points = 5; // how many points to subtract for dying.
    public bool playDeathAnimation = true;

    // Use this for initialization
	void Start ()
	{
	    _levelManager = FindObjectOfType<LevelManager>();
	}

    // Update is called once per frame
	void Update ()
	{
	    isColliding = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            isColliding = true;
            _animator = other.GetComponent<Animator>();
            ScoreManager.AddPoints(-points);
            _levelManager.RespawnPlayer(playDeathAnimation);
            Debug.Log("Collision" + DateTime.Now.Millisecond);
        }
    }
}
