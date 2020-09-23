using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    Color inactiveColor = new Color32(51,51,51,255);
    Color activeColor = Color.white;

    private void OnMouseDown()
    {
        SetAllInactive();
        SetColor(activeColor);
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

    private void SetAllInactive()
    {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.SetColor(inactiveColor);
        }
    }

    private void SetColor(Color color)
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer sprite in spriteRenderers)
        {
            sprite.color = color;
        }
    }
}
