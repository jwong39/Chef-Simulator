using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FridgeButtons : MonoBehaviour
{
    public int stock = 10;
    public GameObject uiObject;
    public GameObject playerObject;
    public Text StockText;

    public GameObject SteakPrefab;
    public GameObject ChickenPrefab;
    // Start is called before the first frame update
    void Start()
    {
        uiObject = GameObject.Find("UI");
        playerObject = GameObject.Find("Player");
    }

    public void Food(GameObject Prefab){
        if (playerObject.GetComponent < PlayerInventory > ().holdingObject == null && stock > 0){
            playerObject.GetComponent < PlayerInventory > ().holdingObject = Instantiate(Prefab, new Vector3(0, 0, 0), Quaternion.identity); 
            stock--;
        }else{
            for (int i = 0; i < 4; i++){
                if(playerObject.GetComponent < PlayerInventory > ().InvArr[i] == null && stock > 0){
                    playerObject.GetComponent < PlayerInventory > ().InvArr[i] = Instantiate(Prefab, new Vector3(0, 0, 0), Quaternion.identity); 
                    stock--;
                    break;
                }
            }
        }

        StockText.text = "x" + stock;
    }


}

