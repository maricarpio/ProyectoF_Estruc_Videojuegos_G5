using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character2DController : MonoBehaviour
{
    readonly object _lock = new object();
    static Character2DController _instance;

    public static  Character2DController Instance
    {
        get
        {
            return _instance;
        }
    }


    [SerializeField]
    float moveSpeed = 300.0F;

    [SerializeField]
    float jumpForce = 140.0F;

    [SerializeField]
    float jumpGraceTime = 0.20F;

    [SerializeField]
    float fallMultiplier = 3.0F;

    private Rigidbody2D _rb;

    [SerializeField]
    bool isFacingRight = true;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask groundMask;



    float _inputMovimiento;

    bool _isMoving;

    bool _isJumpPressed;

    bool _isGrounded;

    float _gravityY;

    float _lastTimeJumpPressed;




     void Awake()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = this;
                }
            }
        }


        _rb = GetComponent<Rigidbody2D>();
        _gravityY = -Physics2D.gravity.y;
    }

    void Update()
    {
        ProcesarMovimiento();
    }

     void FixedUpdate()
    {
        HandleMove();
        HandleJump();

    }

     void HandleJump()
    {
        if(_lastTimeJumpPressed > 0.0F && Time.time - _lastTimeJumpPressed <= jumpGraceTime)
        {
            _isJumpPressed = true;
        }
        else
        {
            _lastTimeJumpPressed = 0.0F;
        }


        if (_isJumpPressed)
        {
            _isGrounded = IsGrounded();
            if (_isGrounded)
            {
                _rb.velocity += Vector2.up * jumpForce * Time.fixedDeltaTime;
            }
            
        }

        if(_rb.velocity.y < -0.01F)
        {
            _rb.velocity -= Vector2.up * _gravityY * fallMultiplier * Time.fixedDeltaTime;
        }
    }

     bool IsGrounded()
    {
        return
            Physics2D.OverlapCapsule(
                groundCheck.position, new Vector2(0.63F,0.4F),
                CapsuleDirection2D.Horizontal, 0.0F, groundMask);
    }

    void HandleMove()
    {
        float velocityX = _inputMovimiento * moveSpeed *Time.fixedDeltaTime;

        _rb.velocity = new Vector2(velocityX, _rb.velocity.y);
    }

    void ProcesarMovimiento()
    {
        // Logica de Movimiento
         _inputMovimiento= Input.GetAxisRaw("Horizontal");
         _isMoving = _inputMovimiento != 0.0F;

        GestionarOrientacion(_inputMovimiento);
        _isJumpPressed = Input.GetButtonDown("Jump");
        if (_isJumpPressed)
        {
            //Comienza el calculo de Coyote Time
            _lastTimeJumpPressed = Time.time;   
        }
    }

    void GestionarOrientacion(float inputmovimiento)
    {
        if ((isFacingRight == true && inputmovimiento < 0) || (isFacingRight == false && inputmovimiento > 0))
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
  
}