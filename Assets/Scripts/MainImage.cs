using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImage : MonoBehaviour
{
   [SerializeField] private GameObject image_unknown;
   [SerializeField] private GameManager gameManager;

   private void OnMouseDown() {
    if(image_unknown.activeSelf && gameManager.canOpen){
        image_unknown.SetActive(false);
        gameManager.ImageOpened(this);
     } 
   }

   private int _spriteId;
   public int spriteId{
    get { return _spriteId; }
   }

   public void ChangeSprite(int id, Sprite image){
    _spriteId = id;
    GetComponent<SpriteRenderer>().sprite = image;
   }

   public void Close(){
    image_unknown.SetActive(true); // hide image
   }


}
