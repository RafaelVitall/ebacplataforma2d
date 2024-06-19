using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    //DECLARAÇÕES   
    public Rigidbody2D rb;

    public Vector2 friction = new Vector2(.1f, 0f);

    public float speed;
    public float speedRun;

    public float forceJump = 2f;

    float _currentSpeed;

    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.75f;
    public float animDuration = .3f;
    public float splashDuration = .3f;
    public Ease ease = Ease.OutBack;
    private void Update()
    {
       HandleJump();
       HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.Z))
            _currentSpeed = speedRun;
        else _currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);

            //rb.MovePosition(rb.position - velocity * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);


            //rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        if(rb.velocity.x > 0)
        {
            rb.velocity -= friction;
        }
        else if(rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }
    }

    void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * forceJump;
            rb.transform.localScale = Vector2.one;

            DOTween.Kill(rb.transform);

            HandleScaleJump();
            //HandleSplashScale();
        }
    }

    void HandleScaleJump()
    {
        rb.transform.DOScaleY(jumpScaleY, animDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    void HandleSplashScale()
    {
        rb.transform.DOScaleX(jumpScaleY, splashDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleY(jumpScaleX, splashDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
