using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memo : MonoBehaviour
{
    //�������� �̺�Ʈ ����
    //���ӽ��� �̺�Ʈ ����

    //���ӽ��۽� �÷��̾� ��ġ �ʱ�ȭ
    //�� �÷��̾�� ���� �ٲ��� �ʴ��̻� �׻� Ȱ��ȭ���·� �ִ�
    //�� �׷� onenable�� ondisable�� �̺�Ʈ ���������� �ϴ°ͺ��� start�� ondestroy���� ���ִ°� ���� ������?
    //rigid.velocity�� vector3.(0,0,0)�� �����Ϸ��ߴ��� �ȵǼ� ZERO�� �ߴ�
    //�� ���̰� �ִٴ°� �˰ڴµ� ��Ȯ�� �𸣰ڳ�.. �ν����� �󿡼� velocity�� xyz���� ����3�� �޴µ�
    //�� new Vector3�� ���ִ� �Ǳ� �ϴµ� �׷� �� �� Vector.zero�� �Ǵ°���? �̰͵� new Vector3.zero �ؾ��ϴ°� �ƴѰ�
    //�� �̹��� ȸ���ʱ�ȭ�� �̹��� �𵨸��� �ܼ��ؼ� �ʿ� ����
    //�� �ڵ��ϼ����� rigid.rotation = Quaternion.identity; �� �����µ� ȸ���̴� ���ʹϾ� ���°� ���ذ� �Ǵµ� identity�� ����
    //�� Quaternion.Euler ������� �˾Ҵµ�
    //���� ����� �Ѿ� �� �����

    // ���� ���۽� �ð� ����
    // 20�� ����� Ŭ������ Ȱ��ȭ
    // best score ����
    // �ǰݵǾ� ������ ������� ����ð� ���x

    //�����ӿ� ���� ����ð��� ���� �ʿ�� ������ deltaTime ���� �׳� Time�� ����ҰŰ�����

}
