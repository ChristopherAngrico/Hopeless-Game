using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    float movingDown;
    public float movingUp; //end point of move up
    Vector3 desiredDestination;
    float current;
    float speed = 5f; // Adjust the speed value as needed

    private void Awake()
    {
        movingDown = transform.position.y; //grab move down end point
    }

    private void FixedUpdate()
    {
        current += speed * Time.deltaTime;

        float tolerance = 0.1f; // Adjust the tolerance value as needed

        if (Mathf.Abs(transform.position.y - movingUp) < tolerance)
        {
            desiredDestination = new Vector3(transform.position.x, movingDown, transform.position.z);
        }
        else if (Mathf.Abs(transform.position.y - movingDown) < tolerance)
        {
            desiredDestination = new Vector3(transform.position.x, movingUp, transform.position.z);
        }

        Vector3 movingSpike = Vector3.MoveTowards(transform.position, desiredDestination, speed * Time.deltaTime);
        transform.position = movingSpike;
    }
}

