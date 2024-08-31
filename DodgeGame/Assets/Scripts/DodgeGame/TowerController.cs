using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] PooledObject bulletPrefab;
    [SerializeField] Transform targetPosition;
    [SerializeField] float bulletSpawnPeriod;
    
    private Coroutine bulletSpawnRoutine;

    private void Start()
    {
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //targetPosition = playerObj.GetComponent<Transform>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(bulletSpawnRoutine == null)
            {
                bulletSpawnRoutine = StartCoroutine(BulletSpawn());
            }
        }
        else if(Input.GetKeyDown(KeyCode.G))
        {
            if(bulletSpawnRoutine != null)
            {
                StopCoroutine(bulletSpawnRoutine);
                bulletSpawnRoutine = null;
            }
          
        }
    }

    IEnumerator BulletSpawn()
    {
        WaitForSecondsRealtime delay = new WaitForSecondsRealtime(bulletSpawnPeriod);
        while(true)
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


            //Instantiate(bulletPrefab,transform.position,transform.rotation);

        }
    }
}
