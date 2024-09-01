using System.Collections;
using UnityEngine;

public class ClearZoneController : MonoBehaviour
{
    [SerializeField] GameObject clearzone;
    [SerializeField] float activationTime = 20;
    private float minPositionX;
    private float minPositionZ;
    private float maxPositionX;
    private float maxPositionZ;
    Coroutine activeRoutine;



    private void Awake()
    {
        minPositionX = -4f;
        maxPositionX = 4f;
        minPositionZ = -4f;
        maxPositionZ = 4f;


    }
    private void Start()
    {
        clearzone = GameObject.FindWithTag("Respawn");
        PlaceClearZone();
        OFFClearZone();
    }

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

    private void HandleGameStart()
    {
        SetClearzone();
    }

    private void HandleGameOver()
    {
        OFFClearZone();
        StopActiveRoutine();
    }
    private void HandleGameClear()
    {
        OFFClearZone();
        StopActiveRoutine();
    }

    private void SetClearzone()
    {
        OFFClearZone();

        StopActiveRoutine();

        if (activeRoutine == null)
            activeRoutine = StartCoroutine(ActivateRoutine());
    }

    private void OFFClearZone()
    {
        if (clearzone != null)
            clearzone.SetActive(false);
    }

    private void PlaceClearZone()
    {
        float randomX = UnityEngine.Random.Range(minPositionX, maxPositionX);
        float randomZ = UnityEngine.Random.Range(minPositionZ, maxPositionZ);
        clearzone.transform.position = new Vector3(randomX, 1.2f, randomZ);
    }

    IEnumerator ActivateRoutine()
    {
        yield return new WaitForSeconds(activationTime);
        if (Manager.Game.curState == GameManager.GameState.Running)
        {
            if (clearzone != null)
            {
                clearzone.SetActive(true);
                PlaceClearZone();
            }
            

            if (activeRoutine != null)
                activeRoutine = null;
        }
    }

    private void StopActiveRoutine()
    {
        if (activeRoutine != null)
        {
            StopCoroutine(activeRoutine);
            activeRoutine = null;
        }
    }

}
