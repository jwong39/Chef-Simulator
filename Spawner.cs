using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject ClientPrefab;
    public float waitTillOrderComplete = 30;
    public float waiting = 0;
    public bool hasClient = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waiting += Time.deltaTime;
        if (!hasClient && waiting >= waitTillOrderComplete){
            Instantiate(ClientPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
