using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour {
	// Use this for initialization
	void Start () {

    }
    public void GameStart() {
        int id = 0; // 임시값 0
        string name = null;

        Debug.Log("게임을 새로 생성합니다.");

        playerData data = new playerData(name,id);
    }
    public void GameEnd() {
        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }

    public void LoadGame() {

    }
}
