using System.Collections;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] PooledObject bulletPrefab;
    [SerializeField] Transform targetPosition;
    [SerializeField] float bulletSpawnPeriod;
    [SerializeField] bool isAttacking;

    private Coroutine bulletSpawnRoutine;

    private void Awake()
    {
        isAttacking = false;

    }

    private void Start()
    {
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //targetPosition = playerObj.GetComponent<Transform>();
    }



    private void Update()
    {

        CheckGameState();

        if (isAttacking == false)
            return;
    }

    private void CheckGameState()
    {
        GameManager.GameState state;
        state = Manager.Game.curState;

        if (state == GameManager.GameState.Running)
            StartAttack();
        else if (state == GameManager.GameState.Ready || state == GameManager.GameState.GameOver)
            StopAttack();
    }

    private void StartAttack()
    {
        isAttacking = true;
        if (bulletSpawnRoutine == null)
        {
            bulletSpawnRoutine = StartCoroutine(BulletSpawn());
        }
    }

    private void StopAttack()
    {
        isAttacking = false;
        if (bulletSpawnRoutine != null)
        {
            StopCoroutine(bulletSpawnRoutine);
            bulletSpawnRoutine = null;
        }
    }

    IEnumerator BulletSpawn()
    {
        if (isAttacking == false)
        {
            yield return null;
        }


        WaitForSecondsRealtime delay = new WaitForSecondsRealtime(bulletSpawnPeriod);
        while (true)
        {

            yield return delay;
            PooledObject spawnedBullet = bulletPool.GetPool(transform.position, transform.rotation);

            if (spawnedBullet != null)
            {
                Debug.Log("醚舅 积己");
            }
            else
            {
                Debug.Log("醚舅 积己 救凳");
            }
        }
    }
}
