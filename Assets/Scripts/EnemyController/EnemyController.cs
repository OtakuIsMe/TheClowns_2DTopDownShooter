using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

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
    public static bool isShooting = false;
    public static EnemyController Instance;
    public static Vector3 enemyPlayerVector;
    public static float moveSpeedStatic;
    public static EnemyController instance;

    public int enemyHP = 1;
    public Slider enemyHealthBar;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        enemyHealthBar.value = enemyHP;
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
            Vector3 playerPosition = playerTransform.transform.position;
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
        }
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if(enemyHP > 0)
        {
            animator.SetTrigger("damage");
            animator.SetBool("isChasing", true);
        }
        else
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            enemyHealthBar.gameObject.SetActive(false);
            this.enabled = false;
        }
    }

    public void PlayerDamage()
    {
        if (!playerTransform.GetComponent<PlayerCollision>().isInvincible)
        {
            playerTransform.GetComponent<PlayerCollision>().TakeDamage();
        }
    }
}
