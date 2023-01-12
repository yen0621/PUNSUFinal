using System.Collections;
using UnityEngine;

namespace Leaf
{
    /// <summary>
    /// 學習協同程序，簡稱協程 Coroutine
    /// 目的: 讓程式停留達到等待的效
    /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {
        private string testDialogue = "這裡好恐怖， 我想要趕快離開...";

        private void Awake()
        {
            //StartCoroutine(Test());

            //print("取得測試對話的第一個字 : " + testDialogue[0]);

            StartCoroutine(ShowDialogueUseFor());
        }

        private IEnumerator Test()
        {
            print("<color=#33ff33>第一行程式</color>");
            yield return new WaitForSeconds(2);
            print("<color=#ff3333>第二行程式</color>");
        }

        private IEnumerator ShowDialogue()
        {
            print(testDialogue[0]);
            yield return new WaitForSeconds(0.1f);
        }

        private IEnumerator ShowDialogueUseFor()
        {
            for (int i = 0; i < testDialogue.Length; i++)
            {
                print(testDialogue[i]);
                yield return new WaitForSeconds(0.2f);
            }

        }
    }
}


