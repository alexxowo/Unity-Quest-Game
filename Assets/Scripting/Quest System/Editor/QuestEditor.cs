using System.Collections;
using Assets.Scripting.Quest_System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestManager))]
public class QuestEditor : Editor
{
    QuestManager questManager;
    SerializedProperty questionLists;
    GUIStyle principalLabel = new GUIStyle();

    bool collapse = false;

    public void OnEnable()
    {
        principalLabel.fontSize = 24;
        principalLabel.alignment = TextAnchor.MiddleCenter;
        principalLabel.fontStyle = FontStyle.BoldAndItalic;
        principalLabel.normal.textColor = Color.green;

        questManager = (QuestManager)target;
        questionLists = serializedObject.FindProperty("quests");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Quest Data Editor", principalLabel);
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Add Question: ");

        if (GUILayout.Button("ADD")) {
            AddElement();
        }

        DisplayListElements();

        serializedObject.ApplyModifiedProperties();
    }

    // Show Questions elements
    private void DisplayListElements()
    {
        for (int element = 0; element < questionLists.arraySize; element++) 
        {
            
            collapse = EditorGUILayout.Foldout(collapse, $"Question {element}");
            if (collapse)
            {
                EditorGUILayout.BeginVertical("BOX");
                EditorGUILayout.Space(10);
                SerializedProperty questionListRef = questionLists.GetArrayElementAtIndex(element);
                SerializedProperty questID = questionListRef.FindPropertyRelative("ID");
                SerializedProperty Question = questionListRef.FindPropertyRelative("Question");
                SerializedProperty questCorrectAnswer = questionListRef.FindPropertyRelative("correctAnswer");
                SerializedProperty AnswersList = questionListRef.FindPropertyRelative("Answers");
                SerializedProperty questionDiffilculty = questionListRef.FindPropertyRelative("questDifficulty");

                questID.intValue = EditorGUILayout.IntField("Quest ID", questID.intValue);
                Question.stringValue = EditorGUILayout.TextField("Question", Question.stringValue);
                questCorrectAnswer.intValue = EditorGUILayout.IntField("Correct Answer Index", questCorrectAnswer.intValue);
                EditorGUILayout.PropertyField(questionDiffilculty);

                // Show Answers
                ShowAnswers(AnswersList);

                if (GUILayout.Button("Delete Question"))
                {
                    questionLists.DeleteArrayElementAtIndex(element);
                }

                EditorGUILayout.Space(10);
                EditorGUILayout.EndVertical();
            }
        }
    }

    private void ShowAnswers(SerializedProperty AnswersList)
    {
        EditorGUILayout.LabelField($"Answers { AnswersList.arraySize }");
        if (GUILayout.Button("Add New Answer", GUILayout.MaxWidth(130)))
        {
            AnswersList.InsertArrayElementAtIndex(AnswersList.arraySize);
        }

        for (int Answer = 0; Answer < AnswersList.arraySize; Answer++)
        {
            EditorGUILayout.BeginVertical("BOX");
            //EditorGUILayout.PropertyField(AnswersList.GetArrayElementAtIndex(Answer));
            SerializedProperty answerListRef = AnswersList.GetArrayElementAtIndex(Answer);
            SerializedProperty AnswerID = answerListRef.FindPropertyRelative("AnswerID");
            SerializedProperty AnswerSelected = answerListRef.FindPropertyRelative("_Answer");

            AnswerID.intValue = Answer;

            AnswerID.intValue = EditorGUILayout.IntField("Answer ID", AnswerID.intValue);
            AnswerSelected.stringValue = EditorGUILayout.TextField("Answer", AnswerSelected.stringValue);

            if (GUILayout.Button("Remove Answer (" + Answer.ToString() + ")", GUILayout.MaxWidth(130)))
            {
                AnswersList.DeleteArrayElementAtIndex(Answer);
            }
            EditorGUILayout.EndVertical();
        }
    }

    private void AddElement()
    { 
        Debug.Log("it's works lmL");
        Quest questToAdd = new Quest();

        questToAdd.ID = questManager.quests.Count;
        questToAdd.Answers = new List<Answer>(4);

        questManager.quests.Add(questToAdd);
    }
    
    private void DeleteElement() { }

}
