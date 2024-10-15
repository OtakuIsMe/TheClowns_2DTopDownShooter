using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    private Transform playerTransform;
    private Transform enemyTransform;
    private float azimuthInDegrees;
    private SpriteRenderer mySpriteRenderer;

    public int enemyHP = 1;
    public Slider enemyHealthBar;
    void Start()
    {
        enemyHealthBar.value = enemyHP;
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
            Vector3 playerPosition = playerTransform.transform.position;
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
