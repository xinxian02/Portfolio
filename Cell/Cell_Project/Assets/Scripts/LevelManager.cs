using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static public LevelManager lm;
    public GameObject plane;
    Vector3 pos = Vector3.zero;

    private void Awake()
    {
        lm = this;
    }

    private void Start()
    {
        MakePlane();
    }
    public void MakePlane()
    {
        pos += Vector3.forward * Random.Range(7f, 15f);
        Instantiate(plane, pos, plane.transform.rotation);
    }
     
}
