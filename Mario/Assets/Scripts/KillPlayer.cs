using System;
using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    private LevelManager _levelManager;
    private Animator _animator;

    // Use this for initialization
	void Start ()
	{
	    _levelManager = FindObjectOfType<LevelManager>();
	}

    // Update is called once per frame
	void Update ()
    {
	        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator = other.GetComponent<Animator>();
            _levelManager.RespawnPlayer();
            Debug.Log("Collision" + DateTime.Now.Millisecond);
        }
    }
}
