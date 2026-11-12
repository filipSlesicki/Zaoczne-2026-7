using UnityEngine;
using UnityEngine.InputSystem;

public class Player2D : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int points;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float horizontalBounds = 9.5f;
    private InputAction moveInput;

    public void ChangeHealth(int amount)
    {
        health += amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = moveInput.ReadValue<Vector2>();
        if (transform.position.x > horizontalBounds && moveDirection.x > 0)
        {
            moveDirection.x = 0;
        }

        transform.position += new Vector3(moveDirection.x, moveDirection.y) * speed * Time.deltaTime;

        if (transform.position.x < -horizontalBounds)
        {
            Vector3 pos = transform.position;
            pos.x = -horizontalBounds;
            transform.position = pos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Entered trigger: " + other.gameObject.name);
    }
}
