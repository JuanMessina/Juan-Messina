using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonPlayerController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float jumpSpeed;
    public float jumpForce;
    public Rigidbody rb;
    public bool grounded = true;
    public EnemyController enemyController;
    public ChestController chestController;
    public float damage = 1f;
    public float playerLife = 10f;
    public GameObject player;
    public Animator animations;
    public bool movimiento = false;
    public float velocidad;
    public int maxHealth = 100;
    public int currentHealth;
    public Coroutine playerAttackCoroutine;

    
   
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody>();
        animations = GetComponent<Animator>();
        
    }

    void Update()
    {
        PlayerMovement();

        if (grounded == true)
        {
            Jump();
            
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        if (playerLife <= 0)
        {
            Die();
        }

        if (Input.GetMouseButtonDown(0))
        { 
            animations.SetTrigger("Ataque");
        }

        if (grounded == false)
        {
            animations.SetBool("grounded", grounded);
        }

        if (grounded == true)
        {
            animations.SetBool("grounded", grounded);
        }

        healthBar.SetHealth(playerLife);
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0, ver) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        

            if (ver != 0)
            {
                animations.SetFloat("movimiento", Mathf.Abs(ver));
            }
            
            if (hor != 0)
            {
                animations.SetFloat("movimiento", Mathf.Abs(hor));
            }
            
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, 5, 0) * jumpForce, ForceMode.Impulse);
            grounded = false;
            speed = jumpSpeed;
        }


    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            grounded = true;
            speed = maxSpeed;
            
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (col.gameObject.tag == "Enemy")
            {
                if (playerAttackCoroutine == null)
                {
                    animations.SetTrigger("Ataque");
                    StartCoroutine("AtaquePlayer");
                }
                


            }
                
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (col.gameObject.tag == "Chest")
            {
                chestController.OpenAnimation();
            }
        }
    }

    public IEnumerator AtaquePlayer()
    {
        enemyController.enemyLife = enemyController.enemyLife - damage;
        yield return new WaitForSeconds(0.5f);
       playerAttackCoroutine = null;

    }
    
        
        
    

    void Die()
    {
        Destroy(gameObject);
       // Instantiate(player,new Vector3 (1f, 1f, 1f),Quaternion.identity);

    }

    

}
