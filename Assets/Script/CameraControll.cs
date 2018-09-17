using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public Transform target;
    public float dist = 2.5f;
    public float height = 1.0f;
    public float smoothRotate = 5.0f;

    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        float currYAngle = Mathf.LerpAngle(tr.localEulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);

        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);

        tr.LookAt(target);
    }
}