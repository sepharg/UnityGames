using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public float respawnDelay;
    public GameObject deathParticle;
    private GameObject player;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Platformer2DUserControl playerMovementScript;
    private Renderer playerRenderer;
    private PlatformerCharacter2D playerScript;

    // Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        playerMovementScript = player.GetComponent<Platformer2DUserControl>();
	    playerScript = player.GetComponent<PlatformerCharacter2D>();
	    playerRenderer = player.GetComponent<Renderer>();
    }

    public void RespawnPlayer(bool playAnimation)
    {
        StartCoroutine("DoRespawnPlayer", playAnimation);
    }

    public IEnumerator DoRespawnPlayer(bool playAnimation)
    {
        var currentGravity = DisablePlayer();
        float seconds = 0;
        if (playAnimation)
        {
            animator.SetTrigger("Dying"); // trigger Die animation
            seconds = GetAnimationClip(animator, "RobotDeath").length - 0.05f; // wait for die animation to complete. some magic number so that player doesn´t stand idle before dissapearing!
            yield return new WaitForSeconds(seconds);
        }
        else
        {
            Instantiate(deathParticle, player.transform.position, player.transform.rotation);
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

        GoToCheckpointAndEnablePlayer(currentGravity);
    }

    private float DisablePlayer()
    {
        rigidBody.velocity = Vector2.zero; // stop the player
        var currentGravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0f; // 0 gravity. used when falling to death (to stop keeping falling after dead!)
        playerMovementScript.enabled = false; // disable the player
        return currentGravity;
    }

    private void GoToCheckpointAndEnablePlayer(float gravity)
    {
        player.transform.position = currentCheckpoint.transform.position; // move the player to the checkpoint
        rigidBody.gravityScale = gravity;
        FindObjectOfType<HealthManager>().FullHealth(); // reset health of the player
        playerScript.knockBackCount = 0;
        playerMovementScript.enabled = true; // enable the player
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
