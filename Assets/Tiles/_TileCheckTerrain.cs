using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TileCheckTerrain : MonoBehaviour
{
    [SerializeField]
    private _TileScript tilescript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CantBuild")
        {
            tilescript.canBuild = false;
        }
    }



}
