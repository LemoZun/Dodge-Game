using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZoneController : MonoBehaviour
{
    [SerializeField] GameObject clearzone;
    [SerializeField] float activationTime;
    Coroutine activeRoutine;

    private void Awake()
    {
        activationTime = 5f;
    }
    private void Start()
    {
        clearzone = GameObject.FindWithTag("Respawn");
    }

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

    private void HandleGameStart()
    {
        SetClearzone();
    }

    private void HandleGameOver()
    {
        if(clearzone != null)
            clearzone.SetActive(false);
    }

    private void SetClearzone()
    {
        if (clearzone != null)
            clearzone.SetActive(false);
        if (activeRoutine == null)
            activeRoutine = StartCoroutine(ActivateRoutine());
    }

    IEnumerator ActivateRoutine()
    {
        yield return new WaitForSeconds(activationTime);
        if(clearzone != null)
            clearzone.SetActive(true);
        if(activeRoutine != null)
            activeRoutine = null;
    }
}
