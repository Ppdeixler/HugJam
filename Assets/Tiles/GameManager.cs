using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject grid;

    [SerializeField]
    private int cellMapX, cellMapY;

    [SerializeField]
    private GameObject[,] cells;

    private void Start()
    {
        cells = new GameObject[cellMapX, cellMapY];

        GetCells();
        Debug.Log(cells);

    }

    private void GetCells()
    {
        

        for (int i = 0; i < cellMapX; i++)
        {
            for (int b = 0; b < cellMapY; b++)
            {
                for(int c = 0; c < grid.transform.childCount; c++)
                {
                    cells[i, b] = grid.transform.GetChild(c).gameObject;

                    Destroy(cells[i, b]);
                }
            }
        }
    }

}
