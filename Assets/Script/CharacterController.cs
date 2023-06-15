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
    private float groundLength = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    //Die
    private bool playerDie;
    private void Start() {
        transform.position = GameManager.instance.checkpointPosition;
    }
    private void Update()
    {
        // print(transform.position);
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float calculation = 0;
        //When player collide wall will freeze playermovement
        if (collideLeftWall && InputSystem.inputSystem.Movement() < 0)
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
        RaycastHit2D onGround = Physics2D.BoxCast(transform.position, GetComponent<SpriteRenderer>().bounds.size, 0f, Vector2.down, groundLength, groundLayer);
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
        if (other.gameObject.CompareTag("TopSpike") || other.gameObject.CompareTag("BotSpike") || other.gameObject.CompareTag("TopObstacle") || other.gameObject.CompareTag("Arrow"))
            playerDie = true;

        if (other.gameObject.CompareTag("WallLeftSide"))
            collideLeftWall = true;
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            
            Vector3 checkPointPosition = new Vector3(other.transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.checkpointPosition = checkPointPosition;
            // print(GameManager.instance.checkpointPosition);
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
        gameObject.SetActive(true);
        GameManager.instance.ResetGame();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    }
}
