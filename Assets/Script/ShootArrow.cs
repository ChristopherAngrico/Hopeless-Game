using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    float speed = 10f;
    private void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }
}
