using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish_Collider : MonoBehaviour
{
    public GameObject[] Ingredients;
    public int ingredientsNum = 0;
    public GameObject playerObject;
    public GameObject RecipeManager;
    public BoxCollider2D col;

    bool collision;
    public bool complete = false;

    float delay = 0.25f;
    float timeSinceSpacePressed = 0;

    void Awake()
    {
        complete = false;
        col = this.gameObject.GetComponent<BoxCollider2D>();
        //col.enabled = false;
        playerObject = GameObject.Find("Player");
        RecipeManager = GameObject.Find("Recipe Manager");
        collision = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpacePressed += Time.deltaTime;
        // makes the ingredients show above plate
        if (Ingredients[0] != null && !complete){
            float height = 0f;
            float s = 0f;
            foreach (GameObject x in Ingredients){
                if (x != null){
                    height = 0.5f + (s *0.5f);
                    x.transform.position = this.gameObject.transform.position + this.gameObject.transform.TransformDirection(new Vector3(0, height, 0));
                    s++;
                }
                
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && collision && timeSinceSpacePressed > delay)
                {
                    timeSinceSpacePressed = 0;
                    Debug.Log("Here 4");
                    // Run pick up and equip weapon code 
                    playerObject.GetComponent < PlayerInventory > ().timeSinceSpacePressed = 0;
                    playerObject.GetComponent < PlayerInventory > ().itemToPickup = null;
                    if (playerObject.GetComponent < PlayerInventory > ().holdingObject == null){
                        //Debug.Log("Here 5");
                        playerObject.GetComponent < PlayerInventory > ().holdingObject = this.gameObject; 
                        col.enabled = false;
                    }else if (playerObject.GetComponent < PlayerInventory > ().holdingObject != null && playerObject.GetComponent < PlayerInventory > ().holdingObject.GetComponent < ItemPickup > () != null && !complete){
                        Ingredients[ingredientsNum] = playerObject.GetComponent < PlayerInventory > ().holdingObject;
                        ingredientsNum++;
                        playerObject.GetComponent < PlayerInventory > ().holdingObject = null;
                        if (RecipeManager.GetComponent < Recipe > ().completeDish(this.gameObject)){
                            DestroyIngredients();
                            RecipeManager.GetComponent < Recipe > ().changeDishImg(this.gameObject);
                            RecipeManager.GetComponent < Recipe > ().changeName(this.gameObject);
                            complete = true;
                        }
                    }
                }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        float delay = 0.25f;
        if (other.gameObject == playerObject.gameObject)
        {
            // Debug.Log("Here 1");
            if (playerObject.GetComponent < PlayerInventory > ().itemToPickup == null)
            {
                playerObject.GetComponent < PlayerInventory > ().itemToPickup = this.gameObject;
            }
            
            playerObject.GetComponent < PlayerInventory > ().timeSinceSpacePressed += Time.deltaTime;
            // Debug.Log("Here 2");
            if (playerObject.GetComponent < PlayerInventory > ().timeSinceSpacePressed > delay)
            {
                collision = true;
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            playerObject.GetComponent < PlayerInventory > ().itemToPickup = null;
            collision = false;
            // Debug.Log("Exited");
        }
    }

    public void DestroyIngredients(){
        foreach (GameObject x in Ingredients){
            if (x != null){
                Destroy(x);
            }
        }
    }
}
