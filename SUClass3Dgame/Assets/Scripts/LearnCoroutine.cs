using System.Collections;
using UnityEngine;

namespace Leaf
{
    /// <summary>
    /// �ǲߨ�P�{�ǡA²�٨�{ Coroutine
    /// �ت�: ���{�����d�F�쵥�ݪ���
    /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {
        private string testDialogue = "�o�̦n���ơA �ڷQ�n�������}...";

        private void Awake()
        {
            //StartCoroutine(Test());

            //print("���o���չ�ܪ��Ĥ@�Ӧr : " + testDialogue[0]);

            StartCoroutine(ShowDialogueUseFor());
        }

        private IEnumerator Test()
        {
            print("<color=#33ff33>�Ĥ@��{��</color>");
            yield return new WaitForSeconds(2);
            print("<color=#ff3333>�ĤG��{��</color>");
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


