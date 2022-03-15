using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetails : MonoBehaviour
{
    public int[] waves;
    public int currentWave = 0;

    void Update()
    {
        if (currentWave == waves.Length)
        {
            // level comple
            Debug.Log("Level complete");
        }
    }

}
