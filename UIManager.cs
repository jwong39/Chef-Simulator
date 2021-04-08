using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public double Cash = 10; 

    // Start is called before the first frame update
    public Image holdingImg;
    public Button holdingButton;
    public Image holdingButtonImg;
    public bool inInventory = false;
    public bool inFridge = false;
    public bool inShop = false;

    // gameobjects assigned manually in the scene
    public GameObject Inventory;
    public GameObject ShopButton;
    public GameObject Fridge;
    public GameObject meatFridge;
    public GameObject fruitFridge;
    public GameObject Recipe;
    public GameObject Shop;
    public Text CashText;

    // gameobjects we find in the scene
    public GameObject playerObject;
    public GameObject holdingObject;
    public GameObject RecipeManager;


    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject[] InvArrImg;

    public GameObject movingItem;

    public int swappingNum = -1;

    public Camera cam;

    public string fridgeType = "";

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        playerObject = GameObject.Find("Player");
        RecipeManager = GameObject.Find("Recipe Manager");

    }

    // Update is called once per frame
    void Update()
    {
        CashText.text = "Cash: $" + Cash;


        if (movingItem != null){
            Vector2 pos;
            if (swappingNum == 4){
                pos = Input.mousePosition; 
                pos += new Vector2(2,0);
                holdingImg.transform.position = pos;
            }else{
                pos = Input.mousePosition; 
                pos += new Vector2(2,0);
                InvArrImg[swappingNum].transform.position = pos;
            }
        }

        holdingObject = playerObject.GetComponent<PlayerInventory>().holdingObject;
        holdingImg.enabled = false;
        if (holdingObject != null){
            holdingImg.sprite = holdingObject.GetComponent<SpriteRenderer>().sprite;
            holdingImg.enabled = true;
        }

        if (RecipeManager.GetComponent<Recipe>().hasOrder == true){
            RecipeManager.gameObject.SetActive(true);
        }else{
            RecipeManager.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab)){
            if (!inShop){
                if (inInventory){
                    inInventory = false;
                }else if(inFridge && inInventory){
                    inInventory = true;
                    inFridge = true;
                }else {
                    inInventory = true;
                }
            }
            
            
        }
        if (inShop){
            Inventory.gameObject.SetActive(false);
            Fridge.gameObject.SetActive(false);
            fruitFridge.gameObject.SetActive(false);
            meatFridge.gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Shop.gameObject.SetActive(true);
        }else if(inInventory){
            ShopButton.gameObject.SetActive(true);
            Shop.gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            holdingButton.enabled = true;
            holdingButtonImg.enabled = true;

            if (inFridge){
                Fridge.gameObject.SetActive(true);
                if (string.Compare(fridgeType, "M") == 0){
                    meatFridge.gameObject.SetActive(true);
                    fruitFridge.gameObject.SetActive(false);
                }else if (string.Compare(fridgeType, "F") == 0){
                    fruitFridge.gameObject.SetActive(true);
                    meatFridge.gameObject.SetActive(false);
                }
            }
            if (movingItem == null){
                holdingImg.gameObject.transform.position = holdingButton.gameObject.transform.position;
            }

            Inventory.gameObject.SetActive(true);
            for (int i = 0; i < 4; i++){
                if (playerObject.GetComponent<PlayerInventory>().InvArr[i] != null){
                    
                    InvArrImg[i].GetComponent<Image>().sprite = playerObject.GetComponent<PlayerInventory>().InvArr[i].GetComponent<SpriteRenderer>().sprite;
                    InvArrImg[i].GetComponent<Image>().enabled = true;
                    if (movingItem == null){
                        InvArrImg[i].transform.position = InvArrImg[i].transform.parent.transform.position;
                    }
                }else{
                    InvArrImg[i].GetComponent<Image>().enabled = false;
                }
                
            }
        }else{
            holdingButton.enabled = false;
            holdingButtonImg.enabled = false;
            ShopButton.gameObject.SetActive(false);
            Inventory.gameObject.SetActive(false);
            Fridge.gameObject.SetActive(false);
            fruitFridge.gameObject.SetActive(false);
            meatFridge.gameObject.SetActive(false);
            Shop.gameObject.SetActive(false);
            Cursor.visible = false;
            movingItem = null;
        }
    }

    
}
