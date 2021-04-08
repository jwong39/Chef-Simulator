using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishStack_Collider : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject Dish;
    public bool collision = false;
    // Start is called before the first frame update
    void Awake()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collision){
            if (playerObject.GetComponent<PlayerInventory>().holdingObject == null){
                playerObject.GetComponent < PlayerInventory > ().holdingObject = Instantiate(Dish, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            collision = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            collision = false;
        }
    }
}
