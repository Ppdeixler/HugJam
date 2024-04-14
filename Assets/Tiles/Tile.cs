using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public bool selected;

    public float demolishChance;

    public SpriteRenderer spriteRenderer;

    public void SelectThis()
    {
        selected = true;
    }

}
