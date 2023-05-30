using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    private void Update()
    {
        RaycastHit2D touchGround = Physics2D.BoxCast(transform.position, GetComponent<SpriteRenderer>().bounds.size, 0f, Vector2.down,0.1f, groundLayer);
        if (touchGround)
        {
            Destroy(gameObject);
        }

    }
}
