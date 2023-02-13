using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpots : Interactable
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Fishing...");
    }
}
