using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Create New Character")]
[System.Serializable]
public class CharacterData : ScriptableObject
{
    [Header("Info")]
    public string name;
    public StatusController.TypeCharacter typeCharacter;
    public StatusController.Class typeClass;

    [Header("BasicStats")]
    public float startLife;
    public float startMana;
    public int strenght;
    public int magic;
    public int agillity;
    public int vitality;
    public float baseRange;
    public int Level;
    public float Exp;
    public float nextLevel;
    public float xpFirstLevel = 100f;
    public float xpNextLevel;
    public float difficultFactor = 1f;

}