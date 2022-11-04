using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject closed;
    [SerializeField] GameObject opened;
    [SerializeField] bool Isopened;

    public override void Interact(Player player)
    {
        if (opened == false) 
        {
            Isopened = true;
            closed.SetActive(false);
            opened.SetActive(true);
        }else if(opened == true)
        {
            Isopened = false;
            closed.SetActive(true);
            opened.SetActive(false);
        }
    }
}
