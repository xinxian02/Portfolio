using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static public LevelManager lm;
    public Transform player;
    public GameObject enemy;
    // Start is called before the first frame update

    public float rateTime =2;
    public float myTime;

    void Awake()
    {
        lm = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        if (myTime > rateTime)
        {
            Vector2 r = Random.insideUnitCircle.normalized*30;
            Instantiate(enemy,player.position + new Vector3(r.x,0,r.y),Quaternion.Euler(new Vector3(0.0f,Random.Range(0.0f,360.0f),0.0f)));
            myTime -= rateTime;
        }
    }
}
