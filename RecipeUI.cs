using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    public GameObject RecipeManager;

    public Text Food;
    public Text Ingredients;
    public Image foodImg;

    public string LemonChicken = "Lemon Chicken";
    public string LemonChickenIng = "   Cooked Chicken\n   Sliced Lemon";


    public string SteakAndVeg = "Steak with Salad";
    public string SteakAndVegIng = "    Cooked Steak\n    Sliced Letuce\n    Sliced Tomato";


    public string FruitSalad = "Fruit Salad";
    public string FruitSaladIng = "    Sliced Letuce\n    Sliced Tomato\n    Sliced Lime\n    Sliced Lemon\n    Sliced Orange";

    public string HamWithSalad = "Ham with Salad";
    public string HamWithSaladIng = "    Cooked Ham\n    Sliced Letuce\n    Carrots";

    // Start is called before the first frame update
    void Awake()
    {
        RecipeManager = GameObject.Find("Recipe Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (RecipeManager.GetComponent<Recipe>().hasOrder == true){
            if (RecipeManager.GetComponent<Recipe>().orderID == 0){
                Food.text = LemonChicken;
                Ingredients.text = LemonChickenIng;
                foodImg.sprite = RecipeManager.GetComponent<Recipe>().LemonChickenImg;
            }else if (RecipeManager.GetComponent<Recipe>().orderID == 1){
                Food.text = SteakAndVeg;
                Ingredients.text = SteakAndVegIng;
                foodImg.sprite = RecipeManager.GetComponent<Recipe>().StackNVegImg;
            }else if (RecipeManager.GetComponent<Recipe>().orderID == 2){
                Food.text = FruitSalad;
                Ingredients.text = FruitSaladIng;
                foodImg.sprite = RecipeManager.GetComponent<Recipe>().FruitSaladImg;
            }else if (RecipeManager.GetComponent<Recipe>().orderID == 3){
                Food.text = HamWithSalad;
                Ingredients.text = HamWithSaladIng;
                foodImg.sprite = RecipeManager.GetComponent<Recipe>().HamNSaladImg;
            }
        }
    }
}
