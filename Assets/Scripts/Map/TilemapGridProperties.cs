﻿using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System;

[ExecuteAlways]
public class TilemapGridProperties : MonoBehaviour
{
    private Tilemap tilemap;
    // private Grid grid;
    [SerializeField] private SO_GridProperties gridProperties = null;
    [SerializeField] private GridBoolProperty gridBoolProperty = GridBoolProperty.diggable;

    private void OnEnable()
    {
        // Only populate in the editor
        if (!Application.IsPlaying(gameObject))
        {
            tilemap = GetComponent<Tilemap>();
            if (gridProperties != null)
            {
                gridProperties.gridPropertyList.Clear();
            }
        }
    }

    private void OnDisable()
    {
        // Only populate in the editor
        if (!Application.IsPlaying(gameObject))
        {
            UpdateGridProperties();
            if (gridProperties != null)
            {
                // This is required to ensure that the updated gridproperties gameobject get save when the game is saved = otherwise they are not saved.
                EditorUtility.SetDirty(gridProperties);
            }
        }
    }

    private void UpdateGridProperties()
    {
        // Compress tilemap bounds
        tilemap.CompressBounds();

        // Only populate in the editor
        if (!Application.IsPlaying(gameObject))
        {
            if (gridProperties != null)
            {
                Vector3Int startCell = tilemap.cellBounds.min;
                Vector3Int endCell = tilemap.cellBounds.max;

                for (int x = startCell.x; x < endCell.x; x++)
                {
                    for (int y = startCell.y; y < endCell.y; y++)
                    {
                        TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                        if (tile != null)
                        {
                            gridProperties.gridPropertyList.Add(new GridProperty(new GridCoordinate(x, y), gridBoolProperty, true));
                        }
                    }
                }
            }
        }
    }

    private void Update()
    {
        // Only populate in the editor
        if (!Application.IsPlaying(gameObject))
        {
            // Debug.Log("DISABLE PROPERTY TILEMAPS");
        }
    }


}
