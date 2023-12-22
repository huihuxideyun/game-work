using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float destructionDelay = 20.0f; 
    public float collisionDestructionDelay = 0.5f; 
    public string playerTag = "Player";

    void Start()
    {
        Destroy(gameObject, destructionDelay);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Destroy(gameObject, collisionDestructionDelay);
        }
    }
}