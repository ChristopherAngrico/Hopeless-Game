using UnityEngine;
// using UnityStandardAssets.CrossPlatformInput;


public class CharacterController : MonoBehaviour
{   
    private Rigidbody2D rb;
    private float speed = 5f;
    [SerializeField] private float groundLength;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField]private bool onGround;
    private void Update() {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove(){
        float calculation = InputSystem.inputSystem.Movement() * speed;
        rb.velocity = new Vector2(calculation, rb.velocity.y);
    }

    private void PlayerJump(){
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        print(onGround);
        if(onGround){
            
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.position + (groundLength * Vector3.down));
    }
}
