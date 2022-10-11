using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class portal : MonoBehaviour
{
    [SerializeField] float speedMove =1f;
    Rigidbody2D myRid;
    BoxCollider2D myBox;
    void Start()
    {
        myRid =  GetComponent<Rigidbody2D>();
        myBox = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if(IsFacingLeft())
        {
            myRid.velocity = new Vector2(-speedMove,0f);
        }
        else
        {
            myRid.velocity =  new Vector2(speedMove,0f);
        }
    }
    private bool IsFacingLeft()
    {
        return transform.localScale.x>Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D other) {
        transform.localScale = new Vector2((Mathf.Sign(myRid.velocity.x)), transform.localScale.y);
    }
}
