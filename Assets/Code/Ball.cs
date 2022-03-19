using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 force = new Vector2(1,0.5f);
    [SerializeField] private int speed = 100;
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(force.normalized * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Brick"))
            other.GetComponent<Brick>().TakeDamage();
    }
    private void Update()
    {
        
    }
}
