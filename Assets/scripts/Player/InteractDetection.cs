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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        { 
            _isInTrigger = false;
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
        RaycastHit2D hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Clicked");
            }
        }
    }
}