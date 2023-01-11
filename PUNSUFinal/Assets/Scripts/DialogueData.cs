using UnityEngine;

namespace Leaf
{
    /// <summary>
    /// ��ܸ��
    /// </summary>
    [CreateAssetMenu(menuName = "Leaf/DialogueData", fileName = "New Dialoue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("��ܪ̦W��")]
        public string dialogueName;
        [Header("��ܤ��e"), TextArea(2, 10)]
        public string[] dialogueContents;
    }
}


