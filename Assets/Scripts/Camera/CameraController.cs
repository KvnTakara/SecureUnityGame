using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 targetOffset;
    public Transform target;

    float movementSpeed = 10f;

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if (target == null) return;

        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
    }
}
