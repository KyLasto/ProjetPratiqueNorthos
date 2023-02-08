using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : Interactable
{
    public override void Interact()
    {
        Debug.Log("Mining...");
        base.Interact();
    }
}
