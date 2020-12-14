using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    private Canvas mytoggle;

    void Start ()
    {
        mytoggle = GetComponent<Canvas>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            mytoggle.enabled = !mytoggle.enabled;
        }
    }
}
