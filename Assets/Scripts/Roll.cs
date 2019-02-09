using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                            /* ///////////////////////////////////////////////////////////////////////////////////////////// */
public class Roll : MonoBehaviour {                           // Dieses Script war für den virtuellen Würfel damals gedacht und wird daher nicht verwendet //
                                                            /* ///////////////////////////////////////////////////////////////////////////////////////////// */
    GameObject dice;
    int result = 0;
    // Use this for initialization
    Vector3 currentpos;
	void Start () {
        dice = GameObject.FindGameObjectWithTag("Player");
        currentpos = dice.transform.position;
    }

    // Update is called once per frame
    void Update() {
       // int side = CalcSideUp();
        
        if (Input.GetMouseButtonDown(0)) {
            RollIt();
        }
 }
    int CalcSideUp()
    {
        float dotFwd = Vector3.Dot(transform.forward, Vector3.up);
        if (dotFwd > 0.99f) return 4;
        if (dotFwd < -0.99f) return 3;
        float dotRight = Vector3.Dot(transform.right, Vector3.up);
        if (dotRight > 0.99f) return 5;
        if (dotRight < -0.99f) return 2;
        float dotUp = Vector3.Dot(transform.up, Vector3.up);
        if (dotUp > 0.99f) return 1;
        if (dotUp < -0.99f) return 6;
        return 0;
    }

    void RollIt() {
       

        dice.transform.position = new Vector3(currentpos.x, 5.0f, currentpos.z);
            result = Random.Range(1, 7);
        Debug.Log(result);
            if (result == 1)
            {
            dice.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (result == 2)
            {
            dice.transform.eulerAngles = new Vector3(0, 0, 270);
            }
            else if (result == 3)
            {
            dice.transform.eulerAngles = new Vector3(90, 0, 90);
            }
            else if (result == 4)
            {
            dice.transform.eulerAngles = new Vector3(270, 0, 0);
            }
            else if (result == 5)
            {
            dice.transform.eulerAngles = new Vector3(180, 0, 270);
            }
            else if (result == 6)
            {
            dice.transform.eulerAngles = new Vector3(180, 0, 0);
            }
        
    }
}
