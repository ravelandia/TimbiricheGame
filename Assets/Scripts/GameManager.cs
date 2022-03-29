using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState _gameState;



    public int contp1;
    public int contp2;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        contp1 = 2;
        contp2 = 2;
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
                break;
            case GameState.player2:
                break;

            case GameState.end:
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
