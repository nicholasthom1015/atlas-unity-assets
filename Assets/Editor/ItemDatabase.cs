using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class ItemDatabase<T> : EditorWindow where T : BaseItem
{
    protected Vector2 scrollPosition;
    protected T selectedItem;
    protected float propertiesSectionWidth = 400f;
    
    public ItemDatabase()
    {
        this.minSize = new Vector2(600, 400); 
    }

    protected abstract void DrawItemList();
    protected abstract void DrawPropertiesSection();

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        
        DrawItemList();
        
        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(propertiesSectionWidth));
        DrawPropertiesSection();
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    protected void DeleteSelectedItem()
    {
        //Delete item
    }

    protected void DuplicateSelectedItem()
    {
        //Duplicate item
    }

    protected abstract void ExportItemsToCSV();

    protected abstract void ImportItemsFromCSV();

    protected void DrawTopLeftOptions()
    {
        GUILayout.Label("Database Admin Functions:", EditorStyles.boldLabel);
        if (GUILayout.Button("Export to CSV")) ExportItemsToCSV();
        if (GUILayout.Button("Import from CSV")) ImportItemsFromCSV();
        if (GUILayout.Button("Delete Selected Item")) DeleteSelectedItem();
        if (GUILayout.Button("Duplicate Selected Item")) DuplicateSelectedItem();
        
        // ... additional top-left options, like 'Create New Item' or 'Search' ...
    }

    protected virtual void DrawItemInList(T item)
    {
        //Debug.Log("Item: " + item.itemName);
        Texture2D iconTexture = item.icon.texture;
        
        Color defaultValue = GUI.backgroundColor;
        if (object.Equals(selectedItem, item))
        {
            GUI.backgroundColor = Color.blue;
        }
        
        //string issue;
        //bool isValid = IsValid(item, out issue);
        
        
        // Set the background color based on item validity and selection
        //if (object.Equals(selectedItem, item))
        //{
        //    GUI.backgroundColor = Color.blue;
        //}
        //else if (!isValid)
        //{
         //   GUI.backgroundColor = Color.red;
        //}

        
        Rect rect = EditorGUILayout.BeginHorizontal(GUI.skin.box);
        if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
        {
            selectedItem = item;
            Selection.activeObject = item as UnityEngine.Object;
            Event.current.Use();
        }

        GUILayout.Box(iconTexture, GUILayout.Width(30), GUILayout.Height(30));
        GUILayout.Label(item.itemName);
        EditorGUILayout.EndHorizontal();


        GUI.backgroundColor = defaultValue;
    }
}