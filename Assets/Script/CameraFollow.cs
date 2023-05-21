using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private Vector3 offset = new Vector3(0,0, -10);
    private bool collideLeftWall;
    private float maximumPosition;
    [SerializeField]private float smoothSpeed;
    private Vector3 targetPosition;
    private void Awake()
    {
        target = GameObject.Find("Character").transform;
        targetPosition = new Vector3(target.position.x, 0, -10f);
    }
    private void FixedUpdate()
    {
        //  targetPosition = target.position + offset;
        targetPosition = new Vector3(target.position.x, 0, -10f);
        // Vector3 startPosition = new Vector3(targetPosition.x, 0f, -10f);
        if (!collideLeftWall)
        {
            Vector3 smoothMove = Vector3.Lerp(transform.position, targetPosition, smoothSpeed ); 
            transform.position = smoothMove;
        }
        if (collideLeftWall && InputSystem.inputSystem.Movement() == 1)
        {
            maximumPosition = Mathf.Max(targetPosition.x, transform.position.x);
            transform.position = new Vector3(maximumPosition, targetPosition.y, targetPosition.z);
            if(targetPosition.x == maximumPosition){
                collideLeftWall = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WallLeftSide") || other.gameObject.CompareTag("WallLeftSide") && InputSystem.inputSystem.Movement() == -1)
        {
            collideLeftWall = true;
        }
    }
}
