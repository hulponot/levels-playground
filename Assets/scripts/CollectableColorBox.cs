using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Interfaces;

public class CollectableColorBox : MonoBehaviour, ICollactable
{
    public Bag bag;
    public Bag.ColorEnum color;
    public List<Material> colorMaterials;

    private void Start()
    {
        SetColorMaterial();

        StartCoroutine(BoxRotation());
    }
    public void Collect()
    {
        bag.PlaceInBag(this);
        gameObject.SetActive(false);
    }
    public string GetName()
    {
        return color.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        Collect();
    }
  
    private void SetColorMaterial()
    {
        var render = GetComponent<Renderer>();
        render.material = colorMaterials[(int)color];
    }

    public IEnumerator BoxRotation()
    {
        while (isActiveAndEnabled)
        {
            transform.Rotate(new Vector3(0.2f, 0.1f, 0.5f));
            yield return null;
        }
        yield break;
    }
}
