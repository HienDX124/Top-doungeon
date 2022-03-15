using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyContainer;
    public GameObject enemyPrefab;
    public MapDetails mapDetails;
    [HideInInspector] public List<Enemy> enemyList;

    public bool isAllEnemyDie;
    void Update()
    {
        CheckAllEnemyDie();
    }

    void FixedUpdate()
    {

    }

    private bool CheckAllEnemyDie()
    {
        isAllEnemyDie = true;
        foreach (Enemy e in enemyList)
        {
            if (!e._canUse)
            {
                isAllEnemyDie = false;
                return isAllEnemyDie;
            }
        }
        return isAllEnemyDie;
    }

    public Enemy GetEnemy()
    {
        foreach (Enemy enemy in enemyList)
        {
            if (enemy._canUse)
            {
                return enemy;
            }
        }
        Enemy newEnemy = Instantiate(enemyPrefab).gameObject.GetComponent<Enemy>();
        newEnemy.gameObject.transform.SetParent(enemyContainer.transform);
        enemyList.Add(newEnemy);

        return newEnemy;
    }

    public void SpawnAnEnemy()
    {
        GetEnemy().ReSpawn(mapDetails.GetRandomPositionInMap());
    }
}
