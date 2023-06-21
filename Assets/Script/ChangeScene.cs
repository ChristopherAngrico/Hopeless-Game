using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangingScene(int index) {
        SceneManager.LoadScene(index);
    }
}
