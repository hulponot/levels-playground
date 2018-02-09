using UnityEngine;

public class LiftBehaviour : MonoBehaviour {

    public int speed = 1;
    public float floorHigh = 5;
    public float high;
    public float epsilon = 0.005f;

    private float minY;
    private float destination = 0;
    private int direction = 0;
    private CharacterController buttonPresser;

    private void Start()
    {
        high = transform.position.y;
        destination = high;
        minY = high;
    }

    public void Lifting(CharacterController presser,int newDirection)
    {
        if (direction != 0)
        {
            return;
        }
        direction = newDirection;
        destination = high + floorHigh * direction;

        if (destination < minY)
        {
            direction = 0;
            return;
        }
        buttonPresser = presser;
    }

    public void Update()
    {
        if (direction != 0)
        {
            if ( direction > 0 && destination < high)
            {
                StopLifting();
            }
            else if (direction < 0 && destination > high)
            {
                StopLifting();
            }
            else
            {
                ContinueLifting();
            }
        }
            
    }

    private void StopLifting()
    {
        direction = 0;
        buttonPresser = null;
    }

    private void ContinueLifting()
    {
        
        var pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + speed * Time.deltaTime * direction, pos.z);
        if (buttonPresser != null)
        {
            buttonPresser.Move(new Vector3(0, speed * Time.deltaTime * direction, 0));
        }
        high = pos.y;
    }

}
