using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 5;
    private Animator myAnimator;
    private float oldMoveSpeed;
    private bool hasTakenDamage = false;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletPlayer") && !hasTakenDamage)
        {
            hasTakenDamage = true;
            enemyHealth -= BulletController.damagePerBulletStatic;
            oldMoveSpeed = EnemyController.moveSpeedStatic;
            if (enemyHealth <= 0)
            {
                PlayerController.numberOfEnemyKill++;
                GameManagerScript.isGameOver = true;

                SoundController.instance.Playthisound("Explosions", 5f);
                StartCoroutine(DeathEffect());

                SoundController.instance.Stop("Background");
                new WaitForSeconds(2f);
                SoundController.instance.Play("LevelCompleted");
            }
            else
            {
                StartCoroutine(BeingShootingEffect());
            }
        }
    }

    private IEnumerator DeathEffect()
    {
        if (myAnimator != null)
        {
            EnemyController.setMoveSpeed(0);
            myAnimator.SetTrigger("BeDeath");
            yield return new WaitForSeconds(1f);
            hasTakenDamage = false;

            Destroy(gameObject);
        }
    }


    private IEnumerator BeingShootingEffect()
    {
        if (myAnimator != null)
        {
            EnemyController.setMoveSpeed(0);
            myAnimator.SetBool("BeShoot", true);
            yield return new WaitForSeconds(0.2f);
            myAnimator.SetBool("BeShoot", false);
            EnemyController.setMoveSpeed(oldMoveSpeed);
            hasTakenDamage = false;
        }
    }
}
