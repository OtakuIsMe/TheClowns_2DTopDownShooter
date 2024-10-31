using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float distanceFollow = 7f;
    [SerializeField] float distanceOut = 10f;
    [SerializeField] float speed = 2f;
    [SerializeField] float shootCd = 2f;
    private Animator animator;
    private Transform playerTransform;
    private Transform enemyTransform;
    private float azimuthInDegrees;
    private SpriteRenderer mySpriteRenderer;
    public bool isShooting = false;
    public Vector3 enemyPlayerVector;
    public static float moveSpeedStatic;
    public static EnemyController instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        enemyTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        moveSpeedStatic = speed;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 playerPosition = playerTransform.position;
            Vector3 enemyPosition = enemyTransform.position;
            enemyPlayerVector = playerPosition - enemyPosition;

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
            float distance = CountDistance(playerPosition, enemyPosition);

            if (distance > distanceFollow && distance < distanceOut)
            {
                animator.SetBool("IsShoot", false);
                animator.SetBool("IsRun", true);
                MoveEnemy(enemyPlayerVector, speed);
            }
            else if (distance > distanceOut)
            {
                animator.SetBool("IsShoot", false);
                animator.SetBool("IsRun", false);
            }
            else
            {
                if (!isShooting)
                {
                    StartCoroutine(EnemyShooting());
                }
            }
        }
    }

    private float CountDistance(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }

    private void MoveEnemy(Vector3 moveVector, float speed)
    {
        Vector3 direction = moveVector.normalized;
        enemyTransform.Translate(direction * speed * Time.deltaTime);
    }

    IEnumerator EnemyShooting()
    {
        isShooting = true;
        animator.SetBool("IsRun", false);
        animator.SetBool("IsShoot", true);

        yield return new WaitForSeconds(shootCd);

        animator.SetBool("IsShoot", false);
        isShooting = false;
    }
    public static void setMoveSpeed(float newMoveSpeed)
    {
        instance.speed = newMoveSpeed;
    }
}