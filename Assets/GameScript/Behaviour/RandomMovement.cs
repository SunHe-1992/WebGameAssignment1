using System.Collections;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private enum State
    {
        Moving,
        Waiting
    }

    private State currentState;
    private Vector3 targetPosition;
    private float moveSpeed = 2.0f; // Speed at which the object moves
    private float waitTime;

    void Start()
    {
        SetNewTarget();
        currentState = State.Moving;
        StartCoroutine(StateMachine());
    }

    void Update()
    {
        if (currentState == State.Moving)
        {
            MoveToTarget();
        }
    }

    private IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case State.Moving:
                    if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                    {
                        currentState = State.Waiting;
                        waitTime = Random.Range(1f, 10f); // Random wait time between 1 and 9 seconds
                        yield return new WaitForSeconds(waitTime);
                        SetNewTarget();
                        currentState = State.Moving;
                    }
                    break;
                case State.Waiting:
                    // Transition immediately out of wait is handled above
                    yield break;
            }
            yield return null;
        }
    }

    private void MoveToTarget()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void SetNewTarget()
    {
        // Set target position to a random point around the current position within a radius of 5 units
        targetPosition = transform.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
    }
}
