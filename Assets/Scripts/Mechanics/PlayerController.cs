using UnityEngine;
using Platformer.Gameplay;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
using Platformer.Model;

public class PlayerController : KinematicObject
{
    [SerializeField] private Projectile fireball;
    [SerializeField] private Transform fireballSpawnPosition;
    public AudioClip jumpAudio;
    public AudioClip respawnAudio;
    public AudioClip ouchAudio;

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    public JumpState jumpState = JumpState.Grounded;
    private bool stopJump;
    public Collider2D collider2d;
    public AudioSource audioSource;
    public Health health;
    public bool controlEnabled = true;
    
    bool jump;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    internal Animator animator;
    readonly PlatformerModel model = GetModel<PlatformerModel>();
    private static readonly int Grounded = Animator.StringToHash("grounded");
    private static readonly int VelocityX = Animator.StringToHash("velocityX");
    
    Vector2 v = Vector2.right;


    public Bounds Bounds => collider2d.bounds;


    private void Awake()
    {
        health = GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        if (controlEnabled)
        {
            move.x = Input.GetAxis("Horizontal");

            v = move.x switch
            {
                < 0 => Vector2.left,
                > 0 => Vector2.right,
                _ => v
            };

            if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
            {
                jumpState = JumpState.PrepareToJump;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                stopJump = true;
                Schedule<PlayerStopJump>().player = this;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                Cast();
            }
        }
        else
        {
            move.x = 0;
        }
        UpdateJumpState();
        base.Update();
    }


    void UpdateJumpState()
    {
        jump = false;
        switch (jumpState)
        {
            case JumpState.PrepareToJump:
                jumpState = JumpState.Jumping;
                jump = true;
                stopJump = false;
                break;
            case JumpState.Jumping:
                if (!IsGrounded)
                {
                    Schedule<PlayerJumped>().player = this;
                    jumpState = JumpState.InFlight;
                }
                break;
            case JumpState.InFlight:
                if (IsGrounded)
                {
                    Schedule<PlayerLanded>().player = this;
                    jumpState = JumpState.Landed;
                }
                break;
            case JumpState.Landed:
                jumpState = JumpState.Grounded;
                break;
        }
    }

    protected override void ComputeVelocity()
    {
        if (jump && IsGrounded)
        {
            velocity.y = jumpTakeOffSpeed * model.jumpModifier;
            jump = false;
        }
        else if (stopJump)
        {
            stopJump = false;
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * model.jumpDeceleration;
            }
        }

        spriteRenderer.flipX = move.x switch
        {
            > 0.01f => false,
            < -0.01f => true,
            _ => spriteRenderer.flipX
        };

        animator.SetBool(Grounded, IsGrounded);
        animator.SetFloat(VelocityX, Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }
    
    private void Cast()
    {
        var projectile = Instantiate(fireball);
        projectile.transform.position = fireballSpawnPosition.position + (Vector3) move.normalized;
        projectile.Throw(v);
    }
    
    public void Disable()
    {
        controlEnabled = false;
    }
}