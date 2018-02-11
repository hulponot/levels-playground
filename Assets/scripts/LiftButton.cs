using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour {
    public LiftBehaviour lift;
    public int direction = 1;

    private float pressOffset = -0.15f;
    private float originXPosition;
    private bool pressed = false;
    private float returnSpeed = 0.01f;
    private GameObject player;

    public void Start()
    {
        originXPosition = transform.position.x;
    }

    public void Press(CharacterController player)
    {
        if (!pressed)
        {
            pressed = true;
            ButtonPull();
            Action(player);
            StartCoroutine(ButtonPressAnimation());
        }
    }

    private void Action(CharacterController player)
    {
        lift.Lifting(player, direction);
    }

    private void ButtonPull()
    {
        var pos = transform.position;
        transform.position = new Vector3(pos.x + pressOffset, pos.y, pos.z);
    }

    private IEnumerator ButtonPressAnimation()
    {
        for (var offseted = transform.position.x;
            originXPosition - offseted > 0; 
            offseted += returnSpeed)
        {
            transform.Translate(returnSpeed, 0,0);
            yield return null;
        }
        pressed = false;
    }
}
