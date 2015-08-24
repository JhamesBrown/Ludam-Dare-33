using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
    private Rigidbody2D rb;
    private Animator anim;    
    private bool facingRight = true;

    private SpriteRenderer spriRend;


    private bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    private float jumpForce = 300.0f;
    private float speed = 10.0f;

    public GameObject bloodPixel;

    private bool dead;
    public GameObject deadText;
    private int prevHealth;

	void Start () 
	{
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriRend = GetComponentInChildren<SpriteRenderer>();
        SceneManager.health = 10;
        dead = false;
        prevHealth = SceneManager.health;
        deadText.SetActive(false);
	}	
	
	void FixedUpdate () 
	{
        if (dead == false)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
            anim.SetBool("Ground", grounded);

            movement();
        }
        
	}

    void Update ()
    {
        if (prevHealth != SceneManager.health)
        {
            spriRend.color = new Color(1.0f, 0.0f, 0.0f);
            prevHealth = SceneManager.health;
        }
        else
        {
            spriRend.color = new Color(1.0f, 1.0f, 1.0f);
        }

        if (dead == false)
        {
            if (grounded && Input.GetButtonDown("Jump"))
            {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0f, jumpForce));
            }           
        }
        if (dead)
        {
            deadText.SetActive(true);
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }


        anim.SetInteger("Health", SceneManager.health);
        if (SceneManager.health <= 0)
        {
            dead = true;
        }
    }

    void movement()
    {
        anim.SetFloat("Vspeed", rb.velocity.y);


        float translation = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(translation * speed,rb.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(translation));

        if (translation > 0 && !facingRight)
            flip();
        else if (translation < 0 && facingRight)
            flip();      

    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyHitBox")
        {
            for (int i = 0; i < 100; i++)
            {
                Instantiate(bloodPixel, col.transform.position, Quaternion.identity);
            }
            GameObject.Find("AudioManager").GetComponent<AudioManager>().AudSource.PlayOneShot(GameObject.Find("AudioManager").GetComponent<AudioManager>().sounds[1]);
            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="FreedomDoor")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }      
}
