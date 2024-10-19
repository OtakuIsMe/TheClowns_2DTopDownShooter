using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = HealthManager.health;
    private Animator myAnimator;
    private float oldMoveSpeed;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            playerHealth -= BulletController.damagePerBulletStatic;
            HealthManager.health = Mathf.CeilToInt(playerHealth); 

            oldMoveSpeed = PlayerController.moveSpeedStatic;

            if (playerHealth <= 0)
            {
                StartCoroutine(DeathEffect());

                SoundController.instance.Stop("Background");
                new WaitForSeconds(2f);
                SoundController.instance.Play("Gameover");
            }
            else
            {
                SoundController.instance.Playthisound("hit", 5f);
                StartCoroutine(BeingShootingEffect());
            }
        }
    }

    private IEnumerator DeathEffect()
    {
        if (myAnimator != null)
        {
            PlayerController.setMoveSpeed(0);
            myAnimator.SetTrigger("Death");
            yield return new WaitForSeconds(1f); 
        }

        GameManagerScript.isGameOver = true;
        FindObjectOfType<GameManagerScript>().gameOver(); 
    }

    private IEnumerator BeingShootingEffect()
    {
        if (myAnimator != null)
        {
            PlayerController.setMoveSpeed(0);
            myAnimator.SetBool("BeShoot", true);
            yield return new WaitForSeconds(0.2f);
            myAnimator.SetBool("BeShoot", false);
            PlayerController.setMoveSpeed(oldMoveSpeed);
        }
    }
}
