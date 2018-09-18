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
    public Player NowPlayerData = new Player();
    

    void Start()
    {
        
    }

    void Update() {

    }
    public void PlayerDataSave() {
        Debug.Log("저장");
        SaveCo();
    }
    public void PlayerDataLoad()
    {
        StartCoroutine(LoadPlayerData());
    }
    private void SaveCo() {
        string spos = Singleton().NowPlayerData.S_pos[0] + "/" + Singleton().NowPlayerData.S_pos[1] + "/" + Singleton().NowPlayerData.S_pos[2];
        string inventory = "0/1";
        string DoneQuest = "0/1";
        string FinishQuest = "0/1";

        PlayerManagement User = new PlayerManagement(Singleton().NowPlayerData.ID, Singleton().NowPlayerData.Name, Singleton().NowPlayerData.Level, Singleton().NowPlayerData.Health, Singleton().NowPlayerData.Damage, Singleton().NowPlayerData.Defence, Singleton().NowPlayerData.Total_EXP, Singleton().NowPlayerData.P_EXP, Singleton().NowPlayerData.Money,spos);
        JsonData Player = JsonMapper.ToJson(User);

        File.WriteAllText(Application.dataPath  + "/Resources/Data/PlayerData.json", Player.ToString());
    }
    IEnumerator LoadPlayerData() {
        string JsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerData.json");

        JsonData PlayerData = JsonMapper.ToObject(JsonString);

        CreatePlyaer(PlayerData);
        yield return null;
    }

    public GameObject PlayerPrefab;

    private void CreatePlyaer(JsonData name) {
        Debug.Log(name["ID"].ToString());

        string[] spos = name["spos"].ToString().Split('/');

        Singleton().NowPlayerData.ID = int.Parse(name["ID"].ToString());
        Singleton().NowPlayerData.Name = name["Name"].ToString();
        Singleton().NowPlayerData.Level = int.Parse(name["Level"].ToString());
        Singleton().NowPlayerData.Damage = int.Parse(name["Health"].ToString());
        Singleton().NowPlayerData.Damage = int.Parse(name["Damage"].ToString());
        Singleton().NowPlayerData.Defence = int.Parse(name["Defence"].ToString());
        Singleton().NowPlayerData.Total_EXP = int.Parse(name["Total_EXP"].ToString());
        Singleton().NowPlayerData.P_EXP = int.Parse(name["P_EXP"].ToString());
        Singleton().NowPlayerData.Money = int.Parse(name["Money"].ToString());
        Singleton().NowPlayerData.S_pos[0] = int.Parse(spos[0]);
        Singleton().NowPlayerData.S_pos[1] = int.Parse(spos[1]);
        Singleton().NowPlayerData.S_pos[2] = int.Parse(spos[2]);



        Vector3 TmpPos = new Vector3(float.Parse(spos[0]), float.Parse(spos[1]), float.Parse(spos[2])); // x, y, z

        GameObject Player = Instantiate(PlayerPrefab, TmpPos, Quaternion.identity);
        Debug.Log("Create");
    }
}


//player Data Struct Class
[System.Serializable]
public class Player
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
    public float[] S_pos = new float[3];
}
