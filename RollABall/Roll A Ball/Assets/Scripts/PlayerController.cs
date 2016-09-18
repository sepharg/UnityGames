using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody _component;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    // Use this for initialization
	void Start ()
	{
	    _component = GetComponent<Rigidbody>();
	    countText.text = "Count: 0";
	    winText.text = "";
	}

    // Update is called once per frame
	void Update () {

	
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var vector = new Vector3(moveHorizontal, 0, moveVertical);
        _component.AddForce(vector * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count;
            if (count == 7)
            {
                winText.text = "You Win!";
            }
        }
        // Destroy(other.gameObject);
    }
}
