using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestGameManager))]
public class QuestGameManagerEditor : Editor {

    QuestGameManager questGameManager;
    SerializedProperty questPlayed;

    private void OnEnable()
    {
        questPlayed = serializedObject.FindProperty("questPlayed");
        questGameManager = target as QuestGameManager;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.Space();
        GUILayout.Label("Quest Game Manager", CustomProps.GetProp("QuestGameManagerTitle"));
        EditorGUILayout.Space();

        if (questPlayed.arraySize > 0) 
        { 
            for (int element = 0; element < questPlayed.arraySize; element++) 
            {
                EditorGUILayout.BeginVertical("BOX");
                SerializedProperty questPlayedReference = questPlayed.GetArrayElementAtIndex(element);
                questPlayedReference.intValue = EditorGUILayout.IntField( $"Quest { element }", questPlayedReference.intValue);

                if (GUILayout.Button("-")) {
                    questPlayed.DeleteArrayElementAtIndex(element);
                }
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("No quests played. :(", CustomProps.GetProp("QuestGameManagerError"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
