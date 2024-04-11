using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXEnemy : MonoBehaviour
{
    public ExPlayer targetPlayer;

    public int damage = 20;

    public void AttackPlayer(ExPlayer player)
    {
        player.TakeDamage(damage);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�÷��̾� ����");
            if ((targetPlayer != null))
            {
                AttackPlayer(targetPlayer);
            }
        }
        
    }
}
