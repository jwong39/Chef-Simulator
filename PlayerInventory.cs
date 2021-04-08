using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public GameObject holdingObject;
    public Vector3 offSet = new Vector3 (1,0,0);
    //private Transform holdingTrans;
    public Animator anim;
    public GameObject[] InvArr;

    public BoxCollider2D col;
    public bool collision, cutting, dumping, nearStove = false;
    public float timeSinceSpacePressed = 0;
    public GameObject itemToPickup;
    
    public float cookedTime = 0f;

    public GameObject touchingObject;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingObject != null){

            holdingObject.gameObject.SetActive(true);
            //holdingTrans = holdingObject.GetComponent < Transform > ();
            if (holdingObject.GetComponent < ItemPickup >() != null){
                holdingObject.GetComponent < ItemPickup > ().enabled = false;
            }else if (holdingObject.GetComponent < Dish_Collider >() != null){
                // holdingObject.GetComponent < Dish_Collider > ().enabled = false;
            }
            
            holdingObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.TransformDirection(new Vector3(1.25f, 0, 0));
            if ( anim.GetBool("front")){
                holdingObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.TransformDirection(new Vector3(0, -1.25f, 0));  
            }
            else if ( anim.GetBool("left")){
                holdingObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.TransformDirection(new Vector3(-1.25f, 0, 0));  
            }
            else if ( anim.GetBool("up")){
                holdingObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.TransformDirection(new Vector3(0, 1.25f, 0));  
            }

            float delay = 0.25f;
            timeSinceSpacePressed += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift) && timeSinceSpacePressed > delay){
                if (holdingObject.GetComponent < ItemPickup >() !=null){
                    holdingObject.GetComponent<ItemPickup >().enabled = true;
                    holdingObject.GetComponent<ItemPickup >().col.enabled = true;
                }else if (holdingObject.GetComponent < Dish_Collider >() !=null){
                    holdingObject.GetComponent< Dish_Collider >().col.enabled = true;
                }
                holdingObject = null;  
                timeSinceSpacePressed = 0;
            }else if (Input.GetKeyDown(KeyCode.Space) && timeSinceSpacePressed > delay)
            { 
                if(collision && cutting){
                    GameObject temp = holdingObject.GetComponent<ItemPickup>().cutPrefab;
                    Destroy(holdingObject);
                    holdingObject = Instantiate(temp, new Vector3(0, 0, 0), Quaternion.identity);
                    
                }else if (collision && dumping){
                    if (holdingObject.GetComponent<Dish_Collider>() != null){
                        holdingObject.GetComponent<Dish_Collider>().DestroyIngredients();
                    }
                    Destroy(holdingObject);
                }else if (holdingObject != null && nearStove){
                    if (string.Compare(holdingObject.name.Substring(0, 3),"Raw") == 0 && touchingObject.GetComponent<Stone_Collider>().cooking == false){
                        
                        if (touchingObject.GetComponent<Stone_Collider>().CookedObject == null){
                            touchingObject.GetComponent<Stone_Collider>().CookedObject = holdingObject.GetComponent<ItemPickup>().cookedPrefab;
                            touchingObject.GetComponent<Stone_Collider>().cooking = true;
                            touchingObject.GetComponent<Stone_Collider>().StoveEmpty = false;
                            Destroy(holdingObject);
                        }
                        
                    }
                    
                }
                timeSinceSpacePressed = 0;
                
            }


        }


        
        for (int i = 0; i < 4; i++){
            if(InvArr[i] != null){
                InvArr[i].gameObject.SetActive(false);
            }
        }

    }

    public void swap(int x, int y){
        Debug.Log("Swaping " + x + " " + y );
        GameObject temp;
        if (x == y){
            return;
        }

        if (x == 4){
            temp = holdingObject;
            holdingObject = InvArr[y];
            InvArr[y] = temp;
        }else if (y == 4){
            temp = holdingObject;
            holdingObject = InvArr[x];
            InvArr[x] = temp;
        }else{
            temp = InvArr[x];
            InvArr[x] = InvArr[y];
            InvArr[y] = temp;
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ItemPickup>() != null || other.gameObject.GetComponent<Door_Collider>() != null || other.gameObject.GetComponent<Fridge_Collider>() != null)
        {
            collision = true;
            //Debug.Log("Entered");
        }
        else if (other.gameObject.GetComponent<Cutting_Collider>() != null){
            collision = true;
            cutting = true;
            Debug.Log("I'm here! 1");
        }else if (other.gameObject.GetComponent<Trash_Collider>() != null){
            // Debug.Log("I'm here!");
            collision = true;
            dumping = true;
        }else if (other.gameObject.GetComponent<Stone_Collider>() != null){
            // Debug.Log("I'm here!!!!!!!!!!!!!!!!!!!");
            touchingObject = other.gameObject;
            collision = true;
            nearStove= true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        collision = false;
        if (other.gameObject.GetComponent<Cutting_Collider>() != null){
            cutting = false;
        }else if (other.gameObject.GetComponent<Trash_Collider>() != null){
            dumping = false;
        }else if (other.gameObject.GetComponent<Stone_Collider>() != null){
            nearStove= false;
        }
        touchingObject = null;
        // Debug.Log("Exited");
    }
}
