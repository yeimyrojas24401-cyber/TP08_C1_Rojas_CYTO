using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator animator;

    private const float WalkThreshold = 0.1f;
    private const float JumpThreshold = 0.5f;

    private int currentState;

    private void Update()
    {
        if (!playerMovement.IsGrounded)
        {
            if (rb.linearVelocity.y > JumpThreshold)
            {
                PlayAnimation(AnimatorStates.Jump);
            }
            else if (rb.linearVelocity.y < -JumpThreshold)
            {
                PlayAnimation(AnimatorStates.Fall);
            }
        }
        else
        {
            if (Mathf.Abs(rb.linearVelocity.x) > WalkThreshold)
            {
                PlayAnimation(AnimatorStates.Walk);
            }
            else
            {
                PlayAnimation(AnimatorStates.Idle);
            }
        }

    }
    private void PlayAnimation(int state)
    {
        if (state == currentState) return;
        animator.Play(state);
        currentState = state;
    }
}
