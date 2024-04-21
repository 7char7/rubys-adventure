using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    
    public int maxHealth = 5;
    
    public GameObject projectilePrefab;
    
    public static int enemyCounter = 0;
    public static int healthReal = 5;
    public managerScript gameManager;
    public int death = 0;
    public ParticleSystem HealthUp;
    public ParticleSystem HealthDown;

    public int health { get { return currentHealth; }}
    int currentHealth;
    
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        death = 0;
        currentHealth = maxHealth;
        enemyCounter = 0;
        HealthUp.Stop();
        HealthDown.Stop();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
   
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f)&& death == 0 || !Mathf.Approximately(move.y, 0.0f) && death == 0)
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        
        if(enemyCounter == 3 && death ==0)
        {
            death += 1;
            gameManager.gameWonUI();
        }

        if(Input.GetKeyDown(KeyCode.R) && death == 1)
        {
  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            death = 0;
        }

        if(Input.GetKeyDown(KeyCode.C) && death == 0)
        {
            Launch();
            HealthUp.Play();
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.5f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
    }
    
    void FixedUpdate()
    {
        if (death == 0)
       { Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        if (amount < 0)
        {
            Instantiate(HealthDown, transform.position, transform.rotation);
        }
        else 
        {
            Instantiate(HealthUp, transform.position, transform.rotation);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
  
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);



        if(currentHealth == 0 && death ==0)
        {
            death += 1;
            gameManager.gameLostUI();
        }
    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}