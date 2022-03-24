using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volume;
    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("SaveVolume", 0);
        Time.timeScale = 1f;
    }
    public void MusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("SaveVolume", volume);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
