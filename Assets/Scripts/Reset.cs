using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private GameControllerScript gameController;
    [SerializeField] private string functionOnClick;

    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite!=null)
        {
            sprite.color = Color.cyan;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 0.9f);
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.9f);
        if (gameController != null)
        {
            gameController.SendMessage(functionOnClick);
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = Color.white;
        }
    }
}
