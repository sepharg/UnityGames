using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour 
{
	public float dodge;	
	public float smoothing;
	public float tilt;
	public Vector2	startWait;
	public Vector2 maneuverWait;
	public Vector2 maneuverTime;
	public Boundary boundary;	

	private float targetManeuver;
	private float currentSpeed;
	private Rigidbody rb;
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		currentSpeed = rb.velocity.z;
		StartCoroutine(Evade());
	}

	IEnumerator Evade()
	{
		yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
		while (true)
		{
			// mueve la nave hacia el lado contrario de donde está. si está a la derecha, la mueve a la izquierda y viceversa.
			// de esta manera nunca hace maniobras hacia fuera de la pantalla.
			targetManeuver = Random.Range(1, dodge * -Mathf.Sign(transform.position.x)); 
			yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));										
			targetManeuver = 0;
			yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
		}
	}
	
	void FixedUpdate () 
	{
		float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);	
		rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
		// clamp just in case rb position inside the script
		rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),0.0f,Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x * -tilt);
	}
}
