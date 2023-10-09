using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    public GameObject Explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {

        if (collision.collider.tag == "BODY") {

            GameObject explosion = Instantiate(Explosion, collision.collider.transform.position, Quaternion.identity);
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration + 0.2f);
            Destroy(collision.gameObject);
        
        }
    
    }
}
