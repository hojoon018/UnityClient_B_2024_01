using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;      //XML ����ϱ� ����

public class PlayerData                   //�÷��̾� ������ ���
{
    public string playerName;
    public int playerLevel;
    public List<string> items = new List<string>();
}

public class ExXMLData : MonoBehaviour
{
    string filePath;
    
    void Start()
    {
        filePath = Application.persistentDataPath + " /PlayerData.xml";
        Debug.Log(filePath);
    }

    
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "�÷��̾� 1";
            playerData.playerLevel = 1;
            playerData.items.Add("��1");
            playerData.items.Add("����1");
            SaveData(playerData);
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();

            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            Debug.Log(playerData.items[0]);
            Debug.Log(playerData.items[1]);

        }
    }

    void SaveData(PlayerData data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        FileStream steam = new FileStream(filePath, FileMode.Create); //���Ͻ�Ʈ�� �Լ��� ���� ����
        serializer.Serialize(steam, data);                              //Ŭ���� -> XML ��ȯ �� ����
        steam.Close();
    }

    PlayerData LoadData()
    {
        if(File.Exists(filePath))
        {
            XmlSerializer serializer= new XmlSerializer(typeof(PlayerData));
            FileStream steamm = new FileStream(filePath, FileMode.Open);   //���� �б���� ���� ����
            PlayerData data = (PlayerData)serializer.Deserialize(steamm);        //XML -> Ŭ���� �о ��ȯ
            steamm.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
