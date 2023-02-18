using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public CharacterData data;
    public static Data info;

    private void Awake()
    {
        info = this;
    }
}
