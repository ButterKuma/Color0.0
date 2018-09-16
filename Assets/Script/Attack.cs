using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject bullet;
    public float bSpeed = 1000.0f;
    public float lifeTime = 1.0f;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bSpeed);
    }
    private void Update()
    {
        lifeTime = lifeTime - Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(bullet);
            lifeTime = 1.0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
