using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string functionOnClick;

    private void OnMouseOver() {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null){
            sprite.color = Color.cyan;
        }    
    }

    public void OnMouseDown(){
        transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
    }

    public void OnMouseUp() {
        transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        if(gameManager != null){
            gameManager.SendMessage(functionOnClick);
        }    
    }

    public void OnMouseExit() {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null){
            sprite.color = Color.white;
        }
    }
}
