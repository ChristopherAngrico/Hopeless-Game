using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fading : MonoBehaviour
{
    public CanvasGroup fadingThxText, fadingCreateByText;
    bool fadeInThx, fadeOutThx, fadeInCreate, fadeOutCreate;
    private void Start()
    {
        fadeInThx = true;
        StartCoroutine(nameof(FadingText));
    }
    IEnumerator FadingText()
    {
        if (fadeInThx)
        {
            while (fadeInThx)
            {
                if (fadingThxText.alpha < 1)
                    fadingThxText.alpha += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
                if (fadingThxText.alpha >= 1)
                {
                    fadeInThx = false;
                    fadeOutThx = true;
                }
            }
        }
        if (fadeOutThx)
        {
            if (fadingThxText.alpha >= 0)
                fadingThxText.alpha -= Time.fixedDeltaTime;
            if (fadingThxText.alpha == 0)
                fadeOutThx = false;
        }
        yield return null;
    }

    // private void FixedUpdate()
    // {
    //     FadingThx();
    //     Invoke(nameof(FadingCreate),10f);
    // }
    // void FadingThx(){
    //     if (fadeInThx)
    //     {
    //         if (fadingThxText.alpha < 1)
    //             fadingThxText.alpha += Time.fixedDeltaTime;
    //         if (fadingThxText.alpha >= 1){
    //             fadeInThx = false;
    //             fadeOutThx = true;
    //         }
    //     }
    //     if (fadeOutThx)
    //     {
    //         if (fadingThxText.alpha >= 0)
    //             fadingThxText.alpha -= Time.fixedDeltaTime;
    //         if (fadingThxText.alpha == 0)
    //             fadeOutThx = false;
    //     }
    // }
    // void FadingCreate(){
    //     if (fadeInCreate)
    //     {
    //         if (fadingCreateByText.alpha < 1)
    //             fadingCreateByText.alpha += Time.fixedDeltaTime;
    //         if (fadingCreateByText.alpha >= 1)
    //             fadeInCreate = false;
    //     }
    //     if (fadeOutCreate)
    //     {
    //         if (fadingCreateByText.alpha < 1)
    //             fadingCreateByText.alpha += Time.fixedDeltaTime;
    //         if (fadingCreateByText.alpha >= 1)
    //             fadeInThx = false;
    //     }
    //     Invoke(nameof(ChangeMenuScene),5f);
    // }
    // void ChangeMenuScene(){
    //     SceneManager.LoadScene("MenuScene");
    // }
}
