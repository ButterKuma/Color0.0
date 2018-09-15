using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDataManagement : MonoBehaviour {
    public static PlayerDataManagement SingletonInstance = null;

    public static PlayerDataManagement Singleton() {

        if (!SingletonInstance)
        {
            GameObject TempSinggletonInstance = new GameObject();
            SingletonInstance = TempSinggletonInstance.AddComponent<PlayerDataManagement>();

            DontDestroyOnLoad(SingletonInstance);
        }

        return SingletonInstance;
    }
    public PlayerData NowPlayerData = new PlayerData();
    
    void Start()
    {
        
    }

    void Update() {

    }

}
//player Data Struct Class
[System.Serializable]
public class PlayerData
{

public int ID;
public string Name;
public int Level;
public int Health;
public int Damage;
public int Defence;
public int Total_EXP;
public int P_EXP;
public int Money;
public List<int> DoneQuest = new List<int>(); //진행 중 퀘스트
public List<int> FinishQuest = new List<int>(); //완료한 퀘스트
public List<int> Inventory = new List<int>(); //아이템 Inventory
public List<int> S_Position = new List<int>(); //마지막 저장 위치 0 = x, 1 = y, 2 = z, 
}
