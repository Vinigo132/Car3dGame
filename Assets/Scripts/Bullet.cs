using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private float speed = 100f;

    //private int score;
    //public Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Alvo"))
        {
            GameManager.Instance.AddScore(); // Adiciona +1 ao score global
            Destroy(collision.gameObject);  // Destroi o alvo
            Destroy(gameObject);  // Destroi a bala
        }        

    }
}
