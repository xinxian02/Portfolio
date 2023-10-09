using UnityEngine;

using System.Collections.Generic;

using Leap;

using Leap.Unity;

using UnityEngine.EventSystems;

public class BallScript : MonoBehaviour {
    LeapProvider provider;








    void Start()
    {



        provider = FindObjectOfType<LeapProvider>() as LeapProvider;



    }






    void Update()
    {

        Frame frame = provider.CurrentFrame;

        foreach (Hand hand in frame.Hands)
        {

            if (hand.IsLeft)
            {

                //transform.position = hand.PalmPosition.ToVector3() +

                //                     hand.PalmNormal.ToVector3() *

                //                    (transform.localScale.y * .5f + .02f);

                //transform.rotation = hand.Basis.CalculateRotation();
                Vector3 Ball = (Vector3.right * 1 + Vector3.forward * 1);
                if (Ball != Vector3.zero)
                {
                    transform.Translate(Ball * 1 * Time.deltaTime, Space.World);
                }
            }
            if (hand.IsRight)
            {
                Vector3 Ball = (Vector3.left * 1 + Vector3.back * 1);
                if (Ball != Vector3.zero)
                {
                    transform.Translate(Ball * 1 * Time.deltaTime, Space.World);
                }
            }

        }

    }
}
