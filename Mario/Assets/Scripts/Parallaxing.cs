using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds; // list of the back and foregrounds to be parallaxed
    private float[] parallaxScales; // the proportion of the camera´s movement to move the backgrounds by
    public float smoothing = 1f; // how smooth the parallax is going to be. 

    private Transform cam; // reference to the main camera´s transform
    private Vector3 previousCamPos; // the position of the camera in the previous frame

    void Awake()
    {
        cam = Camera.main.transform;
    }

	// Use this for initialization
	void Start ()
	{
	    previousCamPos = cam.position;
        parallaxScales = new float[backgrounds.Length];

	    for (int i = 0; i < backgrounds.Length; i++)
	    {
	        parallaxScales[i] = backgrounds[i].position.z * -1;
	    }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            var parallax = (previousCamPos.x - cam.position.x)*parallaxScales[i];

            // set a target x position which is the current position plus the parallax
            var backgroundTargetPositionX = backgrounds[i].position.x + parallax;
            
            // create a target position which is the background´s current position with it´s target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);

            // fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

	    previousCamPos = cam.position;
	}
}
