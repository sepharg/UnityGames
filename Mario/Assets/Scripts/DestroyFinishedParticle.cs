using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {
    private ParticleSystem _particleSystem;

    // Use this for initialization
	void Start ()
	{
	    _particleSystem = GetComponent<ParticleSystem>();
	}

    // Update is called once per frame
	void Update () {
	    if (_particleSystem.isPlaying)
	    {
	        return;
	    }
        Destroy(gameObject);
    }
}
