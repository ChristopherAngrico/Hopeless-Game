using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    private GameObject[] traps;
    public LayerMask groundLayer;
    private void Start()
    {
        if (traps == null)
            traps = GameObject.FindGameObjectsWithTag("TopSpike");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(nameof(FallingSpike));
        }
    }

    private IEnumerator FallingSpike()
    {
        foreach (GameObject trap in traps)
        {
            Shake shakeComponent = trap.GetComponent<Shake>();
            if (shakeComponent != null)
            {
                shakeComponent.TriggerShake();
            }
        }
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject trap in traps)
        {
            trap.GetComponent<Rigidbody2D>().isKinematic = false;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
