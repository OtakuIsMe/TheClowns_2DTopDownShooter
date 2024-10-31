using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletObject;
    [SerializeField] float bulletSpeed = 5f;
    Vector3 BulletMove;
    private bool IsShootingProgress = true;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove = EnemyController.instance.enemyPlayerVector;
        Debug.Log(BulletMove);
        if (EnemyController.isShooting)
        {
            if (IsShootingProgress)
            {
                StartCoroutine(BulletShooting());
            }
        }
    }


    private IEnumerator BulletShooting()
    {
        IsShootingProgress = false;
        yield return new WaitForSeconds(0.2f);

        GameObject bullet = Instantiate(bulletObject, transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = BulletMove.normalized * bulletSpeed;
        }
        yield return new WaitForSeconds(1.8f);
        IsShootingProgress = true;
    }
}
