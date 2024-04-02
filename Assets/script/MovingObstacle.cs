using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float moveDistance = 2f; // Distance to move up and down
    public float moveSpeed = 2f;    // Speed of movement

    private Vector3 startPos;
    private float timer;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate movement based on sine function to achieve smooth up and down motion
        float newY = startPos.y + Mathf.Sin(timer * moveSpeed) * moveDistance;
        timer += Time.deltaTime;

        // Update the position of the obstacle
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
