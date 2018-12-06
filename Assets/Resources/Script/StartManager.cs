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
        SetName.text = null;
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
        PlayerDataManagement.Singleton().LoadData();
    }
    public void OnClickEndButton()
    {

        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }


    public void OnClickCancle()
    {
        SetName.text = null;
        PanelSetName.SetActive(false);
        panelRectTransform.SetAsLastSibling();
    }
    public void OnClickOk()
    {
        PlayerDataManagement.Singleton().CreateData(SetName.text);
    }
}