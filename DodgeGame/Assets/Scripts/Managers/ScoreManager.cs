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
