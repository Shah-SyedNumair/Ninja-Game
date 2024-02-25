using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Isuck : MonoBehaviour
{

    [SerializeField]
    KeyCode keyrestart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyrestart))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
