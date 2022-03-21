using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBricks : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    [SerializeField] private GameObject ballIncreaser;
    private const int NUMBER_BRICKS = 8;
    private Vector2 defaultSpawn = new Vector2(0, 4);
    private Vector2[] spawnPoints = {new Vector2(-2.45f,3), new Vector2(-1.75f,3),
                                    new Vector2(-1.05f,3), new Vector2(-0.35f,3),
                                    new Vector2(0.35f,3), new Vector2(1.05f,3),
                                    new Vector2(1.75f,3), new Vector2(2.45f,3)};
    private List<GameObject> bricksList = new List<GameObject>(NUMBER_BRICKS);
    private GameObject newBrick;
    private GameObject line;
    private void Start()
    {
        SpawnBrick();
    }
    public void SpawnBrick()
    {
        CreateLine();
        RandomBrickLine();
        for (int i = 0; i < NUMBER_BRICKS; i++)
        {
            if (bricksList[i] != null)
            {
                newBrick = Instantiate(bricksList[i], spawnPoints[i], Quaternion.identity) as GameObject;
                newBrick.transform.SetParent(line.transform);
            }
        }
        bricksList.Clear();
    }
    private void CreateLine()
    {
        line = new GameObject("Line");
        line.AddComponent<BricksDrop>();
    }
    private void RandomBrickLine()
    {
        for (int i = 0; i <= NUMBER_BRICKS; i++)
        {
            int change = Random.Range(0, 101);
            if (change < 51)
                bricksList.Add(brick);
            else if (change > 50 && change < 76)
                bricksList.Add(null);
            else if (change > 75 && change < 101)
                bricksList.Add(ballIncreaser);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomBrickLine();
            SpawnBrick();
        }
    }
}
