using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TileScript : MonoBehaviour
{

    [Header("Tile Properties")]



    public bool canBuild;

    public bool built;

    public terrain ActualTerrain;

    public SpriteRenderer spriteRenderer;

    public builds ActualBuild;


    


    public void Deselect()
    {
        selected = false;
    }

    public enum terrain { River, Mountain, Grass, Forest };

    public enum builds {None, House, Firefight, Hospital} ;

    public void BuildHere(builds buildsType)
    {
        ActualBuild = buildsType;
        FindObjectOfType<AudioManager>().Play("Build");
    }

    public void DemolishHere()
    {
        ActualBuild = builds.None;

        canBuild = true;

        built = false;

        spriteRenderer.sprite = null;

        FindObjectOfType<AudioManager>().Play("Demolish");

    }


    //Old selection system

    public bool selected;
    public void SelectThis()
    {
        selected = true;
    }
    public void DemolishStructure()
    {

    }

}
