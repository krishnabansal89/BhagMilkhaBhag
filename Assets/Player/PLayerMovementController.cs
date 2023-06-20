using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovementController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] LayerMask Turn;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float JumpHeight = 2f;
    [SerializeField] private GameObject obj;
    private float gravity = -50f;
     private CharacterController charactercontroller ; 
     private Vector3 velocity;
     public Transform loc;
     private bool isGrounded;
    private bool isRotateble;
    private bool left;
    private bool right;
    private float horizontalInput;
    private float dir;
    private int i = 0;
    private bool isTurn=false;
    private int y = 1;
    private int x = 0;
    private Vector3 direction;
    
     
    // Start is called before the first frame update
    void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Input.GetAxis("Horizontal");
        horizontalInput = 1;
        
        isGrounded = Physics.CheckSphere(loc.position , 0.1f , groundLayers , QueryTriggerInteraction.Ignore);
        isRotateble = Physics.CheckSphere(loc.position, 0.1f, Turn, QueryTriggerInteraction.Ignore);

        if (!isRotateble)
        {
            isTurn = false;
        }

        if (isGrounded && velocity.y <0)
        {
            velocity.y = 0f;
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(JumpHeight*-2*gravity);
        }
        else
        {
            velocity.y = velocity.y + gravity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && isRotateble)
        {
            Debug.Log("right");

            
            if(!isTurn)
            {
                x = x + 1;
                if (x>3)
                {
                    x = 0;
                }
                isTurn = true;
                transform.Rotate(new Vector3(0f, 90f, 0));
            }
            i = 0;
                right = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && isRotateble)
        {
            i = 0;
            Debug.Log("Left");
            if (!isTurn )
            {
                x = x - 1;
                isTurn = true;
                transform.Rotate(new Vector3(0f, -90f, 0));
            }

            left = true;
        }
        
       if (x == 0)
        {
            charactercontroller.Move(new Vector3(0, 0, horizontalInput * runSpeed) * Time.deltaTime);
        }
        if (x == 1)
        {
            charactercontroller.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
        }
        if (x == 2)
        {
            charactercontroller.Move(new Vector3(0, 0, -horizontalInput * runSpeed) * Time.deltaTime);
        }
        if (x == 3)
        {
            charactercontroller.Move(new Vector3(-horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
        }

        charactercontroller.Move(velocity *Time.deltaTime);
    }
}
