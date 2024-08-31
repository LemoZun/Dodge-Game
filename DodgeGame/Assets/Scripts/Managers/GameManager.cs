using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public event Action OnGameStart;
    public event Action OnGameEnd;

    
    public enum GameState { Ready, Running, GameOver}

    public GameState curState;

    private void Awake()
    {

        if(Instance == null)
        {
            Instance = this;            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void Start()
    {
        curState = GameState.Ready;

    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.anyKeyDown)
        {
            GameStart();
        }
        else if (curState == GameState.GameOver && Input.GetKeyDown(KeyCode.R))
            GameStart();
    }

    public static void Create()
    {
        GameManager gameManagerPrefab = Resources.Load<GameManager>("Managers/GameManager");
        Instantiate(gameManagerPrefab);
    }

    public static void Release()
    {
        if (Instance == null)
            return;

        Destroy(Instance.gameObject);
        Instance = null;
    }

    public void GameStart()
    {
        OnGameStart?.Invoke(); //이벤트도 써보기
        curState = GameState.Running;
    }

    public void GameOver()
    {
        curState = GameState.GameOver;
        OnGameEnd?.Invoke();
    }


}
