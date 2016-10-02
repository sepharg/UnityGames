using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    private LevelManager _levelManager;
    private GameObject checkPoint;

    // Use this for initialization
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        checkPoint = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _levelManager.currentCheckpoint = checkPoint;
        }
    }
}
