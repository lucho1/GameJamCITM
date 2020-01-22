﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XButton : MonoBehaviour
{
    public Button button;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BButton"))
            button.onClick.Invoke();
    }
}
