using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject player;
    [HideInInspector]public Vector3 checkpointPosition;
    public bool triggerCheckPoint;
    private void Awake() {
        if(instance != null)
            DestroyImmediate(gameObject);
        else{
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        player = GameObject.Find("Character");
        checkpointPosition = player.transform.position;
    }

    private void LoadScene(){
        SceneManager.LoadScene("EasyMode");
    }

    public void ResetGame(){
        LoadScene();
        // player.transform.position = checkpointPosition;
        // triggerCheckPoint = true;
    }
}
