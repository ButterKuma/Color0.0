using LitJson;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public InputField SetName;
    public GameObject PanelSetName;

    // Use this for initialization
    void Awake()
    {
        SetName = GameObject.Find("InputField").GetComponent<InputField>();
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
        SceneManager.LoadScene(1);
        PlayerDataManagement.Singleton().PlayerDataLoad();
    }
    public void OnClickEndButton()
    {

        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }


    public void OnClickCancle()
    {
        PanelSetName.SetActive(false);
        panelRectTransform.SetAsLastSibling();
    }
    public void OnClickOk()
    {
        int id = ((int)Random.Range(100.0f,999.0f)*2)/5;
        Debug.Log(SetName.text + id);
        InitializeData(SetName.text, id);
        SceneManager.LoadScene(1);
    }
    public void OnClickItemView() {
        SceneManager.LoadScene(1);
    }

    public void InitializeData(string name, int id)
    {
        PlayerDataManagement.Singleton().NowPlayerData.ID = id;
        PlayerDataManagement.Singleton().NowPlayerData.Name = name;
        PlayerDataManagement.Singleton().NowPlayerData.Level = 1;
        PlayerDataManagement.Singleton().NowPlayerData.Health = 100;
        PlayerDataManagement.Singleton().NowPlayerData.Damage = 10;
        PlayerDataManagement.Singleton().NowPlayerData.Defence = 15;
        PlayerDataManagement.Singleton().NowPlayerData.Total_EXP = 400;
        PlayerDataManagement.Singleton().NowPlayerData.P_EXP = 0;
        PlayerDataManagement.Singleton().NowPlayerData.Money = 0;
        PlayerDataManagement.Singleton().NowPlayerData.S_pos[0] = 100.0f; //x축
        PlayerDataManagement.Singleton().NowPlayerData.S_pos[1] = 0.5f; //y축
        PlayerDataManagement.Singleton().NowPlayerData.S_pos[2] =70.0f; //z축
        PlayerDataManagement.Singleton().PlayerDataSave();
        PlayerDataManagement.Singleton().PlayerDataLoad();
    }
}