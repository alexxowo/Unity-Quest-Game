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

    public void OnEnable()
    {
        questManager = (QuestManager)target;
        questionLists = serializedObject.FindProperty("quests");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Quest Data Editor", CustomProps.GetProp("QuestEditorMainTitle"));
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
            questManager.quests[element].showQuestContent = EditorGUILayout.Foldout(questManager.quests[element].showQuestContent, $"Question {element}");
            if (questManager.quests[element].showQuestContent)
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
                ShowAnswers(AnswersList, questManager.quests[element].Answers);

                if (GUILayout.Button("Delete Question", GUILayout.ExpandWidth(false)))
                {
                    questionLists.DeleteArrayElementAtIndex(element);
                }

                EditorGUILayout.Space(10);
                EditorGUILayout.EndVertical();
            }
        }
    }

    private void ShowAnswers(SerializedProperty AnswersList, List<Answer> answers)
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
