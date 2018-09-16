using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed; //이동 속도
    public float spinSpeed; //회전 속도
    private float hori; //수평
    Vector3 velocity = new Vector3(0.0f, 20.0f, 0.0f);

    public GameObject bullet;
    public Transform pos;


    private void Awake()
    {
        speed = 2.0f;
        spinSpeed = 2.0f;
    }

    private void Update()
    {
        //jump
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        //action
        if (Input.GetMouseButtonDown(0))
        {
            Action();
        }
        Move();
        Rotate();
    }
    //공격을 위한 총알 생성
    void Action()
    {
        Instantiate(bullet, pos.position, pos.rotation);
    }

    void Move()
    {

        //LeftShift 판정

        if (Input.GetKey(KeyCode.LeftShift))
            speed = 3.5f;
        else
            speed = 2.0f;

        //속도 계산
        float move = speed * Time.deltaTime;

        //이동 방향
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * move);
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * move);
        else if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * move);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * move);

        if (transform.position.y < 0)
        {
            transform.Translate(0, 0, 0);
        }
    }

    void Rotate()
    {
        hori = Input.GetAxis("Mouse X");
        float Rh = spinSpeed * hori;
        transform.Rotate(Vector3.up * Rh);
    }
    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(velocity);

    }
}
