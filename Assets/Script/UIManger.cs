using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour {
    public GameObject MenuPanel;
	// Use this for initialization
	void Start () {
        MenuPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       // if (Application.platform == RuntimePlatform.WindowsPlayer)
            if(MenuPanel.activeInHierarchy != true) {
                if (Input.GetKeyDown(KeyCode.Escape))
                  MenuPanel.SetActive(true);
              }
            else if (MenuPanel.activeInHierarchy != false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                   MenuPanel.SetActive(false);
        }
    }

    public void Save()
    {
        PlayerDataManagement SaveControll = new PlayerDataManagement();
        SaveControll.PlayerDataSave();
    }
    public void OnExit()
    {
        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }
}
