using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponCreation : BaseItemCreation<Weapon>
{
    public WeaponType weaponType;
    public float attackPower;
    public float attackSpeed;
    public float durability; // Durability of the weapon
    public float range; // Range of the weapon
    public float criticalHitChance; // Chance of a critical hit
    
    void OnGUI()
    {
        DrawCommonFields();

        DrawCommonPropertySection();
        
        if (GUILayout.Button("Create Weaon"))
        {
            CreateItem<Weapon>();
            
        }
    }

    void DrawCommonPropertySection()
    {
        EditorGUILayout.LabelField("Weapon Properties", EditorStyles.boldLabel);

        attackPower = EditorGUILayout.FloatField("AttackPower", attackPower);

        attackSpeed = EditorGUILayout.FloatField("AttackSpeed", attackSpeed);

        durability = EditorGUILayout.FloatField("Durability", durability);

        range = EditorGUILayout.FloatField("Range", range);

        criticalHitChance = EditorGUILayout.FloatField("CriticalHitChance", criticalHitChance);

        weaponType = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type", weaponType);
    }
}
