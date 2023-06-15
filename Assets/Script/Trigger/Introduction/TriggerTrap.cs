using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Introduction
{
    public class TriggerTrap : MonoBehaviour
    {
        private GameObject bucket;
        private bool checkTrigger;
        // public LayerMask groundLayer;
        private void Start()
        {
            if (bucket == null)
            {
                bucket = GameObject.Find("Bucket");
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && !checkTrigger)
            {
                // print("Trigger");
                trap();
                checkTrigger = true;
            }
            
        }

        private void trap()
        {
           bucket.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
