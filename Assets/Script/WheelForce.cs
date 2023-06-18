using UnityEngine;

public class WheelForce : MonoBehaviour
{
    private float groundLength = 0.01f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private float speed = -3f;
    public bool hitGround;
    private float circleRadius = 1.355f;
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        hitGround = Physics2D.CircleCast(transform.position, circleRadius, Vector2.down, groundLength, groundLayer);
        if(hitGround){
            rb.AddForce(new Vector2(speed, rb.velocity.y));
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.position + groundLength * Vector3.down);
    }
}
