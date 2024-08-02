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
    private float moveSpeed = 15.0f; // Speed at which the object moves
    private float waitTime;

    void Start()
    {
        ChangeState(State.Moving);
    }

    void Update()
    {
        if (currentState == State.Moving)
        {
            MoveToTarget();
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                ChangeState(State.Waiting);
            }
        }
    }

    private void ChangeState(State newState)
    {
        StopAllCoroutines(); // Ensure no coroutines are running
        currentState = newState;

        switch (newState)
        {
            case State.Moving:
                SetNewTarget();
                break;
            case State.Waiting:
                waitTime = Random.Range(1f, 10f); // Random wait time between 1 and 9 seconds
                StartCoroutine(WaitAndMove(waitTime));
                break;
        }
    }

    private IEnumerator WaitAndMove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ChangeState(State.Moving);
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void SetNewTarget()
    {
        targetPosition = transform.position + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
    }
}
