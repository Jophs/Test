﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public bool guardPlayed = false;
    public GuardEffectScript guardEffectSript;



    public void Start()
    {
        guardEffectSript = GameObject.Find("Guard").GetComponent<GuardEffectScript>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       // Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // Debug.Log("OnPointerExit");
    }


    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;

            // If Guard is played, activate GuardEffect
            if (eventData.pointerDrag.name.Contains("Guard") && gameObject.name.Contains("Tabletop")) 
            {
                //guardPlayed = true;
                //Debug.Log(guardPlayed);

                guardEffectSript.showPanel();
            }

            /* if (eventData.pointerDrag.name.Contains("Guard") && gameObject.name.Contains("Hand"))
            {
                guardPlayed = false;
                Debug.Log(guardPlayed);
            } */

        }

    }


}
