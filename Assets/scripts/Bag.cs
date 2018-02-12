using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour {
    public enum ColorEnum { Red = 0, Yellow = 1, Blue = 2 };

    public Text textArea;
    private List<ICollactable> content;

    private void Start()
    {
        content = new List<ICollactable>();
    }

    public IEnumerable<String> GetStringsContent()
    {
        return content.Select( c => c.GetName());
    }

    public void PlaceInBag(ICollactable thing)
    {
        if (!content.Contains(thing))
        {
            content.Add(thing);
            UpdateText();
        }
    }

    public void UpdateText()
    {
        textArea.text = "Items collected: " + String.Join(", ", GetStringsContent().ToArray());
            
    }
}
