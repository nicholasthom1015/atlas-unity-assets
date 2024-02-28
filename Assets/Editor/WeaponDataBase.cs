using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponDatabase : ItemDatabase<Weapon>
{
    protected override void DrawItemList()
    {

    }

    protected override void DrawPropertiesSection()
    {

    }

    protected override void ExportItemsToCSV()
    {

    }

    protected override void ImportItemsFromCSV()
    {
        
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Database Admin Functions", EditorStyles.boldLabel);
        if (GUILayout.Button("Export to CSV"))
        {

        }

        if (GUILayout.Button("Import from CSV"))
        {

        }

        if (GUILayout.Button("Delete Selected Item"))
        {
            string itemName = selectedItem.itemName;
            bool Delete = EditorUtility.DisplayDialog($"Delete {itemName}?", $"Are you want to delete {itemName}?", "Yes", "No");
            if (Delete)
            {
                string selectedItemPath = AssetDatabase.GetAssetPath(selectedItem);
                AssetDatabase.DeleteAsset(selectedItemPath);
            }
        }

        if (GUILayout.Button("Duplicate Selected Item"))
        {

        }
        EditorGUILayout.LabelField("Weapon Smith", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Weapon"))
        {
            WeaponCreation wc = (WeaponCreation)EditorWindow.GetWindow(typeof(WeaponCreation), false, "WeaponCreation");
        }

        string[] guids = AssetDatabase.FindAssets("t: Weapon");

        foreach (string guid in guids)
        {
            Weapon w = AssetDatabase.LoadAssetAtPath<Weapon>(AssetDatabase.GUIDToAssetPath(guid));
            if (w.GetType() == typeof(Weapon))
            {
                DrawItemInList(w);
            }
        }
    }
}
