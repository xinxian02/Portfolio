using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;

public class Follow : MonoBehaviour
{
    LeapProvider provider;
    const float deltaCloseFinger = 0.06f;

    // 路径脚本
    [SerializeField]
    private WaypointCircuit circuit;

    //移动距离
    private float dis;
    //移动速度
    private float speed;
    // Use this for initialization
    void Start()
    {
        
        dis = 0;
        speed = 10;
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    // Update is called once per frame
    void Update()
    {
        
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {

            if (isCloseHand(hand))
            {

                //计算距离
                dis += Time.deltaTime * speed;
                //获取相应距离在路径上的位置坐标
                transform.position = circuit.GetRoutePoint(dis).position;
                //获取相应距离在路径上的方向
                transform.rotation = Quaternion.LookRotation(circuit.GetRoutePoint(dis).direction);

               

            }
            /*if (hand.IsRight)
            {
                Vector3 HelicopterModel = (Vector3.left * moveSpeed + Vector3.back * moveSpeed);
                if (HelicopterModel != Vector3.zero)
                {
                    transform.Translate(HelicopterModel * moveSpeed * Time.deltaTime, Space.World);
                }
                transform.position = Vector3.MoveTowards(start1.position, end1.position, moveSpeed * Time.deltaTime);
            }*/

            /*if (hand.IsLeft)
            {

                transform.position = hand.PalmPosition.ToVector3() +

                                     hand.PalmNormal.ToVector3() *

                                    (transform.localScale.y * .5f + .02f);

                transform.rotation = hand.Basis.CalculateRotation();
                 Vector3 HelicopterModel = (Vector3.right * moveSpeed + Vector3.forward * moveSpeed);
                 if (HelicopterModel != Vector3.zero)
                 {
                     transform.Translate(HelicopterModel * moveSpeed * Time.deltaTime, Space.World);
                 }
                transform.position = Vector3.MoveTowards(start1.position, end1.position, moveSpeed * Time.deltaTime);

            }*/

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
