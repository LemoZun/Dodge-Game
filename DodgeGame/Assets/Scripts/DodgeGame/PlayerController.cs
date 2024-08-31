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

        //RigidBody�� �̵� 
        rigid.velocity = new Vector3(xMovement * moveSpeed, 0, zMovement * moveSpeed);

        /* GetKey�� �̵� ����
         * �̰ͺ��� �Է¸Ŵ��� ����� �� ����(�̵����� �Ҵ�� ��� Ű�� �̵� �����ϱ� ����)
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

// GetAxis : �Ƴ��α׽� ������ (-1 ~ 1)
// GetAxisRaw : �����н� Ư�� �� (-1,0,1)