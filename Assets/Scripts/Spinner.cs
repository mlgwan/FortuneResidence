using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Spinner : MonoBehaviour
{
    private bool started;
    private float[] winFields;
    private float endField;
    private float startField;
    private float currLerpRotationTime;
    public bool interactable;

    public GameObject Circle; 			// Das zu drehende Objekt
    public GameObject residence;

    private void Start()
    {
        startField = 0;
        interactable = true;
        residence = GameObject.Find("Residence");
    }

    public void Spin()
    {

        if (residence.GetComponent<ShowResidence>().allowAnimationToPlay) {  // Das Rad ist nur drehbar, wenn gerade keine andere Zerstörungsanimation läuft
            currLerpRotationTime = 0f;

            
            winFields = new float[] { 90, 180, 270, 360 };   // Hier wird die Anzahl der Gewinn-Felder festgelegt

            int fullCircles = 5;                             // Hier wird die Anzahl der Voll-Umdrehungen realisiert
            float randomFinalAngle = winFields[UnityEngine.Random.Range(0, winFields.Length)];           
            endField = -(fullCircles * 360 + randomFinalAngle); 
            started = true;
      

        }
    }

    private void playDestructionAnimation()
    {


            if (startField == 0f)                                          // Hier wird geprüft, auf welchem Feld das Rad gelandet ist und die dazugehörige Animation abgespielt
            {
                residence.GetComponent<ShowResidence>().vulkanDestroy();
            }
            else if (startField == -270f)
            {
                residence.GetComponent<ShowResidence>().meteorDestroy();
            }
            else if (startField == -180f)
            {
                residence.GetComponent<ShowResidence>().customDestroy(residence.GetComponent<ShowResidence>().GetCurrentBuildingAnim(), residence.GetComponent<ShowResidence>().GetCurrentBuildingNumber());
            }
            else if (startField == -90f) {
                residence.GetComponent<ShowResidence>().ufoDestroy();
            } 
    }

    void Update()
    {

        if (started)
        {
            interactable = false;

        }
        else
        {
            interactable = true;

        }

        if (!started)
            return;

        float maxLerpRotationTime = 4f;
        currLerpRotationTime += Time.deltaTime;
        if (currLerpRotationTime > maxLerpRotationTime || Circle.transform.eulerAngles.y == endField)
        {
            currLerpRotationTime = maxLerpRotationTime;
            started = false;
            startField = endField % 360;

            playDestructionAnimation();                                 // Sobald das Rad fertig mit Drehen ist, wird die Zerstörungsanimation ausgewählt
       
        }
        float deltaT = currLerpRotationTime / maxLerpRotationTime;
        deltaT = deltaT * deltaT * deltaT * (deltaT * (6.0f * deltaT - 15.0f) + 10.0f);
        float angle = Mathf.Lerp(startField, endField, deltaT);
        Circle.transform.localEulerAngles = new Vector3(0,0,angle);     // Hier erfolgt die Drehanimation

    }
}