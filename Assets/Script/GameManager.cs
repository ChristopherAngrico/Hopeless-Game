using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject player;
    [HideInInspector] public Vector3 checkpointPosition;
    [HideInInspector] public bool changeScene; //After changing scene player and camera stay at originial position
    private void Awake()
    {
        if (instance != null)
            DestroyImmediate(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        player = GameObject.Find("Character");
        checkpointPosition = player.transform.position;
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print(changeScene);
        Invoke(nameof(ChangeScene), 0.01f);
        // ChangeScene();
    }
    void ChangeScene(){
        changeScene = false;
    }
    public void ResetGame()
    {
        LoadScene();
        if (player != null)
        {
            player.transform.position = checkpointPosition;
            // triggerCheckPoint = true;
        }

    }
}
