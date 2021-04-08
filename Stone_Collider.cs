using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Collider : MonoBehaviour // stove collider
{

    public GameObject timerObject;
    public GameObject panObject;
    public GameObject playerObject;
    public bool collision, cooking, Done = false;
    public bool StoveEmpty = true;
    public float cookedTime = 0f;
    public GameObject CookedObject;
    public Animator anim;

    public bool playedNoice = false;

    // Start is called before the first frame update
    void Start()
    {
        SoundManagerScript.PlaySound("stove");
        playerObject = GameObject.Find("Player");
        anim = timerObject.GetComponent<Animator>();
        timerObject.gameObject.SetActive(false);
        panObject.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("done", Done);
        anim.SetBool("stoveEmpty", StoveEmpty);

        if (cooking){
            Debug.Log("HHEREE");
            if (!playedNoice){
                Debug.Log("HHEREE  1");
                SoundManagerScript.PlaySound("stove");
                playedNoice = true;
            }
            Done = false;
            StoveEmpty = false;
            timerObject.gameObject.SetActive(true);
            panObject.gameObject.SetActive(true);
            float finished = 3f;
            cookedTime += Time.deltaTime;
            if (cookedTime > finished){
                Done = true;
                anim = timerObject.GetComponent<Animator>();
                
                if (Input.GetKeyDown(KeyCode.Space) && collision){
                    playedNoice = false; 
                    StoveEmpty = true;
                    timerObject.gameObject.SetActive(false);
                    panObject.gameObject.SetActive(false);
                    if (playerObject.GetComponent < PlayerInventory > ().holdingObject == null){
                        //Debug.Log("Here 5");
                        playerObject.GetComponent < PlayerInventory > ().holdingObject = Instantiate(CookedObject, new Vector3(0, 0, 0), Quaternion.identity);
                    }else{
                        for (int i = 0; i < 4; i++){
                            if(playerObject.GetComponent < PlayerInventory > ().InvArr[i] == null){
                                playerObject.GetComponent < PlayerInventory > ().InvArr[i] = Instantiate(CookedObject, new Vector3(0, 0, 0), Quaternion.identity);
                                break;
                            }
                        }
                    }
                    cookedTime = 0;
                    cooking = false;
                    CookedObject = null;
                }
                
            }
        }
        //Debug.Log(playerObject.GetComponent<PlayerInventory>().holdingObject.name);
        // if (holdingObject != null && string.Compare(holdingObject.name.Substring(0, 3),"Raw") == 0 && Input.GetKeyDown(KeyCode.Space) && collision){
        //     Debug.Log("HERE 3");
        //     Debug.Log(holdingObject.tag);
        //     GameObject cookedItem = holdingObject.GetComponent<ItemPickup>().cookedPrefab;
        //     Destroy(holdingObject);
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            collision = true;
            // Debug.Log("HERE");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            collision = false;
            // Debug.Log("HERE 2");
            
        }
    }

    public void SetCookedItem(GameObject x){
        CookedObject = x;
    }
}
