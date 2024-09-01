using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PooledObject pooledObject;
    [SerializeField] Transform targetPosition;    
    [SerializeField] float bulletSpeed;
    private Vector3 direction;
    

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        direction = (target.transform.position - transform.position).normalized;

        Manager.Game.OnGameEnd += pooledObject.ReturnPool;
        Manager.Game.OnGameClear += pooledObject.ReturnPool;

    }
    
    private void OnDisable()
    {
        Manager.Game.OnGameEnd -= pooledObject.ReturnPool;
        Manager.Game.OnGameClear -= pooledObject.ReturnPool;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Field"))
        {
            pooledObject.ReturnPool();
            //Debug.Log("필드와 충돌해서 총알 사라짐");
        }
        else if(collision.gameObject.tag == ("Player"))
        {
            pooledObject.ReturnPool();
            Manager.Game.GameOver();
            Debug.Log("게임 오버!");
        }
    }



    private void Update()
    {
        //if(Manager.Game.curState == GameManager.GameState.Running)
        {
            transform.Translate(direction * bulletSpeed * Time.deltaTime);
        }
        
    }

    // direction = (GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
    // 처음엔 이렇게 썼지만 플레이어의 위치를 찾지 못하는 문제가 생겼다.
    // 벡터 정규화 괄호를 잘못 친거같았는데 
    // 총알이 생성되는 위치가 타워에서 생성되니까 플레이어와 타워의 상대적인 방향을 줘야 제대로 찾아간다.
}
