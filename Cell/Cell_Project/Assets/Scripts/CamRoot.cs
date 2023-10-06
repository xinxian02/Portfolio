using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRoot : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, smoothTime);
    }
}
