using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine.EventSystems;
public class LeapBehavior : MonoBehaviour
{
    LeapProvider provider;
    public float moveSpeed = 100f;
    public Transform start;
    public Transform end;
    public Transform start1;
    public Transform end1;
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

            if (isCloseHand(hand))
            {

                //transform.position = hand.PalmPosition.ToVector3() +

                //                     hand.PalmNormal.ToVector3() *

                //                    (transform.localScale.y * .5f + .02f);

                //transform.rotation = hand.Basis.CalculateRotation();
               /* Vector3 HelicopterModel = (Vector3.right * moveSpeed + Vector3.forward * moveSpeed);
                if (HelicopterModel != Vector3.zero)
                {
                    transform.Translate(HelicopterModel * moveSpeed * Time.deltaTime, Space.World);
                }*/
                Debug.Log("小");
                transform.position = Vector3.MoveTowards(start.position, end.position, moveSpeed * Time.deltaTime);
 
            }
            if (hand.IsRight)
            {
                Vector3 HelicopterModel = (Vector3.left * moveSpeed + Vector3.back * moveSpeed);
                if (HelicopterModel != Vector3.zero)
                {
                    transform.Translate(HelicopterModel * moveSpeed * Time.deltaTime, Space.World);
                }
                //transform.position = Vector3.MoveTowards(start1.position, end1.position, moveSpeed * Time.deltaTime);
            }

            if (hand.IsLeft)
            {

                //transform.position = hand.PalmPosition.ToVector3() +

                //                     hand.PalmNormal.ToVector3() *

                //                    (transform.localScale.y * .5f + .02f);

                //transform.rotation = hand.Basis.CalculateRotation();
                /* Vector3 HelicopterModel = (Vector3.right * moveSpeed + Vector3.forward * moveSpeed);
                 if (HelicopterModel != Vector3.zero)
                 {
                     transform.Translate(HelicopterModel * moveSpeed * Time.deltaTime, Space.World);
                 }*/
                //transform.position = Vector3.MoveTowards(start1.position, end1.position, moveSpeed * Time.deltaTime);

            }

        }

    }

     protected bool isCloseHand(Hand hand)     //是否握拳 
    {
        List<Finger> listOfFingers = hand.Fingers;
        int count = 0;
        for (int f = 0; f < listOfFingers.Count; f++)
        { //循环遍历所有的手~~
            Finger finger = listOfFingers[f];
            if ((finger.TipPosition - hand.PalmPosition).Magnitude < deltaCloseFinger)    // Magnitude  向量的长度 。是(x*x+y*y+z*z)的平方根。    //float deltaCloseFinger = 0.05f;
            {
                count++;
              //  if (finger.Type == Finger.FingerType.TYPE_THUMB)
              //  Debug.Log ((finger.TipPosition - hand.PalmPosition).Magnitude);
            }
        }
        return (count == 5);
    }
 

     
 

}