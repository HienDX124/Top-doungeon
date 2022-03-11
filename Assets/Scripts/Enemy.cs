using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BasicStat basicStat;
    private Rigidbody2D enemyBody;
    private Animator animator;
    private GameObject playerGO;
    [SerializeField] private Direction enemyDirection;
    private MapDetails mapDetails;
    [SerializeField] private Vector3 target;
    [SerializeField] private float delayResetMovePoint = 3f;
    [SerializeField] private bool isAttacking;
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

    }

    private Vector3 GetRandomPositionInMap()
    {
        float posX = UnityEngine.Random.Range(0 - mapDetails.mapWidth / 2, mapDetails.mapWidth - mapDetails.mapWidth / 2);
        float posY = UnityEngine.Random.Range(0 - mapDetails.mapHieght / 2, mapDetails.mapHieght - mapDetails.mapHieght / 2);
        return new Vector3(posX, posY, 0);
    }

    private void EnemyMovement()
    {
        delayResetMovePoint -= Time.deltaTime;
        if (delayResetMovePoint <= 0)
        {
            target = GetRandomPositionInMap();
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

        Debug.Log("p1: " + p1 + "; p2: " + p2);
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
}
