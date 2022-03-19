using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    [SerializeField] private int health = 30;
    [SerializeField] private Text healthText;
    private void Start()
    {
        ChangeHealth();
    }
    private void TakeDamage()
    {
        health--;
        ChangeHealth();

        if (health == 0)
            Death();
    }
    private void ChangeHealth()
    {
        healthText.text = health.ToString();
    }
    private void Death()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
            TakeDamage();
    }
}
