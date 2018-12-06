using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class PlayerDataManagement : MonoBehaviour {
    public static PlayerDataManagement SingletonInstance = null;
    public GameObject Player;
    public GameObject PlayerPrefab;
    public bool life = true;

    public static PlayerDataManagement Singleton() {

        if (!SingletonInstance)
        {
            GameObject TempSingletonInstance = new GameObject();
            SingletonInstance = TempSingletonInstance.AddComponent<PlayerDataManagement>();

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
    public void CreateData(string name)
    {
        Singleton().NowPlayerData.ID = (int)(Random.Range(100.0f, 999.0f) * 2) / 5;
        Singleton().NowPlayerData.Name = name;
        Singleton().NowPlayerData.Level = 1;
        Singleton().NowPlayerData.Health = 100;
        Singleton().NowPlayerData.Damage = 10;
        Singleton().NowPlayerData.Defence = 15;
        Singleton().NowPlayerData.Total_EXP = 800;
        Singleton().NowPlayerData.P_EXP = 0;
        Singleton().NowPlayerData.Money = 0;
        Singleton().NowPlayerData.SavePos = "99.85/-0.8710034/65.54";

        StartCoroutine(CreatePlayer());
    }
    IEnumerator CreatePlayer()
    {
        SceneManager.LoadScene(1);

        SaveData();

        yield return null;
    }
    IEnumerator Load() {

        string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerData.json");
        JsonData UserData = JsonMapper.ToObject(Jsonstring);
        Debug.Log(UserData);

        Singleton().NowPlayerData.ID = int.Parse(UserData["ID"].ToString());
        Singleton().NowPlayerData.Name = UserData["Name"].ToString();
        Singleton().NowPlayerData.Level = int.Parse(UserData["Level"].ToString());
        Singleton().NowPlayerData.Health = int.Parse(UserData["Health"].ToString());
        Singleton().NowPlayerData.Damage = int.Parse(UserData["Damage"].ToString());
        Singleton().NowPlayerData.Defence = int.Parse(UserData["Defence"].ToString());
        Singleton().NowPlayerData.Total_EXP = int.Parse(UserData["Total_EXP"].ToString());
        Singleton().NowPlayerData.P_EXP = int.Parse(UserData["P_EXP"].ToString());
        Singleton().NowPlayerData.Money = int.Parse(UserData["Money"].ToString());
        Singleton().NowPlayerData.SavePos = UserData["SavePos"].ToString();


        yield return null;
    }
    public void SaveData()
    {

        JsonData PlayerData = JsonMapper.ToJson(Singleton().NowPlayerData);
        File.WriteAllText(Application.dataPath + "/Resources/Data/PlayerData.json", PlayerData.ToString());
    }
    public void LoadData()
    {
        string Files = Application.dataPath + "/Resources/Data/PlayerData.json";
        FileInfo fi = new FileInfo(Files);
        if (fi.Exists) {
            SceneManager.LoadScene(1);
            StartCoroutine(Load());
        }
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
    public string SavePos;
}
