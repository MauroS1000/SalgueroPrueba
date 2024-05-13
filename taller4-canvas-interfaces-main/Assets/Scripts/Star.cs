using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
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
        Destroy(gameObject);
    }
}
