using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D _body;
    private Vector2 _movement;
    [SerializeField] private Vector2 _lastMove;
    private Animator _animator;
    
    [Range(1, 5)]
    [SerializeField] private float _speed;

    
    // Set input values to Vector2
    private void HandleInput()
    {
        if (GameStateManager.CurrentGameState != GameState.InGame)
        {
            _movement = Vector2.zero;
            return;
        }

        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (_movement != Vector2.zero)
        {
            _lastMove = _movement;
        }
        
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
        _animator.SetFloat("LastHorizontal", _lastMove.x);
        _animator.SetFloat("LastVertical", _lastMove.y);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
