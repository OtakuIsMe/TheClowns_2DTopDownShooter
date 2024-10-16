using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] float playerHealth = 3;
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
            oldMoveSpeed = PlayerController.moveSpeedStatic;
            if (playerHealth <= 0)
            {
                StartCoroutine(DeathEffect());
            }
            else
            {
                StartCoroutine(BeingShootingEffect());
            }
        }
    }

    private IEnumerator DeathEffect()
    {
        PlayerController.setMoveSpeed(0);
        myAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator BeingShootingEffect()
    {
        PlayerController.setMoveSpeed(0);
        myAnimator.SetBool("BeShoot", true);
        yield return new WaitForSeconds(0.2f);
        myAnimator.SetBool("BeShoot", false);
        PlayerController.setMoveSpeed(oldMoveSpeed);
    }
}
