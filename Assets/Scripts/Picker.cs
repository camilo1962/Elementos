using PurpleCable;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Picker : ElementDisplay, IPointerDownHandler
{
    [SerializeField] AudioClip ClickSound = null;

    public static event Action<ElementDef> ElementPicked;
 #region Android

    

    public void OnPointerDown(PointerEventData eventData)
    {
        
        ClickSound.Play();

        ElementPicked?.Invoke(ElementDef);

        foreach (var animation in GetComponents<SimpleAnimation>())
        {
            animation.StartAnimation();
        }
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            Transform objecthit = hit.transform;
            if (hit.transform.gameObject.tag == "piket")
            {
                Debug.Log("has clicado");
                ClickSound.Play();

                ElementPicked?.Invoke(ElementDef);

                foreach (var animation in GetComponents<SimpleAnimation>())
                {
                    animation.StartAnimation();
                }
            }
        }
    }
    #endregion

    #region PC
    
    private void OnMouseDown()
    {
        ClickSound.Play();
    
        ElementPicked?.Invoke(ElementDef);
    
        foreach (var animation in GetComponents<SimpleAnimation>())
        {
            animation.StartAnimation();
        }
       
    }
    
    #endregion
}   
