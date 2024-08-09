using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    public float moveSpeed;

    public Rigidbody2D rb;
    //public Camera cam;

    Vector2 movement;
    //Vector2 mousePos;

    public Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

         
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //Vector2 lookDir = mousePos - rb.position;
     //   float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
       // rb.rotation = angle;

    }
}
