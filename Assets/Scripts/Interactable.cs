using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Distance the player needs to get to the object to interact with it.
    public float InteractRadius = 3f;
    public Transform interactionTransform;
    public Transform interactionWithTrees;
    public Transform interactionWithRocks;
    public Transform interactionWithFishes;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with" + transform.name);

        if (interactionTransform == interactionWithTrees)
        {
            //Woodcutting();
        }
        
        if (interactionTransform == interactionWithRocks)
        {
            //Mining();
        }
        
        if (interactionTransform == interactionWithFishes)
        {
            //Fishing();
        }
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= InteractRadius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, InteractRadius);
    }
}
