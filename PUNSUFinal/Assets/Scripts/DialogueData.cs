using UnityEngine;

namespace Leaf
{
    /// <summary>
    /// 對話資料
    /// </summary>
    [CreateAssetMenu(menuName = "Leaf/DialogueData", fileName = "New Dialoue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("對話者名稱")]
        public string dialogueName;
        [Header("對話內容"), TextArea(2, 10)]
        public string[] dialogueContents;
    }
}


