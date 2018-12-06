using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject obj;
    public GameObject Player;
    public float movePower = 2.5f; //이동힘
    Vector3 velocity = new Vector3(0.0f, 10.0f, 0.0f);
    public Vector3 direction;
    public float accelaration;
    int moveFlag = 0; //0 ,1:forward, 2:back, 3 : left, 4: right
    public float HP = 100.0f;
    public Transform target;


    // Use this for initialization
    void Startr()
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
    void FixedUpdate()
    {      
        if (HP < 60)
        {
            Avoid();
        }
        else
        {
            Move();
            Approach();
        }
    }
    void Avoid() {
        // Player의 현재 위치를 받아오는 Object
        target = Player.transform;
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;
        // 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
        accelaration = 0.1f;
        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
        movePower = (movePower + accelaration * Time.deltaTime);
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.position, transform.position);
        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (distance <= 20.0f)
        {
            this.transform.position = new Vector3(transform.position.x + (-direction.x * movePower),
                                                   transform.position.y + (-direction.y * movePower),
                                                     transform.position.z);
        }
        else
        {
            movePower = 2.5f;
        }
    }
    void Approach()
    {
        // Player의 현재 위치를 받아오는 Object
        target = Player.transform;
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;
        // 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
        accelaration = 0.1f;
        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
        movePower = (movePower + accelaration * Time.deltaTime);
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.position, transform.position);
        // 일정거리 안에 있을 시, 해당 방향으로 무빙
       if (distance <= 20.0f)
        {
            this.transform.position = new Vector3(transform.position.x + (direction.x * movePower),
                                                   transform.position.y + (direction.y * movePower),
                                                     transform.position.z);
        }
        else
        {
            movePower = 2.5f;
        }
    }

    void Move()
    {
        Vector3 moveDirection = Vector3.zero; //이동 방향

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
        int damage = PlayerDataManagement.Singleton().NowPlayerData.Damage;
        Respawn rsp = new Respawn();
        if (col.tag == "Attack")
        {
            if (HP <= 0)
            {
                OnDestroy();
                HP = 100.0f;
            }
            HP = HP - damage;
            Debug.Log(HP);
        }
    }
    private void OnDestroy()
    {
        obj.SetActive(false);
        Destroy(obj, 0.5f);
    }
}