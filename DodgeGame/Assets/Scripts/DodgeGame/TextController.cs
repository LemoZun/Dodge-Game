using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject readyText;
    [SerializeField] GameObject gameoverText;
    [SerializeField] GameObject gameClearText;
    [SerializeField] Text scoreText;
    int curMin;
    int curSecond;
    int bestMin;
    int bestSecond;
    ScoreManager scoreManager;


    private void OnEnable()
    {
        Manager.Game.OnGameStart += HandleGameStart;
        Manager.Game.OnGameEnd += HandleGameOver;
        Manager.Game.OnGameClear += HandleGameClear;

    }

    private void OnDisable()
    {
        Manager.Game.OnGameStart -= HandleGameStart;
        Manager.Game.OnGameEnd -= HandleGameOver;
        Manager.Game.OnGameClear -= HandleGameClear;
    }
    private void Start()
    {
        
        
        //bestMin = (int)scoreManager.BestClearTime / 60;
        //bestSecond = (int)scoreManager.BestClearTime % 60;
        //scoreText.text = ($"���� ��� : \n�ְ� ��� : {bestMin} : {bestSecond}");
        // �̰� ��ü ��� �ϴ°���?


        readyText.SetActive(true);
        gameoverText.SetActive(false);
        gameClearText.SetActive(false);
    }
    private void Update()
    {
        
    }


    private void HandleGameStart()
    {
        readyText.SetActive(false);
        gameoverText.SetActive(false);
        gameClearText.SetActive(false);
    }

    private void HandleGameOver()
    {
        gameoverText.SetActive(true);
    }

    private void HandleGameClear()
    {

        gameClearText.SetActive(true);

    }
}
