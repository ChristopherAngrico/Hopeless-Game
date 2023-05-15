using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
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
        SceneManager.LoadScene();
    }

    public void ResetGame(Vector3 checkPoint){
        player.transform.position = checkPoint;
    }
}
