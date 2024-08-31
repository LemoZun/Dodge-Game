using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject readyText;
    [SerializeField] GameObject gameoverText;


    private void OnEnable()
    {
        Manager.Game.OnGameStart += HandleGameStart;
        Manager.Game.OnGameEnd += HandleGameOver;
    }

    private void OnDisable()
    {
        Manager.Game.OnGameStart -= HandleGameStart;
        Manager.Game.OnGameEnd -= HandleGameOver;
    }
    private void Start()
    {
        readyText.SetActive(true);
        gameoverText.SetActive(false);
    }

    private void HandleGameStart()
    {
        readyText.SetActive(false);
        gameoverText.SetActive(false);
    }

    private void HandleGameOver()
    {
        Debug.Log("종료확인");
        gameoverText.SetActive(true);
    }
}
