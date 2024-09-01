using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        Manager.Game.OnGameEnd += StopMove;
    }

    private void OnDestroy()
    {
        Manager.Game.OnGameEnd -= StopMove;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Manager.Game.curState == GameManager.GameState.Running)
        {
            Move();
        }
        
    }

    private void Move()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        //RigidBody로 이동 (정규화 적용) 
        Vector3 moveDir = new Vector3(xMovement, 0, zMovement);
        if(moveDir.magnitude > 1) 
        {
            moveDir.Normalize();
        }
        rigid.velocity = moveDir*moveSpeed;
        /* GetKey로 이동 구현
         * 이것보단 입력매니저 사용이 더 좋다(이동으로 할당된 모든 키로 이동 가능하기 때문)
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        */
    }

    private void StopMove()
    {
        rigid.velocity = Vector3.zero; 
        rigid.position = new Vector3(0,1,0);

       //rigid.rotation = Quaternion.identity;
       //회전초기화는 당장은 필요 없지만 이건 뭐지?
    }
}

// GetAxis : 아날로그식 범위값 (-1 ~ 1)
// GetAxisRaw : 디지털식 특정 값 (-1,0,1)
// 정규화 예시
// Vector3 moveDir = new Vector3(xMovement, 0, zMovement);
// moveDir.Normalize();

// rigid.velocity = new Vector3(xMovement * moveSpeed, 0, zMovement * moveSpeed).normalized ; 
// 이러면 최종결과가 정규화되서 moveSpeed값이 의미가 없어짐

// 리지드 바디
// AddFore, AddTorque, velocity, angularVelocity
// magnitude : 벡터의 크기