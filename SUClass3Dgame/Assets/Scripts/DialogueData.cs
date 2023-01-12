using UnityEngine;

namespace Leaf
{
    /// <summary>
    /// ��ܸ��
    /// </summary>
    [CreateAssetMenu(menuName = "Leaf/Dialogue Data", fileName = "New Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("��ܪ̦W��")]
        public string dialogueName;
        [Header("��ܪ̤��e"), TextArea(2 , 10)]
        public string[] dialogueContents;
    }
}
