using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float gravity = 9.8f;
    public float speed = 3;
    public float maxSpeed = 10f;
    public float jumpAcc = 1f;

    private float yVelocity = 0f;
    private CharacterController cc;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        if (cc.isGrounded && Input.GetKey(KeyCode.Space))
        {
            yVelocity = jumpAcc;
        }

        if (x != 0 || z != 0 || !cc.isGrounded || yVelocity > 0)
        {
            var velocity = transform.TransformDirection(new Vector3(x * speed * Time.deltaTime, yVelocity, z * speed * Time.deltaTime));
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

            if (!cc.isGrounded)
            {
                yVelocity -= gravity * Time.deltaTime;
            }
            cc.Move(velocity);
        }
        
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var button = hit.gameObject.GetComponent<LiftButton>();
        if (button != null)
        {
            button.LiftUp(cc);
        }
    }
}
