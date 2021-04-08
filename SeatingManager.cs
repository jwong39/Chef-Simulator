using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatingManager : MonoBehaviour
{

    
    Vector2 pos0;
    Vector2 pos1;
    Vector2 pos2;
    Vector2 pos3;
    Vector2 pos4;
    Vector2 pos5;
    Vector2 pos6;
    Vector2 pos7;
    // array should inclure seat array locations
    Vector2[] seatArray = new Vector2[8];
    // Start is called before the first frame update
    void Start()
    {
        pos0.x = 4.07f;
        pos0.y =-5.38f;
        pos1.x = 6.25f;
        pos1.y = -3.78f;
        pos2.x = 9.26f;
        pos2.y = -5.40f;
        pos3.x = 10.78f;
        pos3.y = -4.19f;
        pos4.x = 11.05f;
        pos4.y = -2.04f;
        pos5.x = 6.88f; 
        pos5.y = -1.07f;
        pos6.x = 3.55f; 
        pos6.y = -0.53f;
        pos7.x = 3.57f; 
        pos7.y = 1.20f;

        seatArray[0] = pos0;
        seatArray[1] = pos1;
        seatArray[2] = pos2;
        seatArray[3] = pos3;
        seatArray[4] = pos4;
        seatArray[5] = pos5;
        seatArray[6] = pos6;
        seatArray[7] = pos7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
