using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public FloatingTextManager floatingTextManager;
    public EnemyManager enemyManager;
    public LevelDetails currentLevel;
    public List<Enemy> enemyList;

    void Awake()
    {
        instance = this;
        enemyList = enemyManager.enemyList;
    }

    void Update()
    {
        if (enemyManager.isAllEnemyDie)
        {
            LoadWaveEnemyOfLevel();
        }
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void LoadWaveEnemyOfLevel()
    {
        for (int i = 0; i < currentLevel.waves[currentLevel.currentWave]; i++)
        {
            enemyManager.SpawnAnEnemy();
        }
        currentLevel.currentWave += 1;
        Debug.Log("Current wave: " + currentLevel.currentWave);
    }


}
