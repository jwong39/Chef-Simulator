using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheMainMenu : MonoBehaviour
{
    public void introSound()
    {
         SoundManagerScript.PlaySound("intro");

    }
    public void PlayGame(){
        introSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame(){
        Application.Quit();
    }
}
