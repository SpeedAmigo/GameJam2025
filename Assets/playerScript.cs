using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D _body;
    private Vector2 _movement;
    
    [Range(1, 5)]
    [SerializeField] private float _speed;

    
    // Set input values to Vector2
    private void HandleInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        _body.velocity = new Vector2(_movement.x, _movement.y).normalized * (_speed * 100 * Time.deltaTime);
    }
}
