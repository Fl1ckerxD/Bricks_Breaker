using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 newPosition;
    private Rigidbody2D rig;
    private BallSpawner ballSpawner;
    private SpawnerBricks spawnerBricks;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ballSpawner = FindObjectOfType<BallSpawner>();
        spawnerBricks = FindObjectOfType<SpawnerBricks>();
    }
    public void StopJumping()
    {
        rig.simulated = false;

        if (ballSpawner.ballList[0] == gameObject)
        {
            newPosition = new Vector2(transform.position.x, ballSpawnerPosition.y);
            ballSpawner.gameObject.transform.position = newPosition;
            ballSpawner.ShowSpawner();
        }

        DeleteBall();
    }
    private void DeleteBall()
    {
        ballSpawner.ballList.Remove(gameObject);
        Destroy(gameObject);
        if (ballSpawner.ballList.Count == 0)
        {
            FindAndDrop();
            spawnerBricks.SpawnBrick();
        }

    }
    private void FindAndDrop()
    {
        var bricksDrops = FindObjectsOfType<BricksDrop>();
        for (int i = 0; i < bricksDrops.Length; i++)
            bricksDrops[i].Drop();
    }
    private Vector2 ballSpawnerPosition => ballSpawner.gameObject.transform.position;
}
