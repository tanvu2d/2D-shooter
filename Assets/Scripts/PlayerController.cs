using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Text scoreText;
    Rigidbody2D rb2d;
    Animator animator;
    float speed = 8f;
    float horizontal;
    public bool grounded = true;
    bool duck = false;
    bool faceRight = true;
    bool doubleJump = false;
    public int Health { get { return  currentHealth; } }
    int  currentHealth;
    int maxHealth = 5; 

    public GameObject bulletPrefap;
    public Transform firePoint;
    public Transform firePointDuck;

    float timeDelayShoot = 0.7f;
    bool Shooting = true;
    float timerShoot;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       if (!duck)
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        animator.SetBool("Grounded", grounded);
        animator.SetBool("Duck", duck);
        // 
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * 5000f);
                doubleJump = true;
            }
            else if (doubleJump)
            {
                doubleJump = false;
                rb2d.AddForce(Vector2.up * 4500f);
            }
        }

        if (Input.GetKeyDown (KeyCode.C))
        {
           
            duck = true;
        }
        else if (Input.GetKeyUp (KeyCode.C))
        {
            duck = false;
        }

        if (Input.GetButtonDown ("Fire1"))
        {
            if  (Shooting)
            {
                Shooting = false;
                timerShoot = 0;
                Shoot();
            }
        }
       

         

        if (!Shooting)
        {
            timerShoot += Time.deltaTime;
            if (timerShoot >= timeDelayShoot)
            {
                Shooting = true;
            }
        }

        scoreText.text = score.ToString();
    }

    void FixedUpdate ()
    {
        
        Vector2 position = rb2d.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        rb2d.MovePosition(position);


        if (horizontal > 0 && faceRight == false)
        {
            Flip();

        }
        if (horizontal <0 && faceRight == true )
        {
            Flip();
        }

        if (currentHealth <=0)
        {
            currentHealth = maxHealth;
        }
    }

    void Flip ()
    {
        faceRight = !faceRight;
        Vector3 move = transform.localScale;
        move.x *= -1;
        transform.localScale = move;
    }

    void Shoot ()
    {
        if (!duck)
        {
            GameObject bullet = Instantiate(bulletPrefap, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (faceRight)
            {
                rb.AddForce(firePoint.right * 10f, ForceMode2D.Impulse);
            }
            else if (!faceRight)
            {
                rb.AddForce(firePoint.right * -10f, ForceMode2D.Impulse);
            }
        }
        else if (duck)
        {

            GameObject bullet = Instantiate(bulletPrefap, firePointDuck.position, firePointDuck.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (faceRight)
            {
                rb.AddForce(firePoint.right * 10f, ForceMode2D.Impulse);
            }
            else if (!faceRight)
            {
                rb.AddForce(firePoint.right * -10f, ForceMode2D.Impulse);
            }

        }

    }

    public void Damage (int dame)
    {
        if (dame <0)
        {
            currentHealth += dame;
            UiHealth.instance.Setvalue(currentHealth / (float)maxHealth);
        }
    }

    public  void addGold (int add)
    {
        score += add;
    }
}
