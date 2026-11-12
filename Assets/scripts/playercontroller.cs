using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed;
    public Animator playerAnimator;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D _rigidbody2D;
    private float horizontalInput;
    private bool isJumpPressed;
    

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput =
            Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }
        Debug.Log("Horizontal Input: " + horizontalInput);
        playerAnimator.SetFloat("speed", Mathf.Abs(_rigidbody2D.linearVelocity.x));

        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }


    private void FixedUpdate()
    {
        float x = horizontalInput * moveSpeed;
        float y = _rigidbody2D.linearVelocity.y;
        _rigidbody2D.linearVelocity = new Vector2(x,y);

        if (isJumpPressed)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, jumpForce);
            isJumpPressed = false;
              }
    }
}
