using UnityEngine;
// using UnityStandardAssets.CrossPlatformInput;


public class CharacterController : MonoBehaviour
{
    //Physics
    private Rigidbody2D rb;

    //Movement
    private float speed = 5f;
    private bool collideLeftWall, collideRightWall;

    //Jump
    private float groundLength = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    //Die
    private bool playerDie;

    //Animator
    Animator anim;
    private void Awake()
    {
        //make sure that player position is stay at original position
        if (!GameManager.instance.changeScene)
        {
            // print("Start");
            transform.position = GameManager.instance.checkpointPosition;
        }
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        PlayerMove();
        PlayerJump();
        FlipSprite();
    }

    private void PlayerMove()
    {
        float calculation = 0;
        //player will move if not collide any wall
        if (!collideLeftWall && !collideRightWall)
        {
            calculation = InputSystem.inputSystem.Movement() * speed;
            anim.SetFloat("Walking", Mathf.Abs(calculation));
        }
        //stop the player if collide the left wall
        if (collideLeftWall && InputSystem.inputSystem.Movement() > 0)
        {
            collideLeftWall = false;
        }
        //stop the player if collide the right wall
        if (collideRightWall && InputSystem.inputSystem.Movement() < 0)
        {
            collideRightWall = false;
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
            anim.SetBool("Jumping", true);

        }
        if (onGround && rb.velocity.y < 0.5)
            anim.SetBool("Jumping", false);
        //Smoothing falling player
        if (rb.velocity.y < 0.5)
            rb.velocity += Physics2D.gravity * Time.deltaTime * 0.8f;
            
    
        if (rb.velocity.y > 0)
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), true);
        else
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TopSpike") || other.gameObject.CompareTag("BotSpike") || other.gameObject.CompareTag("TopObstacle") || other.gameObject.CompareTag("Arrow"))
            playerDie = true;

        if (other.gameObject.CompareTag("WallLeftSide"))
            collideLeftWall = true;
        if (other.gameObject.CompareTag("WallRightSide"))
            collideRightWall = true;
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Vector3 checkPointPosition = new Vector3(other.transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.checkpointPosition = checkPointPosition;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.changeScene = true;
            GameManager.instance.LoadLevel();
        }
        if(other.gameObject.CompareTag("MovingGround")){
            transform.position = new Vector3(other.gameObject.transform.position.x, transform.position.y, transform.position.z);
            print("trigger");
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
    private void FlipSprite(){
        if(InputSystem.inputSystem.Movement() < 0){
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(InputSystem.inputSystem.Movement() > 0){
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    }

}
