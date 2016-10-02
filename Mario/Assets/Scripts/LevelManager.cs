using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private GameObject player;
    public float respawnDelay;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Platformer2DUserControl script;
    private Renderer playerRenderer;

    // Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        script = player.GetComponent<Platformer2DUserControl>();
        playerRenderer = player.GetComponent<Renderer>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine("DoRespawnPlayer");
    }

    public IEnumerator DoRespawnPlayer()
    {
        rigidBody.velocity = Vector2.zero; // stop the player
        script.enabled = false; // disable the player
        animator.SetTrigger("Dying"); // trigger Die animation
        
        var seconds = GetAnimationClip(animator, "RobotDeath").length - 0.05f; // wait for die animation to complete. some magic number so that player doesn´t stand idle before dissapearing!
        yield return new WaitForSeconds(seconds);
        playerRenderer.enabled = false; // hide the player 
        yield return new WaitForSeconds(respawnDelay - seconds);

        GoToCheckpointAndStart();
    }

    private void GoToCheckpointAndStart()
    {
        player.transform.position = currentCheckpoint.transform.position; // move the player to the checkpoint
        script.enabled = true; // enable the player
        playerRenderer.enabled = true; // show the player
    }
    
    private AnimationClip GetAnimationClip(Animator animator, string name)
    {
        if (!animator) return null; // no animator

        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }
        return null; // no clip by that name
    }
}
