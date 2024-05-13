using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController3D : MonoBehaviour
{
    public float moveSpeed = 5f;    // Velocidad de movimiento del jugador
    public float jumpForce = 10f;   // Fuerza de salto del jugador
    public float gravity = 50;
    private Rigidbody rb;
    private bool isGrounded;
    private bool canDoubleJump = false;
    private float hInput;
    private Transform spawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPoint = GameObject.Find("Spawn").transform;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(hInput * moveSpeed, rb.velocity.y, rb.velocity.z);
    }
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        if (isGrounded)
        {
            canDoubleJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                isGrounded = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                canDoubleJump = false;
            }
            rb.velocity += new Vector3(Mathf.Epsilon, -gravity * Time.deltaTime, Mathf.Epsilon);
        }
        if (transform.position.y <= -10)
        {
            transform.position = spawnPoint.position;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}