using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    [HideInInspector]public Vector3 checkpointPosition;
    public static GameManager instance;
    private void Awake() {
        if(instance != null)
            DestroyImmediate(gameObject);
        else{
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        player = GameObject.Find("Character");
    }

    private void LoadScene(){
        SceneManager.LoadScene("GameScene");
    }

    public void ResetGame(){
        player.transform.position = checkpointPosition;
        // LoadScene();
    }
}
