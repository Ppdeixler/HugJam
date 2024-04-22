using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileIdentifier : MonoBehaviour
{
    [SerializeField]
    private _TileScript.terrain terrainQueMuda;

    private void OnTriggerStay2D(Collider2D collision)
    {

        collision.TryGetComponent<_TileScript>(out _TileScript tilezin);

        if(tilezin != null)
        tilezin.ActualTerrain = terrainQueMuda;
    }



}
