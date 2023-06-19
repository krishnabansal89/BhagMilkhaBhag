using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovementController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float JumpHeight = 2f;
     private float gravity = -50f;
     private CharacterController charactercontroller ; 
     private Vector3 velocity;
     public Transform loc;
     private bool isGrounded;
     private float horizontalInput;
     
    // Start is called before the first frame update
    void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = 1;
        loc.forward = new Vector3(horizontalInput , 0 ,Mathf.Abs(horizontalInput)-1);
        isGrounded = Physics.CheckSphere(loc.position , 0.1f , groundLayers , QueryTriggerInteraction.Ignore);
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
        charactercontroller.Move(new Vector3(0,0,horizontalInput*runSpeed)*Time.deltaTime);

        charactercontroller.Move(velocity *Time.deltaTime);
    }
}
