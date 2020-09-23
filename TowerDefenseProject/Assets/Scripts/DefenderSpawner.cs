using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab;

    private void OnMouseDown()
    {
        AttemptToSpawnDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defenderPrefab = selectedDefender;
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

    private void AttemptToSpawnDefenderAt(Vector2 gridPos)
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defenderPrefab.GetStarCost();

        if(starDisplay.SpendStars(defenderCost))
        {
            SpawnDefender(gridPos);
        }
    }

    private void SpawnDefender(Vector2 posToSpawn)
    {
        if(!defenderPrefab) { return; }

        Defender spawnedDefender = Instantiate(defenderPrefab, posToSpawn, Quaternion.identity) as Defender;
    }
}
