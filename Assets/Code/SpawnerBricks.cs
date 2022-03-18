using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBricks : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    private Vector2 defaultSpawn = new Vector2(0, 4); 
    public void SpawnBrick()
    {
        Instantiate(brick, defaultSpawn, Quaternion.identity);
    }
}
