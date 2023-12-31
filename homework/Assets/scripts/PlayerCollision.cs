using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("scoreItem"))
        {
            gameManager.winplay();
            gameManager.AddScore();
            Destroy(other.gameObject); 
        }
        else if (other.gameObject.CompareTag("food"))
        {
            gameManager.loseplay();
            gameManager.TakeDamage();
        }
    }
}