using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour { //Dieses Skript ist für die Idle-Rotation einiger Objekte verantwortlich
                                      //Verwendet wird es vom Neuzeit-Helikopter und den Scifi-Drehscheiben
    private Transform toSpin;
    public float spinSpeed;
    public bool reverse;
  

	// Use this for initialization
	void Start () {
        toSpin = gameObject.GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update() {

      
            if (!reverse)
            {
                toSpin.Rotate(0, 0, spinSpeed);
            }
            else
            {
                toSpin.Rotate(0, 0, -spinSpeed);
            }

        }
        
        
	
}
