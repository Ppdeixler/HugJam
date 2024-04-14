using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [Header("Tile Properties")]

    public bool selected;

    public bool canBuild;

    public bool built;

    public terrain ActualTerrain;

    public SpriteRenderer spriteRenderer;

    public void SelectThis()
    {
        selected = true;
    }

    public void DemolishStructure()
    {

    }

    public enum terrain { River, Mountain, Grass, Forest }; 
    
}
