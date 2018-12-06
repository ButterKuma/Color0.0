using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManger : MonoBehaviour {
    public GameObject MenuPanel;
    public GameObject Player;
    public Slider HpG;
    public Text HPTxt;

	// Use this for initialization
	void Start () {
        MenuPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // if (Application.platform == RuntimePlatform.WindowsPlayer)
            StartCoroutine(HPGauge());
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
        Vector3 Pos = Player.transform.position;
        
        string position = Pos.x.ToString() + '/' + Pos.y.ToString() + '/' + Pos.z.ToString();
        PlayerDataManagement.Singleton().NowPlayerData.Health = 100;
       PlayerDataManagement.Singleton().NowPlayerData.SavePos = position;
        PlayerDataManagement.Singleton().SaveData();
    }
    public void GotoMain() {
        Save();
        SceneManager.LoadScene("Start");
    }
    public void OnExit()
    {
        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }
    IEnumerator HPGauge() {

        int HP = PlayerDataManagement.Singleton().NowPlayerData.Health;
        HpG.value = HP;
        HPTxt.text =  "HP "+HP.ToString()+"/"+"100";
        yield return null;
    }
}
