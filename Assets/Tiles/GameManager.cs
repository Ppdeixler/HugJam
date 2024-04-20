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
    public TileBase tileToCheck;

    private void Start()
    {
        InstantiateTileInfo();
        Resources.GameStart();

        Debug.Log(_tilemap.size);
    }

    public void InstantiateTileInfo()
    {
        for (int i = 0; i < _tilemap.size.x; i++)
        {
            for (int b = 0; b < _tilemap.size.x; b++)
            {
                Vector3 worldPosition = _tilemap.GetCellCenterWorld(new Vector3Int(i + _tilemap.origin.x, b + _tilemap.origin.x));
   
                Instantiate(_tilePrefab, worldPosition, Quaternion.identity);
            }
        }
    }
}   