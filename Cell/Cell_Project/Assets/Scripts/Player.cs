using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody myRig;
    float keyTime = 0;
    public Scrollbar myBar;
    int myScore;
    public Text scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // void Update()
    // {
    //     if (Input.touchCount > 0)
    //     {
    //         Touch touch = Input.GetTouch(0);
    //         if (touch.phase == TouchPhase.Began)
    //         {
    //             // When touch starts
    //         }
    //         else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
    //         {
    //             // When touch is held or moved
    //             keyTime += Time.deltaTime;
    //         }
    //         else if (touch.phase == TouchPhase.Ended)
    //         {
    //             // When touch ends
    //             myRig.AddForce(new Vector3(0, 1f, 1f) * 1000f * keyTime);
    //             keyTime = 0f;
    //         }
    //     }
    //
    //     myBar.size = keyTime;
    //
    //     if (transform.position.y < -10f)
    //     {
    //         SceneManager.LoadScene(0);
    //     }
    // }
    


    //Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            keyTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myRig.AddForce(new Vector3(0, 1f, 1f) * 1000f *keyTime);
            // myRig.AddTorque(Vector3.right * 100f);
            keyTime = 0f;
        }
        myBar.size = keyTime;
    
        if(transform.position.y < -10f)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        other.GetComponent<BloodParticle>().StopPtc();
        myScore++;
    }
    private void OnCollisionEnter(Collision collision)
    {
        scoreUI.text = myScore.ToString();
    }
}
