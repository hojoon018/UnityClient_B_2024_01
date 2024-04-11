using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExEnemyManager : MonoBehaviour
{
    public List<EXEnemy> enemies = new List<EXEnemy>();

    // Start is called before the first frame update
    void Start()
    {
        var sortedEnemies = enemies.OrderBy(EXEnemy => EXEnemy.damage);

        foreach(var enemy in sortedEnemies)
        {
            Debug.Log("Sorted Enemy : " + enemy.gameObject.name + " Damage : " + enemy.damage);
        }

        // Ư�� �Ÿ� �̳��� �� ĳ���� ����
        float maxDistance = 10f;
        var closeEnemies = enemies.Where(enemy => Vector3.Distance(enemy.transform.position, transform.position) < maxDistance);

        foreach(var enemy in closeEnemies)
        {
            Debug.Log("Close Enemies : " + enemy.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
