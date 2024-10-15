using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletObject;
    Vector3 BulletMove;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove = EnemyController.enemyPlayerVector;
        Debug.Log(BulletMove);
    }
}
