using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
     public Rigidbody2D rb;
    public Collider2D coll;
    public Animator anim;
     public float jumpforce = 200;
    public float speed;
      public LayerMask ground;
    public int Tian = 0;
    public Text TianNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement(); 
    }
        void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.deltaTime, rb.velocity.y);
         anim.SetFloat("running", Mathf.Abs(facedirection));
            Debug.Log("moved");
        }
        
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
            Debug.Log("changed");
        }
               
         if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground) )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce* Time.deltaTime ); 
           anim.SetBool("jumping", true);
             Debug.Log("jump");
        }
    }
    void SwitchAnim()
    {
        anim.SetBool("idle", false);

        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
                
            }
        }
         else if (coll.IsTouchingLayers(ground))
            {
                
                anim.SetBool("falling", false);
                anim.SetBool("idle", true);
                 Debug.Log("IsTouchingGround: true");
        }
        else
        {
            Debug.Log("IsTouchingGround: false");
        }
          
        }


   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Collection")
    {
        Destroy(collision.gameObject);
         Debug.Log("Destroy");
         // 当触发器碰到tag为"Collection"的物体时，销毁该物体
       // Tian += 1; 
       // TianNum.text =Tian.ToString();// 增加一个tian的计数
    }else
    {
         Debug.Log(" not Destroy");
    }
    }
}