using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDetails : MonoBehaviour
{
    public float mapWidth;
    public float mapHieght;
    public Vector3 GetRandomPositionInMap()
    {
        float posX = UnityEngine.Random.Range(0 - (mapWidth / 2 - 2), mapWidth - 2 - mapWidth / 2);
        float posY = UnityEngine.Random.Range(0 - (mapHieght / 2 - 2), mapHieght - 2 - mapHieght / 2);
        return new Vector3(posX, posY, 0);
    }

}
