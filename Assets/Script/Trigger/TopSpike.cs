using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EasyGame
{
    public class TopSpike : MonoBehaviour
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
                StartCoroutine(nameof(FallingSpike));
                checkedTriggered = true;
            }
        }

        private IEnumerator FallingSpike()
        {
            foreach (GameObject trap in traps)
            {
                trap.GetComponent<Rigidbody2D>().isKinematic = false;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}