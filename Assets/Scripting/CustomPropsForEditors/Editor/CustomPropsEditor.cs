using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomPropsEditor : EditorWindow
{
    CustomProps customProps;
    GUIStyle mainTitle = new GUIStyle();
    SerializedObject serializedObject;
    SerializedProperty customGUIStyle;
    private void StyleSettings()
    {
        mainTitle.normal.textColor = new Color(0, 0.47f, 1);
        mainTitle.fontSize = 24;
        mainTitle.alignment = TextAnchor.MiddleCenter;
        mainTitle.padding = new RectOffset(5, 5, 20, 20);
        mainTitle.fontStyle = FontStyle.BoldAndItalic;
    }

    [MenuItem("Window/Custom Properties for Quest Game editors")]
    static void Init() {
        EditorWindow.GetWindow(typeof(CustomPropsEditor));
    }

    public void OnEnable()
    {
        StyleSettings();


        if (EditorPrefs.HasKey("customPropsPath"))
        {
            string objectPath = EditorPrefs.GetString("customPropsPath");
            customProps = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CustomProps)) as CustomProps;
        }

        if (customProps.customColors == null)
            customProps.customColors = new List<CustomProperties>();


        serializedObject = new SerializedObject(customProps);
        customGUIStyle = serializedObject.FindProperty("GUIStyles");

    }

    private void OnGUI()
    {
        serializedObject.Update();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Custom Props", mainTitle);

        if (customProps != null)
        {
            EditorGUILayout.BeginVertical("BOX");

            customProps.ErrorColor = EditorGUILayout.ColorField("Error Color:", customProps.ErrorColor);
            customProps.MainTitleColor = EditorGUILayout.ColorField("Main Title Color:", customProps.MainTitleColor);
            customProps.MainTitleFontSize = EditorGUILayout.IntField("Main title font Size:", customProps.MainTitleFontSize);
            customProps.SubTitleFontSize = EditorGUILayout.IntField("Subtitle font size:", customProps.SubTitleFontSize);

            EditorGUILayout.LabelField($"Custom Colors / { customProps.customColors.Count }");

            if (GUILayout.Button("Add")) 
            {
                CustomProperties customProperty = CustomProperties.CreateProperty("Name", Color.white);
                customProps.customColors.Add(customProperty);
            }

            for (int element = 0; element < customProps.customColors.Count; element++) {
                EditorGUILayout.BeginVertical("BOX");
                EditorGUILayout.Space();
                customProps.customColors[element].PropertyName = EditorGUILayout.TextField("Property Name", customProps.customColors[element].PropertyName);
                EditorGUILayout.Space();
                customProps.customColors[element].PropertyColor = EditorGUILayout.ColorField("Color 1:", customProps.customColors[element].PropertyColor);
                EditorGUILayout.Space();

                if (GUILayout.Button("Delete"))
                {
                    customProps.customColors.RemoveAt(element);
                }

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(30f);
            EditorGUILayout.BeginVertical("BOX");

            EditorGUILayout.LabelField("Custom GUIStyles");

            if (GUILayout.Button("Add GUIStyle")) 
            {
                customProps.GUIStyles.Add(new GUIStyle());
            }

            if(customGUIStyle.arraySize > 0)
            {
                for(int element = 0; element < customGUIStyle.arraySize; element++)
                {
                    EditorGUILayout.BeginVertical("BOX");

                    SerializedProperty customGUIStylesRef = customGUIStyle.GetArrayElementAtIndex(element);

                    EditorGUILayout.PropertyField(customGUIStylesRef);

                    if (GUILayout.Button("Delete")) 
                    {
                        customProps.GUIStyles.RemoveAt(element);
                        customGUIStyle.DeleteArrayElementAtIndex(element);
                    }

                    EditorGUILayout.EndVertical();
                }
            }
            else
            {
                EditorGUILayout.LabelField("No GUIStyles are listed");
            }


            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.BeginVertical("BOX");
            EditorGUILayout.LabelField("Custom Properties file is not created.");
            if (GUILayout.Button("Create new config", GUILayout.ExpandWidth(false)))
            {
                CreateNewFile();
            }
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndVertical();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(customProps);
        }
        //serializedObject.ApplyModifiedProperties();
    }
    private void CreateNewFile()
    {
        customProps = new CustomProps();
        if (customProps != null)
        {
            CustomProps asset = ScriptableObject.CreateInstance<CustomProps>();
            AssetDatabase.CreateAsset(asset, "Assets/Scripting/CustomPropsForEditors/CustomProperty.asset");
            AssetDatabase.SaveAssets();

            string customPropsFile = AssetDatabase.GetAssetPath(asset);
            EditorPrefs.SetString("customPropsPath", customPropsFile);
        }
    }
}