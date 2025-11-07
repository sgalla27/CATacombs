using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExploration : MonoBehaviour {

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;
    Vector2 lastDirection;

    void Start(){
        lastDirection = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if(movement.sqrMagnitude > 0){
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            lastDirection = movement.normalized;
        } else {
            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    void onCollisionEnter2D(Collision2D collision){
        Vector2 bumpDirection = collision.transform.position - transform.position;
        collision.gameObject.GetComponent<BasketballController>().Bump(bumpDirection);
    }
}