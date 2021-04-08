using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutting_Collider : MonoBehaviour
{
    public BoxCollider2D col;
    public GameObject playerObject;

    bool collision;


    

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        
        collision = false;
    }
}
