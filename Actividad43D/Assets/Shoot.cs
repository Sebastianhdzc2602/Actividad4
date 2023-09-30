using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{

    public PlayerInteract PlayerActions;
    private InputAction click;
    private InputAction position;
    public GameObject arrowPrefab;

    Ray ray;

    private void Awake()
    {
        PlayerActions = new PlayerInteract();
    }

    private void OnEnable()
    {
        click = PlayerActions.Player.Click;
        click.Enable();
        click.performed += Interact;

        position = PlayerActions.Player.Position;
        position.Enable();


    }

    private void OnDisable()
    {
        click.Disable();
        position.Disable();

    }


    private void Interact(InputAction.CallbackContext context)
    {

        Vector2 mousePosition = PlayerActions.Player.Position.ReadValue<Vector2>();
        ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            Instantiate(arrowPrefab, hit.point, Quaternion.identity);
        }


    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
