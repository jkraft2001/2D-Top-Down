using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    PlayerController2D playerController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Player player;

    private void Awake()
    {
        playerController = GetComponent<PlayerController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

    }

    private void Interact()
    {
        Vector2 Position = rgbd2d.position + playerController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(Position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(player);
                break;
            }
        }
    }
}

