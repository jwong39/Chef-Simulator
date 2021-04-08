using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObject;
    public Text buttonText;
    public GameObject x;

    void Start()
    {
        uiObject = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyButton(float price){
        
        if(uiObject.GetComponent<UIManager>().Cash >= price){
            x.GetComponent<FridgeButtons>().stock++;
            x.GetComponent<FridgeButtons>().StockText.text = "x" + x.GetComponent<FridgeButtons>().stock;
            uiObject.GetComponent<UIManager>().Cash -= price;
        }
    }

    public void ShopOpen(){
        
        if(uiObject.GetComponent<UIManager>().inShop){
            uiObject.GetComponent<UIManager>().inShop = false;
            buttonText.text = "Shop $$";
        }else {
            uiObject.GetComponent<UIManager>().inShop = true;
            buttonText.text = "Close";
        }
    }


}
