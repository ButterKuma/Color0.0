using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using LitJson;
using System.IO;

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
        Debug.Log(NowPlayerData.Name);
        Debug.Log(NowPlayerData.ID);
        Debug.Log(NowPlayerData.Level);
        Debug.Log(NowPlayerData.Health);
        Debug.Log(NowPlayerData.Damage);
        Debug.Log(NowPlayerData.Defence);
        Debug.Log(NowPlayerData.Total_EXP);
        Debug.Log(NowPlayerData.P_EXP);
        Debug.Log(NowPlayerData.Money);
        Debug.Log(NowPlayerData.DoneQuest);
        Debug.Log(NowPlayerData.FinishQuest);
        Debug.Log(NowPlayerData.Inventory);

    }
    public void PlayerDataSave() {
        Debug.Log("저장");
        SaveCo();
    }
    private void SaveCo() {

        JsonData Player = JsonMapper.ToJson(Singleton().NowPlayerData);

        File.WriteAllText(Application.dataPath  + "/Resources/Data/PlayerData.json", Player.ToString());
    }
    IEnumerator LoadPlayerData() {
        string JsonString = File.ReadAllText(Application.dataPath + "/ Resources / Data / PlayerData.json");
        Debug.Log("DataLoad");

        JsonData PlayerData = JsonMapper.ToObject(JsonString);

        GetPlayerInfo(PlayerData);
        yield return null;
    }
    private void GetPlayerInfo(JsonData name) {
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
}
