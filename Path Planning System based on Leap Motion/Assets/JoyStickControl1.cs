using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControl1 : MonoBehaviour {

    public Joystick joystick;
    public float moveSpeed = 100f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 HelicopterModel = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
        if (HelicopterModel != Vector3.zero)
        {
            transform.Translate(HelicopterModel * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
