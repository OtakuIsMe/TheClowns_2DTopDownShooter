using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float damagePerBullet = 1f;
    [SerializeField] string target = "Player";
    public static float damagePerBulletStatic;
    void Start()
    {
        damagePerBulletStatic = damagePerBullet;
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(target))
        {
            Destroy(gameObject);
        }
    }
}
