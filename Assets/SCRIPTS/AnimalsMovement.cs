using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Animator))]
public class AnimalsMovement : MonoBehaviour
{
    [SerializeField] private  Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private int currentWaypoint = 0; 
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MoveToWaypoint()); 
    }

    private IEnumerator MoveToWaypoint()
    {
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

        while (currentWaypoint < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypoint].position; 

            while (transform.position != targetPosition)
            {
                transform.LookAt(targetPosition);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
                yield return null;
            }

            animator.SetTrigger("Eat");

            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }
}
