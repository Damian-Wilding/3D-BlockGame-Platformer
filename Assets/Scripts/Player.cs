using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        //GroundCheck = 
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsPlayerOnTheGround())
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        }
    }

    // Tests to see if the player is on the ground or not
    private bool IsPlayerOnTheGround()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
