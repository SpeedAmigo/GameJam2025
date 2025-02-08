using UnityEngine;

public class InteractDetection : MonoBehaviour
{
    private CircleCollider2D collider2D;
    private bool _isInTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        { 
            _isInTrigger = true;
            Debug.Log("Kolizja");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isInTrigger)
        {
            ClickEnemy();
        }
    }

    private void ClickEnemy()
    {

    }
}
