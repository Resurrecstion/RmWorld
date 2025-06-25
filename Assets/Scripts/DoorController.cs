using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D col;

    void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;
    }

    public void SetOpen(bool open)
    {
        anim.SetBool("isOpen", open);
        col.enabled = open;
    }
}
