using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class HurtPlayerOnContact : MonoBehaviour
{
    private bool isColliding;
    public int damageToGive;
    public AudioClip hurtClip;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false; // prevent calling RespawnPlayer more than 1 time (since player keeps colliding with the enemy "while dying")
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            isColliding = true;
            HealthManager.HurtPlayer(damageToGive);
            PlayHurtSound();

            var player = other.GetComponent<PlatformerCharacter2D>();
            player.knockBackCount = player.knockBackLength;
            player.knockFromRight = other.transform.position.x < transform.position.x;
        }
    }

    private void PlayHurtSound()
    {
        var audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.PlayOneShot(hurtClip);
            //AudioSource.PlayClipAtPoint(audioClip, transform.position);
            //audioSource.Play();
        }
    }
}
