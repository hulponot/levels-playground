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

    public void LiftUp(CharacterController player)
    {
        if (!pressed)
        {
            lift.Lifting(player, direction);
            ButtonPressed();
        }
    }

    private void ButtonPressed()
    {
        pressed = true;
        var pos = transform.position;
        transform.position = new Vector3(pos.x + pressOffset, pos.y, pos.z);
        StartCoroutine(ButtonReturn());
    }
    private void ButtonReleased()
    {
        pressed = false;
    }

    private IEnumerator ButtonReturn()
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
