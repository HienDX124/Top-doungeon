using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyContainer;
    public GameObject enemyPrefab;
    public MapDetails mapDetails;
    public List<Enemy> enemyList;



    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.N))
        {
            SpawnAnEnemy();
        }
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
