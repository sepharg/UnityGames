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

    public void RespawnPlayer(bool playAnimation)
    {
        StartCoroutine("DoRespawnPlayer", playAnimation);
    }

    public IEnumerator DoRespawnPlayer(bool playAnimation)
    {
        rigidBody.velocity = Vector2.zero; // stop the player
        var currentGravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0f;
        script.enabled = false; // disable the player
        float seconds = 0;
        if (playAnimation)
        {
            animator.SetTrigger("Dying"); // trigger Die animation
            seconds = GetAnimationClip(animator, "RobotDeath").length - 0.05f; // wait for die animation to complete. some magic number so that player doesn´t stand idle before dissapearing!
            yield return new WaitForSeconds(seconds);
        }
        
        playerRenderer.enabled = false; // hide the player 

        if (playAnimation)
        {
            yield return new WaitForSeconds(respawnDelay - seconds);
        }
        else
        {
            yield return new WaitForSeconds(respawnDelay);
        }

        GoToCheckpointAndStart(currentGravity);
    }

    private void GoToCheckpointAndStart(float gravity)
    {
        player.transform.position = currentCheckpoint.transform.position; // move the player to the checkpoint
        script.enabled = true; // enable the player
        playerRenderer.enabled = true; // show the player
        rigidBody.gravityScale = gravity;
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
