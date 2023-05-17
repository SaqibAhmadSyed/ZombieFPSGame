using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float stoppingDistance = 1f; // Distance at which the enemy stops chasing the player


   public float walkingSpeed = 2f; // Speed at which the enemy walks towards the player
public float runningSpeed = 10f; // Speed at which the enemy runs towards the player
public float chasingDistance = 10f; // Distance at which the enemy starts chasing the player
public string playerTag = "Player"; // Tag to identify the player object
public float obstacleAvoidanceRange = 2f; // Distance at which the enemy detects obstacles and navigates around them
public float maxSlopeAngle = 45f; // Maximum slope angle that the enemy can climb

private Transform player; // Reference to the player's transform
private Vector3 targetPosition; // Position to move towards
private bool isGrounded = false; // Flag to indicate whether the enemy is grounded

private void Start()
{
    // Find the player object in the scene using its tag
    player = GameObject.FindGameObjectWithTag(playerTag).transform;
    targetPosition = transform.position; // Set initial target position to current position
}

private void Update()
{
    // Calculate the distance between the enemy and the player
    float distanceToPlayer = Vector3.Distance(transform.position, player.position);
    transform.LookAt(player);
   if (distanceToPlayer > chasingDistance)
{
    // Move the enemy towards the player at walking speed
    targetPosition = player.position;
    targetPosition.y = transform.position.y; // Disable Y-axis movement
    transform.position = Vector3.MoveTowards(transform.position, targetPosition, walkingSpeed * Time.deltaTime);

            transform.GetComponent<Animation>().Play("Walk");
        }
else if (distanceToPlayer > stoppingDistance)
{
    // Move the enemy towards the player at running speed
    targetPosition = player.position;
    targetPosition.y = transform.position.y; // Disable Y-axis movement
    transform.position = Vector3.MoveTowards(transform.position, targetPosition, runningSpeed * Time.deltaTime);

            transform.GetComponent<Animation>().Play("Run");
        }
else
{
    // Stop the enemy's movement
    transform.position = transform.position;
}

    // Check if the enemy is grounded
    RaycastHit hit;
    if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
    {
        float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
        if (slopeAngle <= maxSlopeAngle)
        {
            isGrounded = true;
        }
    }
    else
    {
        isGrounded = false;
    }

    // If the enemy is grounded, check for obstacles in the way and navigate around them
    if (isGrounded)
    {
        RaycastHit obstacleHit;
        if (Physics.Raycast(transform.position, targetPosition - transform.position, out obstacleHit, obstacleAvoidanceRange))
        {
            // If an obstacle is detected, find a new target position to move towards using the normal of the ground
            Vector3 obstacleNormal = obstacleHit.normal;
            obstacleNormal.y = 0f; // Disable Y-axis movement
            targetPosition = obstacleHit.point + obstacleNormal * obstacleAvoidanceRange;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, walkingSpeed * Time.deltaTime);
        }
    }
}

}