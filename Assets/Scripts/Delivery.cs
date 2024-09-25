using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    [SerializeField] float delayToDelete = 0.5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("We hit something.");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
        Debug.Log ("We collected a package.");
        hasPackage = true;
        spriteRenderer.color = hasPackageColor;
        Destroy(other.gameObject, delayToDelete);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log ("Package delivered.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
    
}
