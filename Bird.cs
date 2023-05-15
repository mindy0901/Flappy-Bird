using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    private CustomInput input;
    public Rigidbody2D rb;
    public GameManager gameManager;
    private bool isGameStarted = false;
    private bool hasGameStarted = false;

    // bird info
    public float flapStrength = 5f;
    private bool isBirdAlive = true;

    // bird rotation
    private int angle;
    public int maxAngle = 10;
    public int minAngle = -30;

    private void Awake()
    {
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Bird.Flap.started += BirdFlap;

        transform.rotation = Quaternion.Euler(Vector3.zero);
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Bird.Flap.started -= BirdFlap;
    }

    private void Start() { }

    private void Update()
    {
        if (isGameStarted && !hasGameStarted)
        {
            gameManager.Play();
            hasGameStarted = true;
        }
        BirdRotation();
    }

    private void BirdFlap(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            rb.velocity = Vector2.up * flapStrength;
            if (!isGameStarted)
            {
                isGameStarted = true;
            }
        }
    }

    private void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < 0)
        {
            if (rb.velocity.y < -1.3f)
            {
                if (angle >= minAngle)
                {
                    angle = angle - 3;
                }
            }
        }
        if (isGameStarted && hasGameStarted)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver();
            isGameStarted = false;
            hasGameStarted = false;
        }
        else if (other.gameObject.tag == "Middle")
        {
            gameManager.IncreaseScore();
        }
    }
}
