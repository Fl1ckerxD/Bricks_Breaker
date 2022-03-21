using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameScene : MonoBehaviour
{
    public void ReturnBalls()
    {
        FindObjectOfType<BallSpawner>().StopShooting();
        var balls = FindObjectsOfType<Ball>();
        for (int i = 0; i < balls.Length; i++)
            balls[i].MoveBallTo();
    }
}
