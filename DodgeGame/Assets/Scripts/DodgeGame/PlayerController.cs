using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float moveSpeed;



    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        //RigidBody로 이동 
        rigid.velocity = new Vector3(xMovement * moveSpeed, 0, zMovement * moveSpeed);

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
}

// GetAxis : 아날로그식 범위값 (-1 ~ 1)
// GetAxisRaw : 디지털식 특정 값 (-1,0,1)