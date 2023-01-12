using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Leaf
{
    /// <summary>
    /// ��ܨt��
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region ��ưϰ�

        [SerializeField, Header("��ܶ���"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("�}�Y���")]
        private DialogueData dialogueOpening;
        [SerializeField, Header("��ܫ���")]
        private KeyCode dialogueKey = KeyCode.V;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);
        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContents;
        private GameObject goTriangle;
        #endregion

        private UnityEvent onDialogueFinish;

        private PlayerInput playerInput;      //���a��J����

        #region �ƥ�
        private void Awake()
        {
            groupDialogue = GameObject.Find("�e����ܨt��").GetComponent<CanvasGroup>();
            textName = GameObject.Find("��ܪ̦W��").GetComponent<TextMeshProUGUI>();
            textContents = GameObject.Find("��ܤ��e").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("��ܧ����ϥ�");
            goTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(dialogueOpening);
        }
        #endregion
        
        /// <summary>
        /// �}�l���
        /// </summary>
        /// <param name="data"></param>
        /// <param name="_onDialogueFinish">��ܵ����᪺�ƥ�A�i�H�ŭ�</param>
        public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;         //���� ���a��J����
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }

        /// <summary>
        /// �H�J�H�X�s�ժ���
        /// </summary>
        private IEnumerator FadeGroup(bool FadeIn = true)
        {
            //�T���B��l ? :
            //�y�k :
            //���L�� ? ���L�Ȭ� true : ���L�Ȭ� false ;
            //true ? 1 : 10; ���G�� 1 
            //false ? 1 : 10; ���G�� 10

            float increase = FadeIn ? +0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }
        }

        /// <summary>
        /// ���r�ĪG
        /// </summary>
        /// <returns></returns>
        private IEnumerator TypeEffect(DialogueData data)
        {
            textName.text = data.dialogueName;
            

            for (int j = 0; j < data.dialogueContents.Length; j++)
            {
                textContents.text = "";
                goTriangle.SetActive(false);

                string dialogue = data.dialogueContents[j];

                for (int i = 0; i < dialogue.Length; i++)
                {
                    textContents.text += dialogue[i];
                    yield return dialogueInterval;


                }

                goTriangle.SetActive(true);

                // �p�G ���a �٨S���U �N����
                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }

                print("<color=#993300>���a���U���� !</color>");
            }

            StartCoroutine(FadeGroup(false));

            playerInput.enabled = true;      // �}�� ���a��J����
            
            // ?. �� onDialogueFinish �S���ȮɴN������
            onDialogueFinish?.Invoke();      // ��ܨƥ󵲧��A�I�s() ;
        }



    }

}