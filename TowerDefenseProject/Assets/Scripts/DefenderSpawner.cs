using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defenderPrefab;

    private void OnMouseDown()
    {
        Debug.Log("Mouse clicked");
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        var clickPos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 posToSpawn)
    {
        if(!defenderPrefab) { return; }

        GameObject spawnedDefender = Instantiate(defenderPrefab, posToSpawn, Quaternion.identity);
    }
}
