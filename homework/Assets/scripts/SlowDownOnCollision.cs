using UnityEngine;
using System.Collections; 
public class SlowDownOnCollision : MonoBehaviour
{
    public string targetTag = "food"; 
    public float slowDownFactor = 0.5f;     
    public float slowDownDuration = 1.0f;   

    private Animator animator;               

    void Start()
    {

        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(targetTag))
        {
            StartCoroutine(SlowDown());
        }
    }

    IEnumerator SlowDown()
    {
        animator.speed *= slowDownFactor;

        yield return new WaitForSeconds(slowDownDuration);

        animator.speed /= slowDownFactor;
    }
}