using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour {

    public GameObject obj;
    public float movePower = 2.5f; //이동힘
    Vector3 velocity = new Vector3(0.0f, 10.0f, 0.0f);
    float posY = 0.5f;
    int moveFlag = 0; //0 ,1:forward, 2:back, 3 : left, 4: right
    public float HP = 100.0f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("ChangeMovement");
    }
    IEnumerator ChangeMovement()
    {
        moveFlag = Random.Range(1, 6);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine("ChangeMovement");
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 moveDirection = Vector3.zero; //이동 방향

        if (transform.position.y < 0)
        {
            if (gameObject.tag == "enermy")
            {
                Destroy(gameObject, 0.5f);
            }
        }

        if (moveFlag == 1)
        {
            moveDirection = Vector3.forward;
            transform.Translate(moveDirection * movePower * Time.deltaTime);
        }
        else if (moveFlag == 2)
        {
            moveDirection = Vector3.back;
            transform.Translate(moveDirection * movePower * Time.deltaTime);
        }
        else if (moveFlag == 3)
        {
            moveDirection = Vector3.left;
            transform.Translate(moveDirection * movePower * Time.deltaTime);
        }
        else if (moveFlag == 4)
        {
            moveDirection = Vector3.right;
            transform.Translate(moveDirection * movePower * Time.deltaTime);
        }

        transform.position += moveDirection * movePower * Time.deltaTime;
}
    private void OnTriggerEnter(Collider col)
    {
        PlayerDataManagement damage = new PlayerDataManagement(); 
        if (col.tag == "Attack")
        {
            if (HP <= 0)
            {
                float spawnTime = 3.0f;
                obj.SetActive(false);
                HP = 100.0f;
                while (spawnTime < 0) {
                    spawnTime = spawnTime - Time.deltaTime;
                }
                obj.SetActive(true);
            }
            HP = HP - damage.NowPlayerData.Damage;
            Debug.Log(HP);
        }
    }
}
