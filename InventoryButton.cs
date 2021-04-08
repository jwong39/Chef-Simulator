using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        canvasObject = GameObject.Find("UI");
        playerObject = GameObject.Find("Player");
    }

    public void holdingButton(){
       if(canvasObject.GetComponent<UIManager>().movingItem != null){
            //this.gameObject.GetComponent<Button>().enabled = true;
            playerObject.GetComponent<PlayerInventory>().swap(canvasObject.GetComponent<UIManager>().swappingNum, 4);
            canvasObject.GetComponent<UIManager>().movingItem = null;
        }else if (canvasObject.GetComponent<UIManager>().movingItem == null && playerObject.GetComponent<PlayerInventory>().holdingObject != null && !(string.Compare(playerObject.GetComponent<PlayerInventory>().holdingObject.name.Substring(0, 4), "Dish") == 0)  ){
            //this.gameObject.GetComponent<Button>().enabled = false;
            canvasObject.GetComponent<UIManager>().movingItem = canvasObject.GetComponent<UIManager>().holdingObject;
            canvasObject.GetComponent<UIManager>().swappingNum = 4;
        }
    }

    public void InventoryButton1(int num){
        if(canvasObject.GetComponent<UIManager>().movingItem != null){
            //this.gameObject.GetComponent<Button>().enabled = true;
            playerObject.GetComponent<PlayerInventory>().swap(canvasObject.GetComponent<UIManager>().swappingNum, num);
            canvasObject.GetComponent<UIManager>().movingItem = null;
        }else if (playerObject.GetComponent<PlayerInventory>().InvArr[num] != null){
            //this.gameObject.GetComponent<Button>().enabled = false;
            canvasObject.GetComponent<UIManager>().movingItem = canvasObject.GetComponent<UIManager>().InvArrImg[num];
            canvasObject.GetComponent<UIManager>().swappingNum = num;
        }
    }

}
