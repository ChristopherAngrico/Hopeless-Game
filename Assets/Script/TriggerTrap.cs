using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    private GameObject[] traps;
    private void Start(){
        if(traps == null)
            traps = GameObject.FindGameObjectsWithTag("Spike");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach(GameObject trap in traps){
                Shake shakeComponent = trap.GetComponent<Shake>();
                if(shakeComponent != null){
                    shakeComponent.TriggerShake();
                }
            }
        }
    }
}
