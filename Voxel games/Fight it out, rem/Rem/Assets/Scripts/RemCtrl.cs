using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemCtrl : MonoBehaviour
{

    public float speed = 6;
    public float rotSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //Movement(horizontal, vertical);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
    }

    //private void Movement(float horizontal, float vertical)
    //{
    //    horizontal *= speed * Time.deltaTime;
    //    vertical *= speed * Time.deltaTime;

    //    //判断物体的屏幕坐标
    //    //世界坐标转换为屏幕坐标
    //    Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);

    //    //限制物体在屏幕中的运动：

    //    //1. 如果超过屏幕，停止运动
    //    //if (screenPoint.x >= Screen.width && horizontal > 0 || screenPoint.x <= 0 && horizontal < 0)
    //    //{
    //    //    horizontal = 0;
    //    //}


    //    //2. 左出右进，右出左进；上出下进，下出上进
    //    if (screenPoint.x > Screen.width)
    //    {
    //        screenPoint.x = 0;
    //    }
    //    else if (screenPoint.x < 0)
    //    {
    //        screenPoint.x = Screen.width;
    //    }

    //    if (screenPoint.y > Screen.height)
    //    {
    //        screenPoint.y = 0;
    //    }
    //    else if (screenPoint.y < 0)
    //    {
    //        screenPoint.y = Screen.height;
    //    }

    //    this.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

    //    this.transform.Translate(horizontal, 0, vertical);
    //}
}
