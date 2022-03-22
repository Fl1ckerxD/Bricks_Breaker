using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameScene : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private void Start() 
    {
        Time.timeScale = 1f;
    }
    public void ReturnBalls()
    {
        FindObjectOfType<BallSpawner>().StopShooting();
        var balls = FindObjectsOfType<Ball>();
        for (int i = 0; i < balls.Length; i++)
            balls[i].MoveBallTo();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void PlayButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
