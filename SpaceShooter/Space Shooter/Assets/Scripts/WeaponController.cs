using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	private AudioSource audioSource; 
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		// en vez de Coroutine, se puede usar esto
		InvokeRepeating("Fire", delay, fireRate);
	}
	
	void Fire () {
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		audioSource.Play();
	}
}
