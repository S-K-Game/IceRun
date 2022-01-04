using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovment : MonoBehaviour
{
    public HealthBar healthBar;
    public int HitPoints;
    public int MaxHitPoints = 5;
    [SerializeField] string sceneName;
    private bool firstTime = true;


    [SerializeField] private float jumpHigh=14f;
    public float speed=0f;
    private Animator animator;
    private Rigidbody2D rb;
    public bool onPlatform=false;
    public bool isSlide=false;
    public bool isJummping=false;
    public bool dead=false;
    private int currentCol;
    private ColdBar coldBar;
    private int maxCold = 200 ;
    private bool timePass = true;



    [SerializeField] private string triggeringTag = "Snow" ;

    
    // Start is called before the first frame update
    void Start()
    {
        HitPoints = MaxHitPoints;
        healthBar.SetMaxHealth(MaxHitPoints);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        currentCol = maxCold;
        coldBar = GameObject.Find("ColdBar1").GetComponent<ColdBar>();
        coldBar.setMax(currentCol);
    }

    void FixedUpdate()
    {

          
        
        if(!onPlatform && !dead)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if(timePass){
                firstTime = true;
                StartCoroutine(waitForDamage());
                TakeDamage(5);
            }

            if (coldBar.getCold() == 0)
            {
                animator.SetTrigger("trap");
                StartCoroutine(toDie());
                if (firstTime)
                {
                    firstTime = false;
                    TakeHit(1);
                }
            }
        }
        AnimationUpdater();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == triggeringTag) {
            speed=3f;
            rb.constraints = RigidbodyConstraints2D.None;
        }
        
    }


    private void AnimationUpdater(){
        string StateName="";
        if(Input.GetKey(KeyCode.UpArrow) && !isJummping){
            
            rb.AddForce(new Vector2(0, 1f));
            offJump();
            StateName="jump";
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            offSlide();
            StateName="slide";
            

        }
        if(StateName!="")
            animator.SetTrigger(StateName);
    }

    public void offPlatform(){
        StartCoroutine(SpeedBoost());
    }

    public void offSlide(){
        StartCoroutine(SpeedSilde());
    }

    public void offJump(){
        StartCoroutine(waitSome());
    }

     private IEnumerator SpeedSilde(){
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        speed=8f;
        yield return new WaitForSeconds(0.25f);
        rb.constraints = RigidbodyConstraints2D.None;
        speed=3f;
    }

    private IEnumerator SpeedBoost(){
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        speed=4f;
        yield return new WaitForSeconds(3f);
        speed=3f;
        rb.constraints = RigidbodyConstraints2D.None;
    }
    private IEnumerator waitSome(){
        isJummping = true;
        speed = 4f;
        yield return new WaitForSeconds(1f);
        speed = 3f;
        isJummping=false;
    }

    private IEnumerator waitForDamage(){
        timePass = false;
        yield return new WaitForSeconds(3f);
        timePass = true;
    }


    private void TakeDamage (int Damage){
        currentCol -= Damage;
        coldBar.setCold(currentCol);
    }

    private IEnumerator toDie(){
        yield return new WaitForSeconds(1f);
       currentCol = maxCold;
       coldBar.setCold(maxCold);
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
   }
    public void TakeHit(int damage)
    {
        HitPoints -= damage;
        healthBar.SetHealth(HitPoints);
        if (HitPoints <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
