using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class StartManager : MonoBehaviour{
    public Text Temp;
    public RectTransform panelRectTransform;
    public InputField SetName;
    public GameObject PanelSetName;

    // Use this for initialization
    void Awake() {
        Temp = GameObject.Find("Text").GetComponent<Text>();
        SetName = GameObject.Find("InputField").GetComponent<InputField>();
        PanelSetName.SetActive(false);
    }
    private void Update()
    {
        
    }
    public void OnClickStartButton() {
        StartCoroutine(StartCo());
        
    }
    public void OnClickLoadButton() {
        StartCoroutine(LoadCo());
        SceneManager.LoadScene(1);

    }
    public void OnClickEndButton() {

        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }

    IEnumerator LoadCo()
    {
        string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerData.json");

        JsonData PlayerList = JsonMapper.ToObject(Jsonstring);
        ExchangText(Jsonstring);

        yield return null;
    }
    IEnumerator StartCo() {
        
        Debug.Log("게임을 새로 생성합니다.");
        PanelSetName.SetActive(true);
        panelRectTransform.SetAsFirstSibling();

        yield return null;
    }

    public void ExchangText(string text) {
        Temp.text = text;
    }
    public void OnClickCancle() {
        panelRectTransform.SetAsLastSibling();
    }
    public void OnClickOk() {
        Debug.Log(SetName.text);
    }
}
