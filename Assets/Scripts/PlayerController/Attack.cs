using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject bulletObject;
    [SerializeField] float bulletSpeed = 9f;
    private PlayerControls playerControls;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        myAnimator = GetComponent<Animator>();
        playerControls.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerControls.Combat.Attack.started += _ => Shoot();
    }

    private void Shoot()
    {
        if (this == null)
        {
            Debug.LogWarning("Attack component has been destroyed.");
            return;
        }

        if (!gameObject.activeSelf)
        {
            Debug.LogWarning("Player is inactive, cannot shoot.");
            return;
        }

        if (myAnimator != null)
        {
            myAnimator = GetComponent<Animator>();
            myAnimator.SetBool("Attack", true);

            GameObject bullet = Instantiate(bulletObject, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 bulletMove = (mousePos - transform.position).normalized;

            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = bulletMove * bulletSpeed;
            }

            AudioManager.instance.Play("Shoot");
            StartCoroutine(RemoveAttackTriggerAfterDelay(0.5f));
        }
        else
        {
            Debug.LogWarning("Animator is missing or has been destroyed.");
            return;
        }
    }

    private IEnumerator RemoveAttackTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        myAnimator.SetBool("Attack", false);
    }
}
