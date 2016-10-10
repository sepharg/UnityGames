using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour
{
    public float lifeTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if ((lifeTime -= Time.deltaTime) <= 0)
	    {
	        DestroyObject(gameObject);
	    }
	}
}
