﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHandModel : MonoBehaviour
{
    public GameObject extinguisher;
    //public GameObject[] hands;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Hand")
        {
            return;
        }

        Debug.Log(other.gameObject.name);

        if (other.transform.parent.parent.parent.name == "Right")
        {
            if (extinguisher.gameObject.activeSelf)
            {
                extinguisher.SetActive(false);
            }
            else
            {
                extinguisher.SetActive(true);
            }
        }
    }
}