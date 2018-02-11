using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts.Interfaces;

public class InteractableHint : MonoBehaviour, IInteractableCorutine
{
    public string text;

    private GameObject canvas;
    private Text textArea;
    private bool animating = false;

    private void Start()
    {
        canvas = transform.Find("Canvas").gameObject;
        textArea = canvas.transform.Find("Text").GetComponent<Text>();
    }

    public IEnumerator StartInteract()
    {
        if (animating)
            yield break;
        animating = true;
        canvas.SetActive(true);
        string increasingText = "";
        foreach (var ch in text)
        {
            if (!animating)
                yield break;
            increasingText += ch;
            textArea.text = increasingText;
            yield return new WaitForSeconds(0.02f);
        }
    }
    public IEnumerator StopInteract()
    {
        animating = false;
        canvas.SetActive(false);
        textArea.text = "";
        yield break;
    }
}
