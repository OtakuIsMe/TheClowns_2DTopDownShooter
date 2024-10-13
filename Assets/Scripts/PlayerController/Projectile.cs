using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float movespeed = 22f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        //DetectFireDistance();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveProjectile();
    }

    //private void DetectFireDistance()
    //{
    //    if (Vector3.Distance(transform.position, startPos) > )
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void MoveProjectile()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movespeed);
    }
}
