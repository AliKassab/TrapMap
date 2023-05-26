using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rgd;
    private BoxCollider2D bc;
    private new Animator animation;
    private SpriteRenderer spr;

    

    [SerializeField] private AudioSource Jumpsound;

    [SerializeField] private LayerMask GroundJump;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpforce = 14f;
    bool jumping = false;

    private enum MoveState {Idle, Run, Jump, Fall};
    
   private void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();    
    }
    
   private void Update()
    {

        float direction = Input.GetAxisRaw("Horizontal");
        rgd.velocity = new Vector2(direction * speed, rgd.velocity.y) ;

        if(Input.GetButtonDown("Jump") && grounded())
        {
            Jumpsound.Play();
            rgd.velocity = new Vector2(rgd.velocity.x, jumpforce);
        }
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        AnimationState(direction);

        if (Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(4);
        }

    }

    private void AnimationState(float direction)
    {
        MoveState state;

        if (direction > 0)
        {
            state = MoveState.Run;
            spr.flipX = false;
        }
        else if (direction < 0)
        {
            state = MoveState.Run;
            spr.flipX = true;
        }
        else
        {
            state = MoveState.Idle;
        }

        if (rgd.velocity.y > 0.1f)
        {
            state = MoveState.Jump;
        }
        
        else if (rgd.velocity.y < -0.1f)
        {
            state = MoveState.Fall;
        }

        animation.SetInteger("state", (int)state);
    }

    private bool grounded()
    {
       return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, GroundJump);
    }
}
