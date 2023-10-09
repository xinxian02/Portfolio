using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine.EventSystems;

public class LeapBehavoir3 : Joystick
{


    LeapProvider provider;
    public float moveSpeed = 20f;
    public Transform start;
    public Transform end;
    public Transform start1;
    public Transform end1;
    float tempX = 0f;
    float tempY = 0f;
    const float deltaCloseFinger = 0.06f;
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }
    void Update()
    {

        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {


            if (hand.IsRight)
            {

                Vector2 HelicopterModel = (Vector2.right * moveSpeed);
                if (HelicopterModel != Vector2.zero)
                {
                    transform.Translate(HelicopterModel * moveSpeed * Time.deltaTime, Space.World);
                   
                }
               // transform.position = Vector3.MoveTowards(start1.position, end1.position, moveSpeed * Time.deltaTime);
            }

            if (hand.IsLeft)
            {

                //transform.position = hand.PalmPosition.ToVector3() +

                //                     hand.PalmNormal.ToVector3() *

                //                    (transform.localScale.y * .5f + .02f);

                //transform.rotation = hand.Basis.CalculateRotation();
                /*Vector2 HelicopterModel = (Vector2.left * moveSpeed);
                if (HelicopterModel != Vector2.zero)
                {
                    transform.Translate(HelicopterModel * moveSpeed * Time.deltaTime, Space.World);
                }*/
                //transform.position = Vector3.MoveTowards(start1.position, end1.position, moveSpeed * Time.deltaTime);

            }

        }

    }
}
