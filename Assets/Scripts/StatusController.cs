using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{ 
    public enum TypeCharacter
    {
        Character = 0,
        Monster = 1,
        Boss = 2
    }

    public enum Class
    {
        Warrior = 0,
        Wizard = 1,
        Archer = 2
    }
    
    [Header("Type")]
    public TypeCharacter typeCharacter;
    public Class typeClass;
    public string name;

    [Header("Health/Magic")]
    public double health;
    public double healthMax;
    public double healthRegen;
    public double mana;
    public double manaMax;
    public double manaRegen;

    [Header("BasicStatus")]
    public float strength;
    public float agility;
    public float vitality;
    public float energy;
    public float command;

    [Header("Experience")]
    public float level;
    public float exp;
    public float nextLevel;
    public float xpFirstLevel;
    public float xpNextLevel;
    public float difficultFactor;

    [Header("StatusCalculator")]
    public float minDamage;
    public float maxDamage;
    public float minMagicDamage;
    public float maxMagicDamage;
    public float comboBase;
    public float speed;
    public float defense;
    public float rangeBase;
    public float range;
    public double defenseRate;
    public double attackRate;
    public double defenseRatePvp;
    public double attackRatePvp;
    public float skill;
    public float soulBarrier;
    public float fornitude;
    public float damageBuff;
    public float defenseBuff;
    public float heal;
    public float criticalDamage;

    [Header("Slider Health")]
    public Text textHealth;
    public Slider sliderHealth;
    public Image colorHealth;
    
    [Header("Slider Mana")]
    public Text textMana;
    public Slider sliderMana;
    public Image colorMana;
    
    [Header("Slider Experience")]
    public Text textXp;
    public Slider sliderXp;
    public Image colorXp;
    
    [Header("Stats Window")]
    public Text Level;
    public Text Xp;
    public Text NextLevel;
    public Text XpNextLevel;
    public Text Health;
    public Text HealthRegen;
    public Text Mana;
    public Text ManaRegen;
    public Text Speed;
    public Text Defence;
    public Text MinDamage;
    public Text MaxDamage;
    public Text MinMagicDamage;
    public Text MaxMagicDamage;
    public Text Combo;
    public Text Defense;
    public Text Skill;
    public Text Fornitude;

    void Start()
    {
        name = Data.info.data.name;
        typeCharacter = Data.info.data.typeCharacter;
        typeClass = Data.info.data.typeClass;
        health = Data.info.data.startLife;
        mana = Data.info.data.startMana;
        healthMax = Data.info.data.startLife;
        manaMax = Data.info.data.startMana;
        strength = Data.info.data.strenght;
        energy = Data.info.data.magic;
        agility = Data.info.data.agillity;
        vitality = Data.info.data.vitality;
        range = Data.info.data.baseRange;
        level = Data.info.data.Level + 1;
        exp = Data.info.data.Exp;
        nextLevel = Data.info.data.xpFirstLevel;
        xpFirstLevel = Data.info.data.xpFirstLevel;
        xpNextLevel = Data.info.data.xpFirstLevel;
        difficultFactor = Data.info.data.difficultFactor;
        
        //Health
        //colorHealth.color = Color.red;

        //Mana
        //colorHealth.color = Color.blue;
        
        //Experiencia
        //colorXp.color = Color.Lerp(Color.red, Color.green, sliderXp.value / sliderXp.maxValue);

        
        if (typeClass == Class.Warrior)
        {
            minDamage = strength / 6;
            maxDamage = strength / 4;
            minMagicDamage = energy / 9;
            maxMagicDamage = energy / 4;
            comboBase = (strength + agility + energy) / 2;
            speed = agility / 15;
            defense = agility / 3;
            defenseRate = agility / 3;
            attackRate = (level * 5) + (agility * 1.5f) + (strength / 4);
            defenseRatePvp = (level * 2) + (agility / 2);
            attackRatePvp = (level * 3) + (agility * 4.5f);
            health = 35 + ((level - 1) * 2) + (vitality * 3);
            mana = 10 + ((level - 1) / 2) + energy;
            manaRegen = mana / 27.5f;
            skill = 200 + energy / 10;
            soulBarrier = 10 + (agility / 50) + (energy / 200);
            fornitude = 12 + (vitality / 100) + (energy / 20);
            damageBuff = (energy / 7) + 3;
            defenseBuff = (energy / 8) + 2;
            heal = (energy / 5) + 5;
        }

        else if (typeClass == Class.Wizard)
        {
            minDamage = strength / 6;
            maxDamage = strength / 4;
            minMagicDamage = energy / 9;
            maxMagicDamage = energy / 4;
            comboBase = (strength + agility + energy) / 2;
            speed = agility / 10;
            defense = agility / 4;
            defenseRate = agility / 3;
            attackRate = (level * 5) + (agility * 1.5f) + (strength / 4);
            defenseRatePvp = (level * 2) + (agility / 4);
            attackRatePvp = (level * 3) + (agility * 4);
            health = 30 + ((level - 1) * 2) + (vitality * 2);
            mana = (energy + level - 1) * 2;
            manaRegen = mana / 27.5f;
            skill = 200 + energy / 10;
            soulBarrier = 10 + (agility / 50) + (energy / 200);
            fornitude = 12 + (vitality / 100) + (energy / 20);
            damageBuff = (energy / 7) + 3;
            defenseBuff = (energy / 8) + 2;
            heal = (energy / 5) + 5;
        }
                
        else if (typeClass == Class.Archer)
        {
            minDamage = (strength + agility * 2) / 14;
            maxDamage = (strength + agility * 2) / 8;
            minMagicDamage = energy / 9;
            maxMagicDamage = energy / 4;
            comboBase = (strength + agility + energy) / 2;
            speed = agility / 50;
            defense = agility / 10;
            defenseRate = agility / 4;
            attackRate = (level * 5) + (agility * 1.5f) + (strength / 4);
            defenseRatePvp = (level * 2) + (agility / 10);
            attackRatePvp = (level * 3) + (agility * 0.6f);
            health = 40 + (level - 1) + (vitality * 2);
            mana = 6 + (level + energy) * 1.5f;
            manaRegen = mana / 27.5f;
            skill = 200 + energy / 10;
            soulBarrier = 10 + (agility / 50) + (energy / 200);
            fornitude = 12 + (vitality / 100) + (energy / 20);
            damageBuff = (energy / 7) + 3;
            defenseBuff = (energy / 8) + 2;
            heal = (energy / 5) + 5;
        }
        StatusWindows();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddExp(100);
            AtualizarXpBar();
        }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            health -= 10;
            AtualizarHealthBar();
        }
        
        else if (Input.GetKeyDown(KeyCode.W))
        {
            mana -= 10;
            AtualizarManaBar();
        }
    }

    public void CountStatus()
    {
        if (typeClass == Class.Warrior)
        {
            minDamage = minDamage + (strength / 6);
            maxDamage = maxDamage + (strength / 4);
            minMagicDamage = minMagicDamage + (energy / 9);
            maxMagicDamage = maxMagicDamage + (energy / 4);
            comboBase = comboBase + ((strength + agility + energy) / 2);
            speed = speed + (agility / 15);
            defense = defense + (agility / 3);
            defenseRate = defenseRate + (agility / 3);
            attackRate = attackRate + ((level * 5) + (agility * 1.5f) + (strength / 4));
            defenseRatePvp = defenseRatePvp + ((level * 2) + (agility / 2));
            attackRatePvp = attackRatePvp + ((level * 3) + (agility * 4.5f));
            health = health + (35 + ((level - 1) * 2) + (vitality * 3));
            mana = mana + (10 + ((level - 1) / 2) + energy);
            manaRegen = manaRegen + (mana / 27.5f);
            skill = skill + (200 + energy / 10);
            soulBarrier = soulBarrier + (10 + (agility / 50) + (energy / 200));
            fornitude = fornitude + (12 + (vitality / 100) + (energy / 20));
            damageBuff = damageBuff + ((energy / 7) + 3);
            defenseBuff = defenseBuff + ((energy / 8) + 2);
            heal = heal + ((energy / 5) + 5);
        }

        else if (typeClass == Class.Wizard)
        {
            minDamage = minDamage + (strength / 6);
            maxDamage = maxDamage + (strength / 4);
            minMagicDamage = minMagicDamage + (energy / 9);
            maxMagicDamage = maxMagicDamage + (energy / 4);
            comboBase = comboBase + ((strength + agility + energy) / 2);
            speed = speed + (agility / 10);
            defense = defense + (agility / 4);
            defenseRate = defenseRate + (agility / 3);
            attackRate = attackRate + ((level * 5) + (agility * 1.5f) + (strength / 4));
            defenseRatePvp = defenseRatePvp + ((level * 2) + (agility / 4));
            attackRatePvp = attackRatePvp + ((level * 3) + (agility * 4));
            health =  health + (30 + ((level - 1) * 2) + (vitality * 2));
            mana = mana + ((energy + level - 1) * 2);
            manaRegen = manaRegen + (mana / 27.5f);
            skill = skill + (200 + energy / 10);
            soulBarrier = soulBarrier + (10 + (agility / 50) + (energy / 200));
            fornitude = fornitude + (12 + (vitality / 100) + (energy / 20));
            damageBuff = damageBuff + ((energy / 7) + 3);
            defenseBuff = defenseBuff + ((energy / 8) + 2);
            heal = heal + ((energy / 5) + 5);
        }
                
        else if (typeClass == Class.Archer)
        {
            minDamage = minDamage + ((strength + agility * 2) / 14);
            maxDamage = maxDamage + ((strength + agility * 2) / 8);
            minMagicDamage = minMagicDamage + (energy / 9);
            maxMagicDamage = maxMagicDamage + (energy / 4);
            comboBase = comboBase + ((strength + agility + energy) / 2);
            speed = speed + (agility / 50);
            defense = defense + (agility / 10);
            defenseRate = defenseRate + (agility / 4);
            attackRate = attackRate + ((level * 5) + (agility * 1.5f) + (strength / 4));
            attackRatePvp = defenseRatePvp + ((level * 2) + (agility / 10));
            attackRatePvp = attackRatePvp + ((level * 3) + (agility * 0.6f));
            health = health + (40 + (level - 1) + (vitality * 2));
            mana = mana + (6 + (level + energy) * 1.5f);
            manaRegen = manaRegen + (mana / 27.5f);
            skill = skill + (200 + energy / 10);
            soulBarrier = soulBarrier + (10 + (agility / 50) + (energy / 200));
            fornitude = fornitude + (12 + (vitality / 100) + (energy / 20));
            damageBuff = damageBuff + ((energy / 7) + 3);
            defenseBuff = defenseBuff + ((energy / 8) + 2);
            heal = heal = ((energy / 5) + 5);
        }

        AtualizarXpBar();
        AtualizarHealthBar();
        AtualizarManaBar();
    }
    
    public void AtualizarHealthBar()
    {
        textHealth.text = "" + health;
        sliderHealth.maxValue = (float)healthMax;
        sliderHealth.value = (float)health;
        
        //colorHealth.color = Color.red;
    }
    
    public void AtualizarManaBar()
    {
        textMana.text = "" + mana;
        sliderMana.maxValue = (float)manaMax;
        sliderMana.value = (float)mana;
        
        //colorMana.color = Color.blue;
    }
    public void AtualizarXpBar()
    {
        textXp.text = "" + nextLevel;
        sliderXp.maxValue = xpNextLevel;
        sliderXp.value = exp;
        
        //colorXp.color = Color.Lerp(Color.red, Color.green, sliderXp.value / sliderXp.maxValue);
    }
    
    public void AddExp(float xp)
    {
        if (exp < xpNextLevel)
        {
            exp += xp;
            nextLevel -= xp;
            StatusWindows();
        }

        else if (exp >= xpNextLevel)
        {
            exp += xp;
            exp += nextLevel - exp;

            nextLevel = xpNextLevel * level * difficultFactor;

            level++;
            xpNextLevel = nextLevel;
            
            AtualizarXpBar();
            AtualizarHealthBar();
            AtualizarManaBar();
            CountStatus();
            StatusWindows();
        }
    }

    public void StatusWindows()
    {
        //Stats Windows
        Level.text = "Level: " + level.ToString();
        Xp.text = "Xp: " + exp;
        NextLevel.text = "Next Level " + nextLevel;
        XpNextLevel.text = "Xp Next Level: " + xpNextLevel;
        Health.text = "Health: " + health;
        HealthRegen.text = "Health Regen: " + HealthRegen;
        Mana.text = "Mana: " + mana;
        ManaRegen.text = "ManaRegen: " + ManaRegen;
        Speed.text = "Speed: " + speed;
        MinDamage.text = "Min Damage: " + minDamage;
        MaxDamage.text = "Max Damage: " + maxDamage;
        MinMagicDamage.text = "Min Magic Damage: " + minMagicDamage;
        MaxMagicDamage.text = "Max Magic Damage: " + maxMagicDamage;
        Combo.text = "Combo: " + comboBase;
        Defense.text = "Defence: " + defense;
        Skill.text = "Skill: " + skill;
        Fornitude.text = "Fornitude: " + fornitude;
    }
}