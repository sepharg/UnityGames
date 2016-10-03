﻿using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{

    public int points = 10;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.AddPoints(points);
            DestroyObject(gameObject);
        }
    }
}