using UnityEngine;

public class Player : MonoBehaviour {

    public float gravity = 9.8f;
    public float speed = 3;
    public float maxSpeed = 10f;
    public float jumpAcc = 1f;

    private float yVelocity = 0f;
    private CharacterController cc;
    private InteractableWithRaycast interacter;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        interacter = GetComponentInChildren<InteractableWithRaycast>();
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
        if (Input.GetKey(KeyCode.E) && interacter.CurrentTarget != null)
        {
            pressLiftUp(interacter.CurrentTarget);
        }
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        pressLiftUp(hit.gameObject);
    }

    private void pressLiftUp(GameObject btnContainer)
    {
        var button = btnContainer.GetComponent<LiftButton>();
        if (button != null)
        {
            button.Press(cc);
        }
    }
}
