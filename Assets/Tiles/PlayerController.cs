using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    private Vector2 mousePosition;

    [SerializeField]
    private _TileScript tile;

    private GameManager gameManager;

    [Header("Player Mode")]

    public EMode _Mode;

    [Header("Sprites for the Blueprint")]

    [SerializeField]
    private Sprite[] spritesBlueprint;

    [SerializeField]
    private Sprite spriteAppearing;

    private GameObject tileGameObject;

    private SpriteRenderer spriteOfBuilding;


    private void Update()
    {
        MakeBlueprint();
    }
    public void Click()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);

        if (hit.collider == null) return;

        tile = hit.collider.GetComponent<_TileScript>();

        switch (_Mode) 
            {
            case EMode.BuildHouse:
                BuildHouse();
                break;
            case EMode.BuildFirefighter:
                BuildFirefighter();
                break;
            case EMode.BuildHospital:
                BuildHospital();
                break;
            case EMode.Demolish:
                tile.DemolishHere();
                break;
            case EMode.MoveBuilding:
                break;
            default: break;



        }
        //The old selecting system
        if (tile.selected)
        {
        ////Deselect and Select
        //if (tile != null)
        //{
        //    tile.Deselect();
        //    tile = hit.collider.GetComponent<_TileScript>();
        //    tile.SelectThis();
        //}

        ////Select if none are selected
        //if (tile == null)
        //{
        //    tile = hit.collider.GetComponent<_TileScript>();
        //    tile.SelectThis();
        //}

        }

    }

    //Build Functions
    public void MakeBlueprint()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);


        if (hit.collider ==  null && tileGameObject != null)
        {
            tileGameObject.GetComponentInChildren<SpriteRenderer>().sprite = null;
            return;
        }

        if (hit.collider == null) return;

        if (tileGameObject != null)
        {
            tileGameObject.GetComponentInChildren<SpriteRenderer>().sprite = null;
        }

        tileGameObject = hit.collider.gameObject;

        if (tileGameObject != null) 

        switch (_Mode)
        {
                case EMode.BuildHouse:
                    spriteAppearing = spritesBlueprint[0];
                    break;

                case EMode.BuildFirefighter:
                    spriteAppearing = spritesBlueprint[1];
                    break;

                case EMode.BuildHospital:
                    spriteAppearing = spritesBlueprint[2];
                    break;

                default:
                    spriteAppearing = null;
                    break;
        }



        if (tileGameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite != null)
        {
            return;
        }

        tileGameObject.GetComponentInChildren<SpriteRenderer>().sprite = spriteAppearing;

    }
    public void BuildHouse()
    {
        if (!tile.canBuild) return;
        if (tile.built) return;

        tile.BuildHere(_TileScript.builds.House);
        tile.built = true;
        tile.canBuild = false;

        if (Resources.houses <= 0) return;
        Resources.houses--;

        if(tileGameObject == null) return;

        spriteOfBuilding = tileGameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>();

        tileGameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite = spriteAppearing;
            
    }

    public void BuildFirefighter()
    {
        if (!tile.canBuild) return;
        if (tile.built) return;

        tile.BuildHere(_TileScript.builds.Firefight);
        tile.built = true;
        tile.canBuild = false;

        if (Resources.firefightbuild <= 0) return;
        Resources.firefightbuild--;

        if (tileGameObject == null) return;

        spriteOfBuilding = tileGameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>();

        tileGameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite = spriteAppearing;

    }

    public void BuildHospital()
    {
        if (!tile.canBuild) return;
        if (tile.built) return;

        tile.BuildHere(_TileScript.builds.Hospital);
        tile.built = true;
        tile.canBuild = false;

        if (Resources.hospital <= 0) return;
        Resources.hospital--;

        if (tileGameObject == null) return;

        spriteOfBuilding = tileGameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>();

        tileGameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite = spriteAppearing;

    }


    //Inputs
    public void GetMousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Click();
        }
    }

    //Modes of creation
    public enum EMode {BuildHouse, BuildFirefighter, BuildHospital,  Demolish, MoveBuilding}

    //Functions to the buttons on the UI of the game.
    public void ChangeToHouse()
    {
        _Mode = EMode.BuildHouse;
    }
    public void ChangeToFirefighter()
    {
        _Mode = EMode.BuildFirefighter;
    }
    public void ChangeToHospital()
    {
        _Mode = EMode.BuildHospital;
    }
    public void ChangeToDemolish()
    {
        _Mode = EMode.Demolish;
    }
    public void ChangeToMove()
    {
        _Mode = EMode.MoveBuilding;
    }





}
