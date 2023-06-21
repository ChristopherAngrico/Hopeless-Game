using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRock : MonoBehaviour
{
    private GameObject[] traps;
    private bool checkedTriggered;
    private void Start()
    {
        if (traps == null)
        {
            traps = GameObject.FindGameObjectsWithTag("TopSpike");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !checkedTriggered)
        {
            StartCoroutine(nameof(FallingRock));
            checkedTriggered = true;
        }
    }

    private IEnumerator FallingRock()
    {
        foreach (GameObject trap in traps)
        {
            trap.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject trap in traps)
        {
            Destroy(trap);
        }
    }
}

