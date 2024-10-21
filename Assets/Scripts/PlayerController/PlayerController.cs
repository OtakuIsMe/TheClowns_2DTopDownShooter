using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    public static float moveSpeedStatic;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    public static PlayerController instance;

    public static int numberOfEnemyKill;
    public TextMeshProUGUI killsText;

    private bool IsSoundStart = true;

    public List<EnemyHealth> enemies = new List<EnemyHealth>();
    public int numberOfEnemies;

    private void Awake()
    {
        numberOfEnemyKill = 0;
        numberOfEnemies = enemies.Count;
        Debug.Log(numberOfEnemies);
        if (instance == null)
        {
            instance = this;
        }
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        moveSpeedStatic = moveSpeed;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        killsText.text = numberOfEnemyKill.ToString();
        PlayerInput();
        Vector3 mousePos = Input.mousePosition;
        if (numberOfEnemyKill >= 3)
        {
            GameManagerScript.isGameWinner = true;

            SoundController.instance.Stop("Background");
            new WaitForSeconds(2f);
            SoundController.instance.Play("LevelCompleted");
        }
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPosition - transform.position;

        myAnimator.SetFloat("moveX", direction.x);
        myAnimator.SetFloat("moveY", direction.y);
        myAnimator.SetFloat("speed", movement.magnitude);
        if (movement != Vector2.zero && IsSoundStart)
        {
            StartCoroutine(EFSound());
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement.normalized * (moveSpeed * Time.fixedDeltaTime));
    }

    private IEnumerator EFSound()
    {
        IsSoundStart = false;
        SoundController.instance.Playthisound("foot", 5f);
        yield return new WaitForSeconds(0.35f);

        IsSoundStart = true;
    }
    private void AdjustPlayerFacingDirection()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mouseWorldPosition - transform.position;

        if (direction.x < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }

    public static void setMoveSpeed(float newMoveSpeed)
    {
        instance.moveSpeed = newMoveSpeed;
    }
}
