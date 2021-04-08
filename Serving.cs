using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serving : MonoBehaviour
{
    public BoxCollider2D col;
    public GameObject playerObject;
    public GameObject RecipeManager;
    public GameObject uiObject;
    public bool collision;


    

    // Start is called before the first frame update
    void Start()
    {
        //d_AudioSource = GetComponent<AudioSource>();
        playerObject = GameObject.Find("Player");
        RecipeManager = GameObject.Find("Recipe Manager");
        uiObject = GameObject.Find("UI");
        collision = false;
        // open = false;
        //pc = (GameObject.Find("Player")).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collision)
        {
            if (Input.GetKeyDown(KeyCode.Space) && RecipeManager.GetComponent<Recipe>().hasOrder)
            {
                GameObject client = GameObject.Find("AI");
                if (playerObject.GetComponent<PlayerInventory>().holdingObject.GetComponent<Dish_Collider>().complete){
                    Destroy(playerObject.GetComponent<PlayerInventory>().holdingObject);
                    uiObject.GetComponent<UIManager>().Cash += 20;
                    RecipeManager.GetComponent<Recipe>().hasOrder = false;
                }else {
                    playerObject.GetComponent<PlayerInventory>().holdingObject.GetComponent<Dish_Collider>().DestroyIngredients();
                    Destroy(playerObject.GetComponent<PlayerInventory>().holdingObject);
                    uiObject.GetComponent<UIManager>().Cash += 5;
                    RecipeManager.GetComponent<Recipe>().hasOrder = false;
                }
                
            }
        }
 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            if (playerObject.GetComponent<PlayerInventory>().holdingObject.GetComponent<Dish_Collider>() != null){
                collision = true;
            }
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
