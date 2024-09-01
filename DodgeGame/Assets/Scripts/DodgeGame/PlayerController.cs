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
        //RigidBody�� �̵� (����ȭ ����) 
        Vector3 moveDir = new Vector3(xMovement, 0, zMovement);
        if(moveDir.magnitude > 1) 
        {
            moveDir.Normalize();
        }
        rigid.velocity = moveDir*moveSpeed;
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

    private void StopMove()
    {
        rigid.velocity = Vector3.zero; 
        rigid.position = new Vector3(0,1,0);

       //rigid.rotation = Quaternion.identity;
       //ȸ���ʱ�ȭ�� ������ �ʿ� ������ �̰� ����?
    }
}

// GetAxis : �Ƴ��α׽� ������ (-1 ~ 1)
// GetAxisRaw : �����н� Ư�� �� (-1,0,1)
// ����ȭ ����
// Vector3 moveDir = new Vector3(xMovement, 0, zMovement);
// moveDir.Normalize();

// rigid.velocity = new Vector3(xMovement * moveSpeed, 0, zMovement * moveSpeed).normalized ; 
// �̷��� ��������� ����ȭ�Ǽ� moveSpeed���� �ǹ̰� ������

// ������ �ٵ�
// AddFore, AddTorque, velocity, angularVelocity
// magnitude : ������ ũ��