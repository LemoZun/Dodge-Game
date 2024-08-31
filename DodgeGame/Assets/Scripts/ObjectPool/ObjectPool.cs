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

// 배열과 리스트로도 오브젝트 풀을 구현하려 했으나, 지금상황에선 그냥 알아서 마지막요소나 첫 요소를 빼서 쓰는 스택이나 큐가 더 편하다
// 그럼 배열이나 리스트를 쓰면 좋은 상황은 뭐가 있을까
// 고정자리에 스폰되는 특정한 몬스터 전용 칸을 필요료 할 경우 풀의 특정 자리에만 리턴되도록 해서 쓰기? 


