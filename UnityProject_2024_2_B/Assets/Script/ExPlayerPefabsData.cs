using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayerPefabsData : MonoBehaviour
{
    public int scorePoint;
    void SaveData(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }


    int LoadData()
    {
        return PlayerPrefs.GetInt("Score");
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            SaveData(scorePoint);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("Score : "+LoadData());
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("Score");
        }
    }
}
