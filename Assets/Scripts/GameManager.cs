using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState _gameState;



    private int contp1;
    private int contp2;

    private int PuntosP1;
    private int PuntosP2;

    public TextMesh P1Points;
    public TextMesh P2Points;

    public TextMesh PName;
    

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        contp1 = 2;
        contp2 = 2;
        PuntosP1 = 0;
        PuntosP2 = 0;
        P1Points.text = PuntosP1.ToString();
        P2Points.text = PuntosP2.ToString();
        PName.text = "Player 1";
    }

    void Start()
    {
        _gameState = GameState.Start;
        
    }

    public enum GameState
    {
        Start,
        player1,
        player2,
        end
    }

    public GameState GetGameState => _gameState;
    // Update is called once per frame
    void Update()
    {
        switch (_gameState)
        {
            case GameState.Start:
                UpdateGameState(GameState.player1);

                break;
            case GameState.player1:
                PName.text ="Player 1";
                break;
            case GameState.player2:
                PName.text = "Player 2";
                break;
            case GameState.end:
                break;
        }
    }
    public void GetInvalidLine(GameState gameState){
        switch (gameState)
        {
            case GameState.player1:
                UpdateGameState(GameState.player2);
                contp2 = 2;
                break;
            case GameState.player2:
                UpdateGameState(GameState.player1);
                
                contp1 = 2;
                break;
        }
    }
    public void GetPuntuation(GameState gameState, int puntos)
    {
        switch (gameState)
        {
            case GameState.player1:
                PuntosP2 += puntos;
                //Debug.Log("PuntosP1: " + PuntosP1);
                //Pasa los puntos a Texto y esot se muestra en la pantalla
                P2Points.text = PuntosP2.ToString();
                //Se actualiza el GameState para que el player2 pueda jugar un turno mas
                UpdateGameState(GameState.player2);
                //Se devuelve el valor a Contp2 sino ocurre esto el player2 juega de manera indefinida
                contp2 = 2;
                break;
            case GameState.player2:
                //Para entender esto porfavor leer el codigo de player1
                PuntosP1 += puntos;
                //Debug.Log("PuntosP2: " + PuntosP2);
                P1Points.text = PuntosP1.ToString();
                UpdateGameState(GameState.player1);
                contp1 = 2;
                break;
        }
    }

    

    public void UpdateGameState(GameState gameState)
    {
        _gameState = gameState;
        
    }
    public void SwitchPlayer()
    {
        if (_gameState == GameState.player1 && contp1 >= 1)
        {

            _gameState = GameState.player1;
            contp1 = contp1 - 1;
            if (contp1 == 0)
            {
                _gameState = GameState.player2;
                contp2 = 2;
            }
        }
        else
        {
            if (_gameState == GameState.player2 && contp2 >= 1)
            {
                
                _gameState = GameState.player2;
                contp2 = contp2 - 1;
                if (contp2 == 0)
                {
                    
                    _gameState = GameState.player1;
                    contp1 = 2;
                }
            }
        }

    }

}
