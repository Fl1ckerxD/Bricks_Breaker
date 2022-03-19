using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    public void StopJumping()
    {
        rig.simulated = false;
    }
}
