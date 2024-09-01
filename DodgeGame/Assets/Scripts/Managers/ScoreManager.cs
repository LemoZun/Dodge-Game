using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    float startTime;
    float clearTime;
    float bestClearTime;
    float criticalPoint = 5f;

    Coroutine ScroeRoutine;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Instance.bestClearTime = 0;
    }

    private void Start()
    {
        Manager.Game.OnGameStart += HandleGameStart;
        Manager.Game.OnGameEnd += HandleGameOver;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        Manager.Game.OnGameStart -= HandleGameStart;
        Manager.Game.OnGameEnd -= HandleGameOver;
    }

    public static void Create()
    {
        ScoreManager scoreManagerPrefab = Resources.Load<ScoreManager>("Managers/ScoreManager");
        Instantiate(scoreManagerPrefab);
    }

    private void HandleGameStart()
    {
        clearTime =0;
        startTime = Time.time;
    }

    private void HandleGameOver()
    {
        clearTime = Time.time-startTime;
        int minutes = (int)(clearTime / 60f);
        int seconds = (int)(clearTime % 60f);
        Debug.Log($"버틴 시간은 {clearTime}");
        Debug.Log($"{minutes}분 {seconds}초");
        if(bestClearTime != 0)
            Debug.Log($"현재 베스트 클리어 시간 : {bestClearTime}");
    }
    private void HandleGameClear()
    {
        clearTime = Time.time - startTime;
        int minutes = (int)(clearTime / 60f);
        int seconds = (int)(clearTime % 60f);
        Debug.Log($"클리어 시간은 {clearTime}");
        Debug.Log($"{minutes}분 {seconds}초");
        Debug.Log($"현재 베스트 클리어 시간 : {bestClearTime}");
        if (clearTime < bestClearTime)            
            RecordScore();
    }

    private void RecordScore()
    {
        bestClearTime = clearTime;
        int minutes = (int)(clearTime/60f);
        int seconds = (int)(clearTime%60f);
        Debug.Log($"베스트 스코어 갱신, 클리어 시간은 {clearTime}");
        Debug.Log($"{minutes}분 {seconds}초");

    }
}
