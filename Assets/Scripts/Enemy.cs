using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public BasicStat basicStat;
    private Rigidbody2D enemyBody;
    private Animator animator;
    private GameObject playerGO;
    [SerializeField] private Direction enemyDirection;
    private MapDetails mapDetails;
    [SerializeField] private Vector3 target;
    [SerializeField] private float delayResetMovePoint = 3f;
    [SerializeField] private float delayCauseDamage = 1f;
    [SerializeField] private bool isAttacking;

    [HideInInspector] public bool _canUse;
    void Awake()
    {
        basicStat = GetComponent<BasicStat>();
        enemyBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerGO = GameObject.Find("Player");
        mapDetails = GameObject.Find("MapDetails").GetComponent<MapDetails>();
    }

    void Update()
    {
        EnemyMovement();
        StartCoroutine(CheckMoveDir());
        UpdateDirection(enemyDirection);
        delayCauseDamage -= Time.deltaTime;
    }

    private void EnemyMovement()
    {
        delayResetMovePoint -= Time.deltaTime;
        if (delayResetMovePoint <= 0)
        {
            target = mapDetails.GetRandomPositionInMap();
            delayResetMovePoint = 3f;
        }

        if (isAttacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerGO.transform.position, basicStat.base_Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, basicStat.base_Speed * Time.deltaTime);
        }

    }

    private IEnumerator CheckMoveDir()
    {
        var p1 = transform.position.x;
        yield return new WaitForSeconds(0.5f);
        var p2 = transform.position.x;

        if (p1 < p2)
        {
            enemyDirection = Direction.right;
        }
        else
        {
            enemyDirection = Direction.left;
        }
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

    public void ReceiveDamage(float damage)
    {
        if (basicStat.base_HP > 0)
        {
            basicStat.base_HP -= damage;
        }
        else
        {
            Death();
        }
    }

    public void CauseDamageByCollision(Player player, float damage)
    {
        Debug.Log("CauseDamageByCollision call back, delayCauseDamage: " + delayCauseDamage);
        if (delayCauseDamage < 0)
        {
            player.ReceiveDamage(damage);

            GameManager.instance.ShowText("- " + basicStat.base_Damage, 20, Color.red, player.transform.position, Vector3.up * 50, 1.5f);

            delayCauseDamage = 1;
        }
        else
        {
        }
    }

    private void Death()
    {
        this.gameObject.SetActive(false);
        _canUse = true;
    }

    public void ReSpawn(Vector3 position)
    {
        basicStat.base_HP = 10;
        _canUse = false;
        gameObject.SetActive(true);
        gameObject.transform.position = position;
    }
}
