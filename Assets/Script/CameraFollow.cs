using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private Vector3 offset = new Vector3(0, 0, -10);
    private bool collideLeftWall, collideRightWall;
    private float maximumPosition, minimumPosition;
    [SerializeField] private float smoothSpeed;
    private Vector3 targetPosition;
    private void Awake()
    {
        target = GameObject.Find("Character").transform;
    }
    private void Start()
    {
        //Make sure that camera position is stay at original position
        if (!GameManager.instance.changeScene)
        {
            targetPosition = new Vector3(GameManager.instance.checkpointPosition.x, 0, -10f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WallLeftSide"))
        {
            collideLeftWall = true;
        }
        if (other.gameObject.CompareTag("WallRightSide"))
        {
            collideRightWall = true;
        }
    }
    private void FixedUpdate()
    {
        targetPosition = new Vector3(target.position.x, 0, -10f);

        if (!collideLeftWall && !collideRightWall)
        {
            Vector3 smoothMove = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothMove;
        }
        if (collideLeftWall && InputSystem.inputSystem.Movement() > 0)
        {
            maximumPosition = Mathf.Max(targetPosition.x, transform.position.x);
            transform.position = new Vector3(maximumPosition, targetPosition.y, targetPosition.z);
            if (targetPosition.x == maximumPosition)
            {
                collideLeftWall = false;
            }
        }
        if (collideRightWall && InputSystem.inputSystem.Movement() < 0)
        {
            minimumPosition = Mathf.Min(targetPosition.x, transform.position.x);
            transform.position = new Vector3(minimumPosition, targetPosition.y, targetPosition.z);
            if (targetPosition.x == minimumPosition)
            {
                collideRightWall = false;
            }
        }
    }

}
