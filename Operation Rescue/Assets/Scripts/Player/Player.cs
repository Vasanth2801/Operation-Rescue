using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [Header("Inputs")]
    [SerializeField] private float moveInputX;
    [SerializeField] private float moveInputY;
    [SerializeField] private Vector2 mousePos;

    void Update()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        MouseLook();
    }

    void FixedUpdate()
    {
        Move();
    }

    void  Move()
    {
        rb.linearVelocity = new Vector2(moveInputX * speed, moveInputY * speed);
    }

    void MouseLook()
    {
        Vector2 direction = mousePos - rb.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}