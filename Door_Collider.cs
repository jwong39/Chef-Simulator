using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Collider : MonoBehaviour
{
    public BoxCollider2D col;
    //public BoxCollider2D col2;
    public GameObject playerObject;
    //public GameObject lockObject;
    //public GameObject keyObject;
    //PlayerController pc;
    bool collision, open;
    public Animator anim;
    //public bool locked = false;
    //public AudioClip Open;
    //public AudioClip Close;
    //public AudioSource d_AudioSource;

    

    // Start is called before the first frame update
    void Start()
    {
        //d_AudioSource = GetComponent<AudioSource>();
        playerObject = GameObject.Find("Player");
        anim = this.gameObject.GetComponent<Animator>();
        collision = false;
        open = false;
        //pc = (GameObject.Find("Player")).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && collision)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("open", true);
                open = true;
                col.enabled = false;
                //this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //d_AudioSource.PlayOneShot(Open);
                //this.gameObject.SetActive(false);
                
            }
        }else if (open && collision)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                anim.SetBool("open", false);
                open = false;
                col.enabled = true;
                //d_AudioSource.PlayOneShot(Close);
                //this.gameObject.SetActive(true); 
            }

        }
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