using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject prefab;
    public GameObject Player;
    public GameObject Reset;
    public int cnt;
    public List<GameObject> EnemyList = new List<GameObject>(); //enemy Data Save


    // Use this for initialization
    void Start()
    {
        Player = Resources.Load<GameObject>("Prefabs/" + "Player");
        OnCreate();
        PlayerCreate(); ;
    }
    void Update()
    {
        if (PlayerDataManagement.Singleton().life !=true)
        {
            Debug.Log(PlayerDataManagement.Singleton().life);
            On_Respawn();
        }     
    }
    public  void OnCreate() {
        GameObject tmpObj = null;
        for (cnt =0; cnt < 10; cnt++)
        {
            tmpObj = Instantiate(prefab, new Vector3(93.9f, 0.5f, 149.3f), Quaternion.identity) as GameObject;
            EnemyList.Add(tmpObj);
        }
    }
    public void EnemyReset()
    {
        GameObject tmpObj = null;
        tmpObj = Instantiate(prefab, new Vector3(93.9f, 0.5f, 149.3f), Quaternion.identity) as GameObject;
        EnemyList.Add(tmpObj);
    }
    void PlayerCreate()
    {
        GameObject tmpObj = null;

        string[] spos = PlayerDataManagement.Singleton().NowPlayerData.SavePos.Split('/');
        Vector3 tmpPos = new Vector3(float.Parse(spos[0]), float.Parse(spos[1]), float.Parse(spos[2]));
        Debug.Log(tmpPos);
        tmpObj = Instantiate(Player, tmpPos, Quaternion.identity) as GameObject;
    }
    void On_Respawn()
    {
        float spawnTime = 3.0f;

        PlayerDataManagement.Singleton().NowPlayerData.Health = 100;
        PlayerDataManagement.Singleton().life = true;
        while (spawnTime < 0)
        {
            spawnTime = spawnTime - Time.deltaTime;
        }
        Reset.SetActive(PlayerDataManagement.Singleton().life);
    }

}
