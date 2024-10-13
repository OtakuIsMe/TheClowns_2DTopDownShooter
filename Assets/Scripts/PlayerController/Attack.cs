using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerControls.Combat.Attack.started += _ => Shoot();
    }

    private void Shoot()
    {
        myAnimator.SetBool("Attack", true);
        StartCoroutine(RemoveAttackTriggerAfterDelay(0.5f));
    }

    private IEnumerator RemoveAttackTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        myAnimator.SetBool("Attack", false);
    }
}
