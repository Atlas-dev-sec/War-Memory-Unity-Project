using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    public GameObject endingMenu;

    public void Update(){
        Debug.Log(GameManager.score);
        if (GameManager.score >= 4){
            GameManager.score = 0;
            endingMenu.SetActive(true);
        }
    }
    
    public void QuitToMain(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart(){
        SceneManager.LoadScene("MainScene");

    }
}
