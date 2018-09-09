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
        ScrollView.SetActive(false);
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
        StartCoroutine(LoadCo());
        ScrollView.SetActive(true);
        ScrollVeiwTransform.SetAsFirstSibling();
    }
    public void OnClickEndButton()
    {

        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }

    IEnumerator LoadCo()
    {
        string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerData.json");

        JsonData PlayerList = JsonMapper.ToObject(Jsonstring);
        yield return null;
    }
    public void OnClickCancle()
    {
        PanelSetName.SetActive(false);
        panelRectTransform.SetAsLastSibling();
    }
    public void OnClickOk()
    {

        Debug.Log(SetName.text);
    }
}