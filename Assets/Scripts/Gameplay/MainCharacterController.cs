using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    public Camera mainCam;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotate();
        ProcessMove();
    }

    public float addForceSpeed = 400f;

    #region move by axis
    void ProcessMove()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        if (isAxisSmall(axisV) && isAxisSmall(axisH))
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            var camForward = mainCam.transform.forward;
            Vector3 cameraForward = camForward;
            cameraForward.y = 0f;
            cameraForward = cameraForward.normalized;
            Vector3 vectForward = axisV * cameraForward * Time.deltaTime;

            Vector3 cameraRight = mainCam.transform.right.normalized;
            Vector3 vectRight = axisH * cameraRight * Time.deltaTime;

            rb.AddForce(addForceSpeed * (vectForward + vectRight));
        }
    }
    bool isAxisSmall(float value)
    {
        return Mathf.Abs(value) < 0.05f;
    }
    #endregion

    #region rotate by mouse
    bool holdingMouseR = false;

    private Vector3 rotationSpeed;
    public float sensivity = 1;
    void ProcessRotate()
    {
        if (Input.GetMouseButtonUp(1))
        {
            //transform.Rotate(Vector3.zero * Time.deltaTime);

        }
        else if (Input.GetMouseButton(1))
        {
            float y = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
            rotationSpeed.y = y;
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
    #endregion
}