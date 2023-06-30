using UnityEngine.SceneManagement;
using UnityEngine;

public class UIHandling : MonoBehaviour
{
    public GameObject play, pause;
    public AudioSource musicSource;
    public void Pause()
    {
        Time.timeScale = 0;
        play.SetActive(true);
        pause.SetActive(false);
        musicSource.Pause();
    }

    public void Play()
    {
        Time.timeScale = 1;
        pause.SetActive(true);
        play.SetActive(false);
        musicSource.Play();
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
