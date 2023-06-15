using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    float startPoint;
    public float endpoint; //endpoint of move
    Vector3 desiredDestination;
    float current;
    [SerializeField]float speed = 5f; // Adjust the speed value as needed

    private void Awake()
    {
        startPoint = transform.position.y; //grab move down end point
    }

    private void FixedUpdate()
    {
        current += speed * Time.deltaTime;

        float tolerance = 0.1f; // Adjust the tolerance value as needed

        if (Mathf.Abs(transform.position.y - endpoint) < tolerance)
        {
            desiredDestination = new Vector3(transform.position.x, startPoint, transform.position.z);
        }
        else if (Mathf.Abs(transform.position.y - startPoint) < tolerance)
        {
            desiredDestination = new Vector3(transform.position.x, endpoint, transform.position.z);
        }

        Vector3 movingSpike = Vector3.MoveTowards(transform.position, desiredDestination, speed * Time.deltaTime);
        transform.position = movingSpike;
    }
}

