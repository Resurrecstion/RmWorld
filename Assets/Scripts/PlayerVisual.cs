using System;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";
    
    public Animator animator;
    public SpriteRenderer spriteRenderer; 

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.instance.IsRunning());
        AdjistPlayerFacingDirection();
    }

    private void AdjistPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.instance.GetMousePosition();
        Vector3 playerPositiom = Player.instance.GetPlayerScreenPosition();

        if (mousePos.x > playerPositiom.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true; 
        }
    }

}
