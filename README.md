# Hopeless

<img src="https://github.com/ChristopherAngrico/Hopeless-Game/blob/main/Assets/Hopless-min.gif?raw=true" height="70%" width="70%">

## Description
A game set in a dark environment with challenging-to-see obstacles that can frustrate players.

## Game Mechanic
<p>CheckPoint<p/><br/>
<img src="https://github.com/ChristopherAngrico/Hopeless-Game/blob/main/AllPhoto/CheckPoint.png" height="30%" width="30%">
  
```C#
  private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            fadeIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            // print("Exit");
            fadeOut = true;
        }
    }

    private void FixedUpdate() {
        if(fadeIn){
            if(UI.alpha < 1){
                UI.alpha += Time.fixedDeltaTime * 6;
            }
            if(UI.alpha >= 1){
                fadeIn = false; 
            }
        }
        if(fadeOut){
            if(UI.alpha >= 0){
                UI.alpha -= Time.fixedDeltaTime * 6;
                // print(UI.alpha);
            }
            if(UI.alpha == 0){
                fadeOut = false;
            }
        }
    }
```

<p>Movement<p/><br/>
<img src="https://github.com/ChristopherAngrico/Hopeless-Game/assets/87889745/7e33abf1-f6c2-4ca2-9264-99b138fb9920" height="30%" width="30%">

```c#
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
```

<p>Jump<p/><br/>
<img src="https://github.com/ChristopherAngrico/Hopeless-Game/assets/87889745/7ec1d02b-25a6-49d2-9e89-24cc78910a03" height="30%" width="30%">

```c#
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
```

<p>Choose difficulty in main menu<p/><br/>
<img src="https://github.com/ChristopherAngrico/Hopeless-Game/blob/main/AllPhoto/MainMenu.png" height="30%" width="30%">

<p>Obstacle<p/><br/>
<img src="https://github.com/ChristopherAngrico/Hopeless-Game/assets/87889745/fb6e7510-35f6-40e5-978c-fe7b4b1f4ea7" height="30%" width="30%">
  
```c#
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !checkedTriggered)
        {
            StartCoroutine(nameof(FallingRock));
            checkedTriggered = true;
        }
    }

    private IEnumerator FallingRock()
    {
        foreach (GameObject trap in traps)
        {
            trap.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject trap in traps)
        {
            Destroy(trap);
        }
    }
```

## Game controls

The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| A,D           | Standart Movement |
| Space           | Jump |

### Script

This game operates on a series of scripts..

| Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `Arrow` | deploy arrow. |
| `BackgroundScrolling`  | Create parralax background. |
| `ChangeScene`  | Change to another scene. |
| `Bridge`  | interactive bridge.  |
| `CameraFollow`  | Camera follow player position.  |
| `CharacterController`  | Control player movement, and jump.  |
| `Falling ground`  | After player stand in top of the ground certain time will fall and destroy. |
| `Game manager`  | Control load level, reset game, and checkpoint. |
| `Input System`  | Handle all input |
| `Moving Ground`  | Handle moving ground |
| `Music Loop`  | handle music loop |
| `Moving Obstacle`  | Handle moving obstacle |
| `Shake`  | Shake obstacle |
| `Shoot arrow`  | TriggerArrow |
| `Swing`  | Handle swing obstacle |
| `TopRock`  | Upside rock will be fall if getting trigger |

