using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{   
    public static Shake instance;
    private bool startShake;
    private void Awake(){
        if(instance == null)
            instance = this;
    }
    [SerializeField]private float desiredRange;
    public void TriggerShake(){
        StartCoroutine(nameof(ShakeSpike));
    }
    private void FixedUpdate() {
        if(startShake)
        {
            Vector3 shaking = transform.position;
            shaking.x = shaking.x + Random.Range(-desiredRange,desiredRange) * Time.deltaTime;
            transform.position = shaking;
        }
    }
    IEnumerator ShakeSpike(){
        //after shake is finished place it to original position
        Vector3 originalPosition = transform.position;
        startShake = true;
        yield return new WaitForSeconds(0.5f);
        startShake = false;
        transform.position = originalPosition;
    }
}
