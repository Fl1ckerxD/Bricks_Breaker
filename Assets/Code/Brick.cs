using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    [SerializeField] private int health;
    private static int defaultHealth = 1;
    [SerializeField] private Text healthText;
    private void Start()
    {
        health = defaultHealth;
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
    public static void IncreaseHealth(int value)
    {
        defaultHealth += value;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
            TakeDamage();
    }
}
