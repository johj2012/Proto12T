﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public ItemBuffer itemBuffer;
    public Transform slotRoot;

    private List<Slot> slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();

        int slotCnt = slotRoot.childCount;

        for(int i = 0; i<slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);

            }
            else
            {
                slot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }

            slots.Add(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
