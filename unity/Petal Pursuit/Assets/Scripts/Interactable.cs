using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable
{
    private bool interacted = false;
    public GameObject onCollectEffect;

    protected override void OnCollided(GameObject collidedObject) {
      //  base.OnCollided(collidedObject); // does what collidable does

        if (Input.GetKey(KeyCode.E)) {
            OnInteract();
        }
    }

    protected virtual void OnInteract() {
        if (!interacted) {
            interacted = true;
            Debug.Log("Interact with " + name);
            
            // Destroy the collectible
            Destroy(gameObject);

            // Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}