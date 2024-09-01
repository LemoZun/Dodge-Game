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
            //Debug.Log("�ʵ�� �浹�ؼ� �Ѿ� �����");
        }
        else if(collision.gameObject.tag == ("Player"))
        {
            pooledObject.ReturnPool();
            Manager.Game.GameOver();
            Debug.Log("���� ����!");
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
    // ó���� �̷��� ������ �÷��̾��� ��ġ�� ã�� ���ϴ� ������ �����.
    // ���� ����ȭ ��ȣ�� �߸� ģ�Ű��Ҵµ� 
    // �Ѿ��� �����Ǵ� ��ġ�� Ÿ������ �����Ǵϱ� �÷��̾�� Ÿ���� ������� ������ ��� ����� ã�ư���.
}
