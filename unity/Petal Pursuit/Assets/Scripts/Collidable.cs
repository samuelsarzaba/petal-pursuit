using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
  private Collider2D myCollider;
  [SerializeField]
  private ContactFilter2D filter;
  private List<Collider2D> collidedObjects = new List<Collider2D>(1); // just stores player


  protected virtual void Start()
  {
    myCollider = GetComponent<Collider2D>();

  }

  protected virtual void Update()
  {
    myCollider.OverlapCollider(filter, collidedObjects);
    foreach (var o in collidedObjects)
    {
      //  Debug.Log("Collided with " + o.name);
      OnCollided(o.gameObject);
    }
  }

  protected virtual void OnCollided(GameObject collidedObject)
  {
    //  Debug.Log("Collided with " + collidedObject.name);
  }
}

