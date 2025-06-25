using UnityEngine;
using UnityEngine.InputSystem;
public class SwordAttack : MonoBehaviour
{
    private Animator animator;
    private bool isDownSlash = true; 

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Теперь GameInput точно уже создан
        GameInput.instance.PlayerInputActions.Combat.Attack.performed += OnAttack;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack performed!");

            if (isDownSlash)
                animator.SetTrigger("SwordSwingDown");
            else
                animator.SetTrigger("SwordSwingUp");

            isDownSlash = !isDownSlash;
        }
    }
}

