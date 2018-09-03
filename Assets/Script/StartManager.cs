using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void GameEnd() {
        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }
}
