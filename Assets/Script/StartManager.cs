using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class StartManager : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public RectTransform ScrollVeiwTransform;
    public InputField SetName;
    public GameObject PanelSetName;
    public GameObject ScrollView;
    public Button Item;
    public Text Laod_Name;
    public Text Laod_Level;

    // Use this for initialization
    void Awake()
    {
        SetName = GameObject.Find("InputField").GetComponent<InputField>();
        ScrollView.SetActive(false);
        PanelSetName.SetActive(false);
    }
    private void Update()
    {

    }
    public void OnClickStartButton()
    {
        Debug.Log("게임을 새로 생성합니다.");
        PanelSetName.SetActive(true);
        panelRectTransform.SetAsFirstSibling();

    }
    public void OnClickLoadButton()
    {
        StartCoroutine(LoadCo(1));
        ScrollView.SetActive(true);
        ScrollVeiwTransform.SetAsLastSibling();

    }
    public void OnClickEndButton()
    {

        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }

    IEnumerator LoadCo(int select)
    {
        string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerData.json");

        JsonData PlayerList = JsonMapper.ToObject(Jsonstring);
        Debug.Log(Jsonstring);

        yield return null;
    }
    public void OnClickCancle()
    {
        PanelSetName.SetActive(false);
        ScrollView.SetActive(false);
        panelRectTransform.SetAsLastSibling();
        ScrollVeiwTransform.SetAsLastSibling();
    }
    public void OnClickOk()
    {
        int id = 2;
        InitializeData(SetName.text, id);
    }
    public void onClickItemView() {
        Debug.Log("OK");
    }

    public void InitializeData(string name, int id)
    {
        Debug.Log(id + name); //체크용
        PlayerDataManagement.Singleton().NowPlayerData.ID = id;
        PlayerDataManagement.Singleton().NowPlayerData.Name = name;
        PlayerDataManagement.Singleton().NowPlayerData.Level = 1;
        PlayerDataManagement.Singleton().NowPlayerData.Health = 100;
        PlayerDataManagement.Singleton().NowPlayerData.Damage = 10;
        PlayerDataManagement.Singleton().NowPlayerData.Defence = 15;
        PlayerDataManagement.Singleton().NowPlayerData.Total_EXP = 400;
        PlayerDataManagement.Singleton().NowPlayerData.P_EXP = 0;
        PlayerDataManagement.Singleton().NowPlayerData.Money = 0;
        PlayerDataManagement.Singleton().NowPlayerData.DoneQuest.Clear();
        PlayerDataManagement.Singleton().NowPlayerData.FinishQuest.Clear();
        PlayerDataManagement.Singleton().NowPlayerData.Inventory.Clear();
        PlayerDataManagement.Singleton().NowPlayerData.S_Position.Clear();
    }

}