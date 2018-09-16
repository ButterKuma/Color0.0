using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject prefab;
    public float spawnTime = 3.0f;
    public List<GameObject> EnemyList = new List<GameObject>(); //enemy Data Save


    // Use this for initialization
    void Start()
    {
        OnCreate();
    }
    void Update()
    {
        On_Respawn();
    }
    void OnCreate() {
        GameObject tmpObj = null;
        for (int cnt = 0; cnt < 5; cnt++)
        {
            tmpObj = Instantiate(prefab, new Vector3(93.9f, 0.5f, 149.3f), Quaternion.identity) as GameObject;
            EnemyList.Add(tmpObj);
        }
    }
    void On_Respawn()
    {
        spawnTime = spawnTime - Time.deltaTime;
    }
}
