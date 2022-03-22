using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rig;
    private BallSpawner ballSpawner;
    private SpawnerBricks spawnerBricks;
    private int _speed = 50;
    private static Vector2 _newPosition;
    private Vector2 _defaultPosition = new Vector2(0, -3.48f);
    private static bool _isFirstBall = true;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ballSpawner = FindObjectOfType<BallSpawner>();
        spawnerBricks = FindObjectOfType<SpawnerBricks>();
    }
    public void StopJumping()
    {
        if (_isFirstBall)
        {
            _newPosition = new Vector2(transform.position.x, ballSpawnerPosition.y);
            _isFirstBall = false;
        }
        MoveBallTo(_newPosition);
    }
    private void DeleteBall()
    {
        ballSpawner.ballList.Remove(gameObject);
        if (ballSpawner.ballList.Count == 0)
        {
            FindAndDrop();
            ballSpawner.gameObject.transform.parent.transform.position = _newPosition;
            ballSpawner.ShowSpawner();
            _isFirstBall = true;
        }
        Destroy(gameObject, 0.1f);
    }
    public void MoveBallTo()
    {
        _newPosition = _defaultPosition;
        _isFirstBall = false;
        MoveBallTo(_newPosition);
    }
    private void MoveBallTo(Vector2 target)
    {
        rig.simulated = false;
        DeleteBall();
        transform.position = Vector2.MoveTowards(transform.position, target, Time.fixedTime * _speed);
    }
    private void FindAndDrop()
    {
        var bricksDrops = FindObjectsOfType<BricksDrop>();
        for (int i = 0; i < bricksDrops.Length; i++)
            bricksDrops[i].Drop();

        Brick.IncreaseHealth(1);
        spawnerBricks.SpawnBrick();
    }
    private Vector2 ballSpawnerPosition => ballSpawner.gameObject.transform.position;
}
