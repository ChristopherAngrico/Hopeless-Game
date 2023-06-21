using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(nameof(Fall));
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody2D>().isKinematic = false;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
