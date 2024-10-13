using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] private GameObject spawnRing;

    private PlayerControls playerControls;
    private Animator myAnimator;
    private GameObject bulletPrefab;
    private GameObject bulletSpawnPos;
    private float attackCD;

    readonly int FIRE_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
        bulletSpawnPos = GetComponent<GameObject>();

        if (spawnRing == null)
        {
            spawnRing = transform.Find("SpawnRing").gameObject;
        }
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
        //GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPos.transform.position, spawnRing.transform.rotation);
        StartCoroutine(RemoveAttackTriggerAfterDelay(0.6f));
        //newBullet.GetComponent<Projectile>();
    }

    private IEnumerator RemoveAttackTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        myAnimator.SetBool("Attack", false);
    }
}
