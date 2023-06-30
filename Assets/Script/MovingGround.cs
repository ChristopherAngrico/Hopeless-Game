using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;
    public GameObject ways;
    public GameObject player;
    public Transform[] wayPoints;
    int pointIndex, pointCount, direction = 1;
    bool movePlayer;
    private void Awake()
    {
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }
    private void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    private void FixedUpdate()
    {
        var step = speed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if (transform.position == targetPos)
        {
            NextPoint();
        }
        if (movePlayer)
        {
            Vector3 followMovingGround = new Vector3(transform.position.x, 0, 0);
            player.transform.position += followMovingGround;
        }
    }

    private void NextPoint()
    {
        if (pointIndex == pointCount - 1)  //Arrivied last point
        {
            direction = -1;
        }
        if (pointIndex == 0)
        {
            direction = 1;
        }
        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            movePlayer = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            movePlayer = false;
        }
    }
}
