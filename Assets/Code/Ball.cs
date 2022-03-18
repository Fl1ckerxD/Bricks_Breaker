using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 force = new Vector2(0,5);
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Brick"))
            other.GetComponent<Brick>().TakeDamage();
    }
    private void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up);
    }
}
