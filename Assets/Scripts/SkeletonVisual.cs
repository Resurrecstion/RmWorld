using UnityEngine;


public class SkeletonVisual : MonoBehaviour
{
    private const string IS_RUNNING = "isRunning";
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>(); 
    }

    private void Update()
    {
        bool isRunning = rb.linearVelocity.magnitude > 0.1f;
        animator.SetBool(IS_RUNNING, isRunning);
        Debug.Log("isRunning: " + isRunning);
    }

    public void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }
}

