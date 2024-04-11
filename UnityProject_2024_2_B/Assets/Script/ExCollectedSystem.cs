using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExItem
{
    public bool IsCollected; //ȹ�� ����
}

public class ExCollectedSystem : MonoBehaviour
{
    public List<ExItem> collectedItem = new List<ExItem>();    // �÷��� �� ����Ʈ


    void Start()
    {
        collectedItem.Add(new ExItem());
        collectedItem.Add(new ExItem());
        collectedItem[0].IsCollected = true;
        collectedItem[1].IsCollected = false;
        CheckAllItemsCollected();
    }

    void CheckAllItemsCollected()
    {
        if(collectedItem.TrueForAll(item=> item.IsCollected)) //��� �������� ���� �Ǿ����� �˻�
        {
            Debug.Log("All items collected ");
        }
        else
        {
            Debug.Log("Not all items collected! ");
        }
    }

    
}
