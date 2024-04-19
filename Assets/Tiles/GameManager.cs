using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GameManager : MonoBehaviour
{

    [Header("Tilemap Informations")]

    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]

    private GameObject _tilePrefab;

    [SerializeField] 
    private int _mapSizeX, _mapSizeY;

    [SerializeField]
    private Tile tile;

    private void Start()
    {
        InstantiateTileInfo();
        Resources.GameStart();
    }

    public void InstantiateTileInfo()
    {
        for (int i = 0; i < _mapSizeX; i++) 
        {
            for (int b = 0; b < _mapSizeY; b++)
            {
                var worldPosition = _tilemap.GetCellCenterWorld(new Vector3Int(i + _tilemap.origin.x,b + _tilemap.origin.y));
                if (_tilemap.ContainsTile(tile))
                {

                }
                
                Instantiate(_tilePrefab, worldPosition, Quaternion.identity);


            }
        }
    }

}
