using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash_Collider : MonoBehaviour
{
    public BoxCollider2D col;
    //public BoxCollider2D col2;
    public GameObject playerObject;
    //public GameObject lockObject;
    //public GameObject keyObject;
    //PlayerController pc;
    public bool collision;
    // public Animator anim;


    

    // Start is called before the first frame update
    void Start()
    {
        //d_AudioSource = GetComponent<AudioSource>();
        playerObject = GameObject.Find("Player");
        // anim = this.gameObject.GetComponent<Animator>();
        collision = false;
        // open = false;
        //pc = (GameObject.Find("Player")).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (collision)
        // {
        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         Debug.Log("HHHHEEERRRREEEE");
        //         Destroy(playerObject.GetComponent<PlayerInventory>().holdingObject);
                
        //     }
        // }
 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            collision = true;
            // Debug.Log("Entered");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            collision = false;
            // Debug.Log("Exited");
        }
    }
}