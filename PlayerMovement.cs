using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (AudioSource))]

public class PlayerMovement : MonoBehaviour {
    // Player Attributes
    private float speed;
    private bool facingRight, facingLeft, facingUp, facingFront;
    Vector2 pos;
    bool moving;
    //PlayerController pc;
    int time;
    public float cookedTime = 0f;

    public Animator anim;

    //[SerializeField] private AudioClip[] m_FootstepSounds;
    //private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start() {
        speed = 0.08f;
        facingFront = true;
        //m_AudioSource = GetComponent<AudioSource>();
        moving = false;
    } // End of Start

    // Update is called once per frame
    void Update() {
        // Variables to get key pressed
        bool leftKey = Input.GetKey("left") || Input.GetKey("a");
        bool rightKey = Input.GetKey("right") || Input.GetKey("d");
        bool upKey = Input.GetKey("up") || Input.GetKey("w");
        bool downKey = Input.GetKey("down") || Input.GetKey("s");

        // Set the moving animation tag to true/false
        moving = (leftKey ^ rightKey) || (upKey ^ downKey);
        anim.SetBool("move", moving);

        pos = transform.position; // Get player position

        // Check x-axis movement
        if(leftKey && !rightKey) {
            // Check if player sprite should flip
            // Debug.
            // SoundManagerScript.PlaySound("footstep");
            facingRight = facingFront = facingUp = false;
            facingLeft = true;
            pos.x -= speed;
        } else if(rightKey && !leftKey) {
            // Check if player sprite should flip
            // SoundManagerScript.PlaySound("footstep");
            facingLeft = facingFront = facingUp = false;
            facingRight = true;
            pos.x += speed; //pos.x = pos.x + 0.08f
        }else if(upKey && !downKey) { // Check y-axis movement
            // SoundManagerScript.PlaySound("footstep");
            facingLeft = facingFront = facingRight = false;
            facingUp = true;
            pos.y += speed;
        } else if(downKey && !upKey) {
            // SoundManagerScript.PlaySound("footstep");
            facingLeft = facingUp = facingRight = false;
            facingFront = true;
            pos.y -= speed;
        }

        anim.SetBool("right", facingRight);
        anim.SetBool("left", facingLeft);
        anim.SetBool("front", facingFront);
        anim.SetBool("up", facingUp);
        
    } // End of Update
    

    // FixedUpdate is called depending on the framerate of the computer
    void FixedUpdate() {
        time = time + 1;
        
        transform.position = pos;
        // Debug.Log(moving);
        if(moving && (time%18 == 0)){//if the player is moving use sound
            time = 0;
            // PlayFootStepAudio();
            SoundManagerScript.PlaySound("footstep");
        }
    } // End of FixedUpdate
    
    // private void PlayFootStepAudio()
    // {
    //     // pick & play a random footstep sound from the array,
    //     // excluding sound at index 0
    //     int n = Random.Range(1, m_FootstepSounds.Length);
        
    //     m_AudioSource.clip = m_FootstepSounds[n];
    //     m_AudioSource.PlayOneShot(m_AudioSource.clip);
    //     // move picked sound to index 0 so it's not picked next time
    //     m_FootstepSounds[n] = m_FootstepSounds[0];
    //     m_FootstepSounds[0] = m_AudioSource.clip;
    // }

    public float getSpeed(){
        return speed;
    }
    public void setSpeed(float n){
        speed = n;
    }
}
