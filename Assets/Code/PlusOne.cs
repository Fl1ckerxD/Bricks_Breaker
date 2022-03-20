using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : MonoBehaviour
{
    private BallSpawner spawnerSpawner;
    private void Start()
    {
        spawnerSpawner = FindObjectOfType<BallSpawner>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
            AddOneBall();
    }
    private void AddOneBall()
    {
        spawnerSpawner.balls++;
        Destroy(gameObject);
    }
}
