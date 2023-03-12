using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] float Run_Speed = 7f;
    [SerializeField] float Jump_Power = 14f;
    [SerializeField] private LayerMask jumpableGround;
    private float dirx = 0f;
    [SerializeField] AudioSource JumpSoundEffect;
    
    private enum Movement_State { Idle , Running , Jumping , Falling}




    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
       dirx = Input.GetAxisRaw("Horizontal");
       rb.velocity = new Vector2 (dirx * Run_Speed , rb.velocity.y );
       if(Input.GetButtonDown("Jump") && IsGrounded())
       {
        JumpSoundEffect.Play();
        rb.velocity =  new Vector2 (rb.velocity.x , Jump_Power );
       } 
       AnimationUpdate();

    }
    private void AnimationUpdate()
    {
       Movement_State state;

       if ( dirx > 0f ){
        state = Movement_State.Running;
        sprite.flipX = false;
        }
       else if (dirx < 0f )
        {
        state = Movement_State.Running ;       
        sprite.flipX = true;
        }
        else
        {
            state = Movement_State.Idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = Movement_State.Jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = Movement_State.Falling;
        }

        anim.SetInteger("State",(int)state );
    }
   private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
