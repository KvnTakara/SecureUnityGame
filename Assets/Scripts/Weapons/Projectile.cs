using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 firingPoint;
    [SerializeField] float projectileSpeed;
    [SerializeField] float maxProjectileDistance;

    void Start()
    {
        firingPoint = transform.position;
    }

    void Update()
    {
        MovePorjectile();
    }

    void MovePorjectile()
    {
        if (Vector3.Distance(firingPoint, transform.position) > maxProjectileDistance)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}
