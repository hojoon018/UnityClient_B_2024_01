using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100; //�÷��̾� ü��

    public void TakeDamage(int damage)
    {
        
        //�÷��̾� ü�� ����
        health -= damage;
        Debug.Log("�÷��̾ ü�� : " +health);

        //�÷��̾� ü���� 0 ���Ϸ� �������� �� �÷��̾� ��� ó��
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("�÷��̾ ����߽��ϴ�.");
        //��� ó�� ���� �߰�
    }
}