using UnityEngine;
// using UnityStandardAssets.CrossPlatformInput;


public class CharacterController : MonoBehaviour
{
    //Physics
    private Rigidbody2D rb;

    //Movement
    private float speed = 5f;
    private bool collideLeftWall;

    //Jump
    [SerializeField] private float groundLength;
    [SerializeField] private LayerMask groundLayer;

    //Die
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
        float calculation = 0;
        //When player collide wall will freeze playermovement
        if (collideLeftWall && InputSystem.inputSystem.Movement() != -1)
        {
            collideLeftWall = false;
        }
        if (!collideLeftWall)
        {
            calculation = InputSystem.inputSystem.Movement() * speed;
        }
        rb.velocity = new Vector2(calculation, rb.velocity.y);
    }

    private void PlayerJump()
    {
        RaycastHit2D onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        float jumpForce = 8f;

        if (onGround && InputSystem.inputSystem.JumpPress())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //Smoothing falling player
        if (rb.velocity.y < 0.5)
        {
            rb.velocity += Physics2D.gravity * Time.deltaTime * 0.8f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
            playerDie = true;

        if (other.gameObject.CompareTag("WallLeftSide"))
        {
            print("Wall");
            collideLeftWall = true;
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
