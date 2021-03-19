using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="QuestsFile", menuName="Systems/Quests")]
public class QuestManager : ScriptableObject
{
    public List<Quest> quests = new List<Quest>();
}
