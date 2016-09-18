using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    private Rigidbody _component;
    public float speed;

    // Use this for initialization
	void Start () {
        _component = GetComponent<Rigidbody>();
	    _component.velocity = transform.forward * speed;
	}

    // Update is called once per frame
    void Update () {
	
	}
}
