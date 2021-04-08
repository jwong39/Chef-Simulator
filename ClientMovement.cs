using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class ClientMovement : MonoBehaviour
{
    public Transform AITrans;
    public GameObject RecipeManager;
    public AIPath aiPath;
    public Patrol pat;
    public Recipe rec;
    [SerializeField] private int minTime, maxTime;
    private float speed;
    private bool facingRight, facingLeft, facingUp, facingFront;
    Vector2 pos;
    bool moving;
    int time;
    int target;
    public Animator anim;
    float pastX;
    float pastY;
    bool useOnce;
    bool useTwonce;
    bool useThrince;
    bool gotOrder;
    // private Transform myTransform;
    // Start is called before the first frame update

    void Awake()
    {
        // myTransform = GetComponent<Transform>();
        // speed = 0.01f;
        RecipeManager = GameObject.Find("Recipe Manager");
        facingRight = true;
        moving = false;
        pos = transform.position; // Get player position
        pastX = pos.x;
        pastY = pos.y;
        target = 1;
        useOnce = false;
        useTwonce = false;
        gotOrder = false;
        useThrince = false;
        // posi.x = 9.08f;
        // posi.y = -6.22f; 
    }

    // Update is called once per frame
    void Update()
    {
        // moving = true;
        // posi = transform.position; // Get player position
        // posi.y += speed;
        if(useOnce == true){
            atSeat();
        }
        orderSomething();
        exitPlace();
        pos = transform.position; // Get player position
        if(((Math.Abs(pos.x-pastX)) > 0.01f) || ((Math.Abs(pos.y-pastY)) > 0.01f)){
            moving = true;
        }
        else{
            moving = false;
        }
        if(pos.x<pastX) // if i moved left, x value decreases , diagnal bottom left or upper left
        {
            facingRight = facingFront = facingUp = false;
            facingLeft = true;
        }
        else if(pos.x>pastX) // if i moved right, x value increases, , diagnal bottom right or upper right
        {
            facingLeft = facingFront = facingUp = false;
            facingRight = true;
        }
        else if(pos.y>pastY) // if i moved up, y value increases
        {
            facingLeft = facingFront = facingRight = false;
            facingUp = true;
        }
        else if(pos.y<pastY) // if i moved down, y value decreases
        {
            facingLeft = facingUp = facingRight = false;
            facingFront = true;
        }

        anim.SetBool("move", moving);


        anim.SetBool("right", facingRight);
        anim.SetBool("front", facingFront);
        anim.SetBool("up", facingUp);
        anim.SetBool("left", facingLeft);
        //reset past
        pastX = pos.x;
        pastY = pos.y;


        // after 30 seconds client walks in
        // stops at collider
    }


    void orderSomething(){
        if(aiPath.reachedDestination == false){
            useOnce = true;
        }
        else if(aiPath.reachedDestination == true && useOnce == true){
            useOnce = false;
            if(target%3 == 1){
                rec.setOrderID(RandomNumber(0, 4));
                rec.hasOrder = true;
            }
            target++;
        }

    }
    void atSeat(){
        // if(aiPath.reachedDestination == true ){
        //     if(target%3 == 2)
        //     {
        //         Debug.Log(target%3);
        //         pat.delay = 100000;
        //         if(gotOrder == true){
        //             pat.delay = 1;
        //         }
        //     }  
        // }
        if (Vector2.Distance(pat.targets[1].position, AITrans.position) < 0.2){
            Debug.Log(target%3);
            pat.delay = 10000;
            if(RecipeManager.GetComponent<Recipe>().hasOrder == false){
                pat.delay = 1;
            }
        }
        //transform.parent.gameObject.getComponent<Transform>().transform
        
        // if (rec.hasOrder == true){
        //     Debug.Log(target%3);
        //     pat.delay = 100000;
        //     if(gotOrder == true){
        //         pat.delay = 1;
        //     }
        // }
    }
    void exitPlace(){
        if(aiPath.reachedDestination == false){
            useTwonce = true;
        }
        else if(aiPath.reachedDestination == true && useTwonce == true){
            useTwonce = false;
            if(target%3 == 0){
                Destroy(transform.parent.gameObject);
            }
            target++;
        }
    }

    private int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    void FixedUpdate() {
        time = time + 1;
        
        transform.position = pos;
        //Debug.Log(moving);
        //if(moving && (time%18 == 0)){//if the player is moving use sound
        //    time = 0;
        //    PlayFootStepAudio();
        //}
    } 
    // void FixedUpdate(){
    //     // time = time + 1;
    //     // transform.position = posi;
    // }
    // public float getSpeed(){
    //     return speed;
    // }
    // public void setSpeed(float n){
    //     speed = n;
    // }
}
