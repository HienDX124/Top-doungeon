using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;
    private Animator animator;
    private Rigidbody2D myBody;
    private Animator weaponAnimator;

    [SerializeField] private GameObject weaponGO;

    private Weapon playerWeapon;
    private float xInput, yInput;

    private bool isMoving;
    private Direction playerDirection;
    [HideInInspector] public BasicStat basicStat;
    private void Awake()
    {
        basicStat = GetComponent<BasicStat>();
        animator = transform.Find("Body").GetComponent<Animator>();
        myBody = gameObject.GetComponent<Rigidbody2D>();
        weaponAnimator = weaponGO.GetComponent<Animator>();
        playerWeapon = weaponGO.GetComponent<Weapon>();
    }

    private void FixedUpdate()
    {
        Attack();
        PlayerMovementInput();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * basicStat.base_Speed * Time.deltaTime, yInput * basicStat.base_Speed * Time.deltaTime);
        myBody.MovePosition(myBody.position + move);
        UpdatePlayerAnimator();
    }

    private void UpdatePlayerAnimator()
    {
        animator.SetBool("move", isMoving);
    }
    private void UpdateDirection(Direction dir)
    {
        float tempX = 1;
        if (dir == Direction.right)
        {
            tempX = Mathf.Abs(gameObject.transform.localScale.x);
        }
        else
        {
            tempX = Mathf.Abs(gameObject.transform.localScale.x) * -1;
        }
        gameObject.transform.localScale = new Vector3(tempX, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
    private void PlayerMovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (yInput != 0 && xInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
            isMoving = true;
        }

        if (yInput != 0 || xInput != 0)
        {
            //  Capture player direction for save game
            if (xInput < 0)
            {
                playerDirection = Direction.left;
                UpdateDirection(playerDirection);
            }
            if (xInput > 0)
            {
                playerDirection = Direction.right;
                UpdateDirection(playerDirection);
            }
            if (yInput < 0)
            {
                playerDirection = Direction.down;
            }
            if (yInput > 0)
            {
                playerDirection = Direction.up;
            }
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void Attack()
    {
        attackCooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && attackCooldown < 0)
        {
            weaponAnimator.Play("hit");
            StartCoroutine(playerWeapon.ActiveColliderWhenAttack());
            attackCooldown = 0.5f;
        }
    }

    public void CauseDamage(Enemy enemy, float damage)
    {
        enemy.ReceiveDamage(damage);
    }

}