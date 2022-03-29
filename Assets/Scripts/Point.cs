using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public GameObject Inner;
    
    private Vector2 _position;
    public Vector2 Pos => _position;

    

    public void Init(Vector2 position)
    {
        this._position = position;
    }

    private void OnMouseDown()
    {
        if(GameManager.Instance.GetGameState==GameManager.GameState.player1){
            Inner.GetComponent<SpriteRenderer>().color=Color.blue;
            
            BoardManager.Instance.SetPoint(this);
        }else{
            Inner.GetComponent<SpriteRenderer>().color=Color.red;
            BoardManager.Instance.SetPoint(this);
        }
        
       
        
    }
    
}
