using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;


public class ObjectPool : MonoBehaviour
{
    [SerializeField] PooledObject prefab;
    [SerializeField] int capacity;

    private Queue<PooledObject> pool;

    private void Awake()
    {
        pool = new Queue<PooledObject> (capacity);
        for(int i = 0; i < capacity; i++)
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            instance.Pool = this;
            pool.Enqueue(instance);
        }
    }

    public PooledObject GetPool(Vector3 position, Quaternion rotation)
    {
        if(pool.Count > 0)
        {
            PooledObject instance = pool.Dequeue();
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.gameObject.SetActive(true);
            return instance;
        }
        else
        {
            return null;
        }
    }

    public void ReturnPool(PooledObject _instance)
    {
        if(pool.Count < capacity)
        {
            _instance.gameObject.SetActive(false);
            pool.Enqueue(_instance);
        }
        else
        {
            Destroy(_instance.gameObject);
        }
    }


}

// �迭�� ����Ʈ�ε� ������Ʈ Ǯ�� �����Ϸ� ������, ���ݻ�Ȳ���� �׳� �˾Ƽ� ��������ҳ� ù ��Ҹ� ���� ���� �����̳� ť�� �� ���ϴ�
// �׷� �迭�̳� ����Ʈ�� ���� ���� ��Ȳ�� ���� ������
// �����ڸ��� �����Ǵ� Ư���� ���� ���� ĭ�� �ʿ�� �� ��� Ǯ�� Ư�� �ڸ����� ���ϵǵ��� �ؼ� ����? 

