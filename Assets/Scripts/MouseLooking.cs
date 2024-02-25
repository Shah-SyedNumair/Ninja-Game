using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{

    public float mouseSens = 500f;

    float xRotate = 0f;

    public Transform playerBody;

/*    public float speed = 100f;
    public float maxAngle = 20f;

    float curAngle = 0f;

    public bool lean = false;
    public bool nolean = true;*/

    // Start is called before the first frame update

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
      //  if (playerBody == null && transform.parent != null) playerBody = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

 /*       // lean left
        if (Input.GetKey(KeyCode.Q))
        {
            curAngle = Mathf.MoveTowardsAngle(curAngle, maxAngle, speed * Time.deltaTime);
            lean = true;
            nolean = false;
        }
        // lean right
        else if (Input.GetKey(KeyCode.E))
        {
            curAngle = Mathf.MoveTowardsAngle(curAngle, -maxAngle, speed * Time.deltaTime);
            lean = true;
            nolean = false;
        }
        // reset lean
        else
        {
            curAngle = Mathf.MoveTowardsAngle(curAngle, 0f, speed * Time.deltaTime);
            nolean = true;
        }

        if (lean)
        {
            playerBody.transform.localRotation = Quaternion.AngleAxis(curAngle, Vector3.forward);
            if (nolean)
            {
                lean = false;
            }
        }*/

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
