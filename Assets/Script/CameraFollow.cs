using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    // private Vector3 offset = new Vector3(0, 0f, -10);
    private Vector3 targetPosition;
    private bool collideLeftWall;
    private float maximumPosition;
    private void Awake()
    {
        target = GameObject.Find("Character").transform;
        targetPosition = new Vector3(target.position.x, 0f, -10f);
    }
    private void LateUpdate()
    {
        if (!collideLeftWall)
        {
            //Store current possiont to fixed y and z position
            targetPosition = new Vector3(target.position.x, 0f, -10f);
            transform.position = targetPosition;

        }
        if (collideLeftWall && InputSystem.inputSystem.Movement() == 1)
        {
            targetPosition = new Vector3(target.position.x, 0f, -10f);
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
