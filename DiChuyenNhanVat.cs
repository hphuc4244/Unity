using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DiChuyenNhanVat : MonoBehaviour
{
    
    public Animator hanhdong;

    public float speed = 5f;
    
    private Rigidbody2D player;
    public float jumpSpeed = 8f;

    [SerializeField] private int count=0;
    [SerializeField] private int countgem=0;
    public TMP_Text cherytext;
    public TMP_Text gemtext;


    void Start()
    {  
        player = GetComponent<Rigidbody2D>();
        
       
    }
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {

        
        direction = Input.GetAxis("Horizontal");
        // Debug.Log(direction);
        hanhdong.SetFloat("ChuyenTT",Mathf.Abs(direction));
        Flip();
        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            hanhdong.SetBool("TTNhay",true);
        }
    }
    void FixedUpdate ()
	{

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
        hanhdong.SetBool("TTNhay",false);
	}
    
    private bool isFacingRight = true;
    private float direction = 0f;
    private void Flip()
    {
        if (isFacingRight && direction < 0f || !isFacingRight && direction > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag=="item")
        {
            Destroy(collision.gameObject);
            count +=5;
            cherytext.text = count.ToString();
        }        
        if(collision.gameObject.tag=="gem")
        {
            Destroy(collision.gameObject);
            countgem +=10;
            gemtext.text = countgem.ToString();
        }
    }


    public void OnCollisionEnter2D(Collision2D orther)
    {
        if(orther.gameObject.tag=="Enemy")
        {
            Destroy(orther.gameObject);
        }
    }
}

