using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public GameObject[] LemonChicken; // ID 0
    public GameObject[] StackNVeg; // ID 1
    public int orderID = -1;
    public Sprite LemonChickenImg;
    public Sprite StackNVegImg;
    public Sprite FruitSaladImg;
    public Sprite HamNSaladImg;

    public bool hasOrder = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(orderID);
    }

    public bool completeDish(GameObject x){
        // Debug.Log("Complete?");
        if (orderID == 0){
            bool hasCookedChicken = false;
            bool hasSlicedLemon = false;
            for (int i = 0; i < 5; i++){
                
                if (x.gameObject.GetComponent<Dish_Collider>().Ingredients[i] != null){
                    Debug.Log(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 14));
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 14), "Cooked Chicken") == 0){
                        hasCookedChicken = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 12), "Sliced_Lemon") == 0){
                        hasSlicedLemon = true;
                    }
                }
                
            }
            if (hasSlicedLemon && hasCookedChicken && x.gameObject.GetComponent<Dish_Collider>().Ingredients[2] == null){
                return true;
            }
            return false;
            
        }else if (orderID == 1){
            bool hasCookedSteak = false;
            bool hasSlicedLetuce = false;
            bool hasSlicedTomato = false;
            for (int i = 0; i < 5; i++){
                
                if (x.gameObject.GetComponent<Dish_Collider>().Ingredients[i] != null){
                    Debug.Log(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 14));
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 12), "Cooked Steak") == 0){
                        hasCookedSteak = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 13), "Sliced Letuce") == 0){
                        hasSlicedLetuce = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 13), "Sliced Tomato") == 0){
                        hasSlicedTomato = true;
                    }
                }
                
            }
            if (hasSlicedTomato && hasSlicedLetuce && hasCookedSteak && x.gameObject.GetComponent<Dish_Collider>().Ingredients[3] == null){
                return true;
            }
            return false;
        }else if (orderID == 2){
            bool hasSlicedLetuce = false;
            bool hasSlicedTomato = false;
            bool hasSlicedOrange = false;
            bool hasSlicedLime = false;
            bool hasSlicedLemon = false;
            for (int i = 0; i < 5; i++){
                
                if (x.gameObject.GetComponent<Dish_Collider>().Ingredients[i] != null){
                    Debug.Log(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 14));
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 12), "Sliced_Lemon") == 0){
                        hasSlicedLemon = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 13), "Sliced Letuce") == 0){
                        hasSlicedLetuce = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 13), "Sliced Tomato") == 0){
                        hasSlicedTomato = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 11), "Sliced_Lime") == 0){
                        hasSlicedLime = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 13), "Sliced_Orange") == 0){
                        hasSlicedOrange = true;
                    }
                }
                
            }
            if (hasSlicedLetuce && hasSlicedTomato && hasSlicedOrange && hasSlicedLime && hasSlicedLemon && x.gameObject.GetComponent<Dish_Collider>().Ingredients[5] == null){
                return true;
            }
            return false;
        }else if (orderID == 3){
            bool hasSlicedLetuce = false;
            bool hasCookedHam = false;
            bool hasCarrot = false;
            for (int i = 0; i < 5; i++){
                
                if (x.gameObject.GetComponent<Dish_Collider>().Ingredients[i] != null){
                    //Debug.Log(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 14));
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 10), "Cooked Ham") == 0){
                        hasCookedHam = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 13), "Sliced Letuce") == 0){
                        hasSlicedLetuce = true;
                    }
                    if (string.Compare(x.gameObject.GetComponent<Dish_Collider>().Ingredients[i].name.Substring(0, 5), "Carro") == 0){
                        hasCarrot = true;
                    }
                }
                
            }
            if (hasSlicedLetuce && hasCookedHam && hasCarrot && x.gameObject.GetComponent<Dish_Collider>().Ingredients[3] == null){
                return true;
            }
            return false;
        }
        return false;
    }

    public void changeDishImg(GameObject x){
        if (orderID == 0 ){
            x.gameObject.GetComponent<SpriteRenderer>().sprite = LemonChickenImg;
        }else if (orderID == 1 ){
            x.gameObject.GetComponent<SpriteRenderer>().sprite = StackNVegImg;
            x.gameObject.GetComponent<Transform>().transform.localScale = new Vector3(0f,0f,0f);
            x.gameObject.GetComponent<Transform>().transform.localScale += new Vector3(2.4f,2.4f,0f);
        }else if (orderID == 2 ){
            x.gameObject.GetComponent<SpriteRenderer>().sprite = FruitSaladImg;
            // x.gameObject.GetComponent<Transform>().transform.localScale = new Vector3(0f,0f,0f);
            //x.gameObject.GetComponent<Transform>().transform.localScale += new Vector3(2.4f,2.4f,0f);
        }else if (orderID == 3 ){
            x.gameObject.GetComponent<SpriteRenderer>().sprite = HamNSaladImg;
            // x.gameObject.GetComponent<Transform>().transform.localScale = new Vector3(0f,0f,0f);
            //x.gameObject.GetComponent<Transform>().transform.localScale += new Vector3(2.4f,2.4f,0f);
        }
    }

    public void changeName(GameObject x){
        if (orderID == 0 ){
            x.gameObject.name = "Lemon Chicken";
        }else if (orderID == 1 ){
            x.gameObject.name = "Steak and Salad";
        }else if (orderID == 2 ){
            x.gameObject.name = "Fruit Salad";
        }else if (orderID == 3 ){
            x.gameObject.name = "Ham and Salad";
        }
    }

    public void setOrderID(int n){
        orderID = n;
    }
}
