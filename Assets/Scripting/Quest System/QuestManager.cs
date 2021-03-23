using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="QuestsFile", menuName="Systems/Quests")]
public class QuestManager : ScriptableObject
{
    [SerializeField]
    public List<Quest> quests = new List<Quest>();
}
