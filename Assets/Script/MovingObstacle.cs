using UnityEngine;
using System.Collections;

public class MovingObstacle : MonoBehaviour
{
    float startPoint;
    public float endpoint; //endpoint of move
    Vector3 desiredDestination;
    [SerializeField] float speed = 5f; // Adjust the speed value as needed

    private void Awake()
    {
        startPoint = transform.localPosition.y; //grab move down end point
    }

    private void Start()
    {
        StartCoroutine(MoveObstacle());
    }

    IEnumerator MoveObstacle()
    {
        float tolerance = 0.01f; // Adjust the tolerance value as needed

        while (true)
        {
            if (Mathf.Abs(transform.localPosition.y - endpoint) < tolerance)
            {
                desiredDestination = new Vector3(transform.localPosition.x, startPoint, transform.localPosition.z);
                // print(desiredDestination);
            }
            else if (Mathf.Abs(transform.localPosition.y - startPoint) < tolerance)
            {
                desiredDestination = new Vector3(transform.localPosition.x, endpoint, transform.localPosition.z);
                if(!GameObject.Find("Punch"))
                    yield return new WaitForSeconds(2f); // Delay for 2 seconds
            }

            Vector3 movingSpike = Vector3.MoveTowards(transform.localPosition, desiredDestination, speed * Time.deltaTime);
            transform.localPosition = movingSpike;

            yield return null;
        }
    }
}
