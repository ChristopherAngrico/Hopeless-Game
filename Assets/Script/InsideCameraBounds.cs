using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideCameraBounds : CharacterController
{

    private Vector3 screenBound;
    private float objectWidth, objectHeight;
    private Vector3 viewPos;

    private void Awake()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        viewPos = transform.position;
    }
    private void FixedUpdate()
    {
        // print(screenBound);
        Vector2 edgeLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Vector2 edgeRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        viewPos.x = Mathf.Clamp(viewPos.x, edgeLeft.x, edgeRight.x);
        // print(viewPos);
        transform.position = viewPos;
    }
}
