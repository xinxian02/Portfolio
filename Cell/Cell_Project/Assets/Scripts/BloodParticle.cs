using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    public ParticleSystem ptc;

    public void StopPtc()
    {
        ptc.Stop();
        GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 2f);
        LevelManager.lm.MakePlane();
    }
     
}
