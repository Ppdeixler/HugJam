using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    private Vector2 mousePosition;

    [SerializeField]

    private GameManager gameManager;
    private void Update()
    {

    }
    public void Click()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);

        if (hit.collider == null) return;

        Tile tile = hit.collider.GetComponent<Tile>();

        tile.SelectThis();
    }
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
}
