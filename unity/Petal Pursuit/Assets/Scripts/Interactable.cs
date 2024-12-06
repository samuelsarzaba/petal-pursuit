using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable
{
    private bool interacted = false;
    public GameObject onCollectEffect;
    public FlowerManager fm;

  /*  protected override void OnCollided(GameObject collidedObject)
{  
    if (collidedObject.CompareTag("Player") && !interacted)
    {
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }
} */

protected virtual void OnInteract()
{
    if (!interacted)
    {
        interacted = true; // Ensures only one interaction occurs
        Debug.Log("Interact with " + name);

        // Call FlowerManager logic if applicable
        if (fm != null)
        {
            fm.CollectFlower(gameObject);
        }

        // Instantiate particle effect
        if (onCollectEffect != null)
        {
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }

        // Destroy this collectable
        Destroy(gameObject);
    }
}

}