using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager
{
    public static GameManager Game { get { return GameManager.Instance; } }
    public static ScoreManager Score { get { return ScoreManager.Instance; }}
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    private static void Initialize()
    {
        GameManager.Create();
        ScoreManager.Create();
    }
}
