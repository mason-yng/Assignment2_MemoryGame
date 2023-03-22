using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImScript : MonoBehaviour
{
    [SerializeField] private GameObject blank;
    [SerializeField] private GameControllerScript gameController;

    public void OnMouseDown()
    {
        if(blank.activeSelf&& gameController.canOpen)
        {
            blank.SetActive(false);
            gameController.imageOpened(this);
        }
    }
    private int _spriteId;

    public int spriteId
    {
        get{ return _spriteId; } 
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    
    public void Close()
    {
        blank.SetActive(true);//hide
    }
}