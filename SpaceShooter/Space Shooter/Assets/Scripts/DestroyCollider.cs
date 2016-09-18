using UnityEngine;
using System.Collections;

public class DestroyCollider : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
	    Destroy(other.gameObject);
	}
}
