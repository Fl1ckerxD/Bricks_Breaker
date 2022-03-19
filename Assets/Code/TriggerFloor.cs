using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFloor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<Ball>().StopJumping();
        }
    }
}
