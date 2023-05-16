using UnityEngine;
// using UnityStandardAssets.CrossPlatformInput;


public class CharacterController : MonoBehaviour
{
    //Jump attribute
    private Rigidbody2D rb;
    private float speed = 5f;
    [SerializeField] private float groundLength;
    [SerializeField] private LayerMask groundLayer;

    //Die attribute
    private bool playerDie;
    private void Start()
    {
        GameManager.instance.checkpointPosition = transform.position;
    }
    private void Update()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float calculation = InputSystem.inputSystem.Movement() * speed;
        rb.velocity = new Vector2(calculation, rb.velocity.y);
    }

    private void PlayerJump()
    {
        RaycastHit2D onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        float jumpForce = 10f;

        if (onGround && InputSystem.inputSystem.JumpPress())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //Smoothing falling player
        if (rb.velocity.y < 0)
        {
            rb.velocity += Physics2D.gravity * Time.deltaTime * 0.6f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            playerDie = true;
        }
    }
    private void FixedUpdate()
    {
        if (playerDie)
        {
            gameObject.SetActive(false);
            Invoke(nameof(ResetGame), 2f);
        }
    }

    private void ResetGame()
    {
        playerDie = false;
        GameManager.instance.ResetGame();
        gameObject.SetActive(true);

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.position + (groundLength * Vector3.down));
    }
}
