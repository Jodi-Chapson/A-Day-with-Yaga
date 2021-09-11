using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Animator playerAnim;

    [Header("Set Variables")] //variables that must be set before the game is played
    public float movespeed = 3f;
    public float diagonalMod = 0.5f;
    public float sprintSpeed; //the variable manipulated in inspector (must be bigger than 1)
    public float lerp;
    public bool canMove;

    [Header("Independent Variables")] //the variables that change without player input
    public float sprintMod; //the changing speed variable
    public Vector3 heading;
    Vector3 forward, right;

    
    
   
    
    
    
    
    

    

    public void Start()
    {
        playerAnim = this.GetComponentInChildren<Animator>();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);


        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        canMove = true;
        sprintMod = 1;
    }

    public void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s"))
        {
            if (canMove)
            {
                Move();
                playerAnim.SetBool("isMoving", true);
            }
        }
        else
        {
            playerAnim.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //is sprinting
            sprintMod = sprintSpeed;
            playerAnim.SetBool("isRunning", true);
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //is not sprinting
            sprintMod = 1;
            playerAnim.SetBool("isRunning", false);
        }

        Vector3 currentheading;

        currentheading.x = Mathf.Lerp(this.transform.forward.x, heading.x, lerp);
        currentheading.y = Mathf.Lerp(this.transform.forward.y, heading.y, lerp);
        currentheading.z = Mathf.Lerp(this.transform.forward.z, heading.z, lerp);

        transform.forward = currentheading;

    }

    public void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMove;
        Vector3 upMove;

        if (direction.x != 0 && direction.z != 0)
        {
            //character is going diagonal
            rightMove = right * movespeed * diagonalMod * sprintMod * Time.deltaTime * Input.GetAxis("HorizontalKey");
            upMove = forward * movespeed * diagonalMod * sprintMod * Time.deltaTime * Input.GetAxis("VerticalKey");
        }
        else
        {
            rightMove = right * movespeed * sprintMod * Time.deltaTime * Input.GetAxis("HorizontalKey");
            upMove = forward * movespeed * sprintMod * Time.deltaTime * Input.GetAxis("VerticalKey");
        }



        heading = Vector3.Normalize(rightMove + upMove);

        //rotates character
        //transform.forward = heading;


        //moves character
        transform.position += rightMove;
        transform.position += upMove;
    }
}
