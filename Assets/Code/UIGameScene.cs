using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIGameScene : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volume;
    [SerializeField] private GameObject pauseMenu;
     [SerializeField] private GameObject FailPanel;
    private void Start() 
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void MusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("SaveVolume", volume);
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
    public void ShowFailPanel()
    {
        FailPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
