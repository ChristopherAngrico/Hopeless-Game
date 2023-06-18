using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private CanvasGroup UI;
    private bool fadeIn, fadeOut;
    private void Awake() {
        UI = GetComponentInChildren<CanvasGroup>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            fadeIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            // print("Exit");
            fadeOut = true;
        }
    }

    private void FixedUpdate() {
        if(fadeIn){
            if(UI.alpha < 1){
                UI.alpha += Time.fixedDeltaTime * 6;
            }
            if(UI.alpha >= 1){
                fadeIn = false; 
            }
        }
        if(fadeOut){
            if(UI.alpha >= 0){
                UI.alpha -= Time.fixedDeltaTime * 6;
                // print(UI.alpha);
            }
            if(UI.alpha == 0){
                fadeOut = false;
            }
        }
    }
}
