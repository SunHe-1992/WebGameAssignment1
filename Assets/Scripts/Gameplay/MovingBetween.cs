using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBetween : MonoBehaviour
{
    //moving obj moves between the transforms.
    public List<Transform> transList = new List<Transform>();
    public Transform movingObj;
    public float moveSpeed = 1f;
    private Transform curTargetTrans;
    int curIndex = -1;
    private void Awake()
    {
        FindNextTargetTrans();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.running == false) return;

        float dist = Vector3.Distance(movingObj.position, curTargetTrans.position);
        if (moveSpeed * Time.deltaTime > dist)
        {
            movingObj.position = curTargetTrans.position;
        }
        else
        {
            Vector3 moveVect = (curTargetTrans.position - movingObj.position).normalized;
            Vector3 delatMove = moveVect * moveSpeed * Time.deltaTime;
            movingObj.position += moveVect * moveSpeed * Time.deltaTime;
        }
        if (CloseToTarget())
        {
            FindNextTargetTrans();
        }
    }
    bool CloseToTarget()
    {
        float dist = Vector3.Distance(movingObj.position, curTargetTrans.position);
        return dist < 0.05f;
    }

    void FindNextTargetTrans()
    {
        curIndex++;
        if (curIndex >= transList.Count)
        {
            curIndex = 0;
        }
        curTargetTrans = transList[curIndex];
    }
}
