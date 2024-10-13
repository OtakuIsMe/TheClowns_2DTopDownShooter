using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    private Transform playerTransform;
    private Transform enemyTransform;
    private float azimuthInDegrees;
    private SpriteRenderer mySpriteRenderer;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        enemyTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 playerPosition = playerTransform.position;
            Vector3 enemyPosition = enemyTransform.position;
            Vector3 enemyPlayerVector = playerPosition - enemyPosition;

            float azimuthInRadians = Mathf.Atan2(enemyPlayerVector.y, enemyPlayerVector.x);

            azimuthInDegrees = azimuthInRadians * Mathf.Rad2Deg;

            if (azimuthInDegrees < 0)
            {
                azimuthInDegrees += 360;
            }

            if (animator != null)
            {
                animator.SetFloat("Angle", azimuthInDegrees);
            }
            if (azimuthInDegrees > 135 && azimuthInDegrees < 225)
            {
                mySpriteRenderer.flipX = true;
            }
            else
            {
                mySpriteRenderer.flipX = false;
            }
        }
    }
}
