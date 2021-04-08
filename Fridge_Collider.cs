using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fridge_Collider : MonoBehaviour
{
    public BoxCollider2D col;
    public GameObject playerObject;
    public GameObject uiObject;
    bool collision, open;
    public Animator anim;

    public string type;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        uiObject = GameObject.Find("UI");
        anim = this.gameObject.GetComponent<Animator>();
        collision = false;
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && collision)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //SoundManagerScript.PlaySound("fridgeOpen");                
                anim.SetBool("open", true);
                open = true;
                SoundManagerScript.PlaySound("fridgeOpen");
                uiObject.GetComponent<UIManager>().inInventory = true;
                uiObject.GetComponent<UIManager>().inFridge = true;
                if (string.Compare(type, "M") == 0){
                    uiObject.GetComponent<UIManager>().fridgeType = "M";
                }else if (string.Compare(type, "F") == 0){
                    uiObject.GetComponent<UIManager>().fridgeType = "F";
                }
                
            }
        }else if (open && collision)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                //SoundManagerScript.PlaySound("fridgeClose");               
                anim.SetBool("open", false);
                open = false;
                SoundManagerScript.PlaySound("fridgeClose");
                uiObject.GetComponent<UIManager>().inInventory = false;
                uiObject.GetComponent<UIManager>().inFridge = false;
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
            anim.SetBool("open", false);
            open = false;
            uiObject.GetComponent<UIManager>().inInventory = false;
            uiObject.GetComponent<UIManager>().inFridge = false;
        }
    }
}