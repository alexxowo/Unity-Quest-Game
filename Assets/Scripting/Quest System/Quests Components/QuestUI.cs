using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Text questionTextLabel;
    public Text[] answerTextLabels = new Text[4];

    public void setupUI(int questsIndex, QuestManager questManager)
    {
        questionTextLabel.text = questManager.quests[questsIndex].Question;

        for (int i = 0; i < answerTextLabels.Length; i++)
        {
            answerTextLabels[i].text = questManager.quests[questsIndex].Answers[i];
        }

        Debug.Log($"cargado Quest: {questsIndex}");
    }

}
