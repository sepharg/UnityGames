using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour {
    private Rigidbody _component;

    // Movement
    public float speed;
    public float tilt;
    public Boundary boundary;

    // Shot instantiation
    public GameObject shot;
    public Transform shotSpawn;

    // Shot fire rate
    public float fireRate = 0.5f;
    double nextFire;

    // Use this for initialization
    void Start()
    {
        _component = GetComponent<Rigidbody>();
    }

    // fixedupdate better for physics
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var vector = new Vector3(moveHorizontal, 0, moveVertical);
        _component.velocity = vector * speed;

        _component.position = new Vector3(Mathf.Clamp(_component.position.x, boundary.xMin, boundary.xMax),0.0f, Mathf.Clamp(_component.position.z, boundary.zMin, boundary.zMax));

        _component.rotation = Quaternion.Euler(0.0f,0.0f,_component.velocity.x * -tilt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
}
