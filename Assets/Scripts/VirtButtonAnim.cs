using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtButtonAnim : MonoBehaviour, IVirtualButtonEventHandler { //Für den Virtual Button, wird er gedrückt dreht sich das Rad

    public GameObject virtualButton;
    public GameObject spinner;

    // Use this for initialization
    void Start() {
        virtualButton = GameObject.Find("VirtualButton");
        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        spinner = GameObject.Find("Drehrad");

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {

        if (spinner.GetComponent<Spinner>().interactable) {
            spinner.GetComponent<Spinner>().Spin();
        }
        
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {

    }


	
	// Update is called once per frame
	void Update () {


    }
}
