using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    const float INF = 999f;
    float startTime;
    private float clearTime;
    public float ClearTime { get; private set; }
    private float bestClearTime;
    public float BestClearTime { get; private set; }
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
        Instance.bestClearTime = INF;
    }

    private void Start()
    {
        Manager.Game.OnGameStart += HandleGameStart;
        Manager.Game.OnGameEnd += HandleGameOver;
        Manager.Game.OnGameClear += HandleGameClear;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        Manager.Game.OnGameStart -= HandleGameStart;
        Manager.Game.OnGameEnd -= HandleGameOver;
        Manager.Game.OnGameClear -= HandleGameClear;
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
        Debug.Log($"��ƾ �ð��� {clearTime}");
        Debug.Log($"{minutes}�� {seconds}��");
        if(bestClearTime != 0)
            Debug.Log($"���� ����Ʈ Ŭ���� �ð� : {bestClearTime}");
    }
    private void HandleGameClear()
    {
        clearTime = Time.time - startTime;
        int minutes = (int)(clearTime / 60f);
        int seconds = (int)(clearTime % 60f);
        Debug.Log($"Ŭ���� �ð��� {clearTime}");
        Debug.Log($"{minutes}�� {seconds}��");
        Debug.Log($"���� ����Ʈ Ŭ���� �ð� : {bestClearTime}");
        if (clearTime < bestClearTime)            
            RecordScore();
    }

    private void RecordScore()
    {
        bestClearTime = clearTime;
        int minutes = (int)(clearTime/60f);
        int seconds = (int)(clearTime%60f);
        Debug.Log($"����Ʈ ���ھ� ����, Ŭ���� �ð��� {clearTime}");
        Debug.Log($"{minutes}�� {seconds}��");

    }
}
