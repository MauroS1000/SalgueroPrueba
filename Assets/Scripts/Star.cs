using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    public float gravity = 50;
    private Rigidbody rb;
    public float jumpForce = 10f;
    public float disappearTime;
    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 0.0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

    }
    void Update()
    {
        timer += Time.deltaTime;

        
        if (timer >= disappearTime)
        {
            
            Destroy(gameObject);
        }
    }
}

