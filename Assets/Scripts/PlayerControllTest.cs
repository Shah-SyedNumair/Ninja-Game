using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllTest : MonoBehaviour
{

    [SerializeField]
    Vector3 v3Force;
    [SerializeField]
    KeyCode Keyplus;
    [SerializeField]
    KeyCode Keyminus;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(Keyplus))
            GetComponent<Rigidbody>().velocity += v3Force;
        if (Input.GetKey(Keyminus))
            GetComponent<Rigidbody>().velocity -= v3Force;
    }
}
