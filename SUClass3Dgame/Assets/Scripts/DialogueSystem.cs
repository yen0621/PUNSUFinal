using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Leaf
{
    /// <summary>
    /// 對話系統
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region 資料區域

        [SerializeField, Header("對話間格"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("開頭對話")]
        private DialogueData dialogueOpening;
        [SerializeField, Header("對話按鍵")]
        private KeyCode dialogueKey = KeyCode.V;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);
        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContents;
        private GameObject goTriangle;
        #endregion

        private UnityEvent onDialogueFinish;

        private PlayerInput playerInput;      //玩家輸入元件

        #region 事件
        private void Awake()
        {
            groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話者名稱").GetComponent<TextMeshProUGUI>();
            textContents = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("對話完成圖示");
            goTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(dialogueOpening);
        }
        #endregion
        
        /// <summary>
        /// 開始對話
        /// </summary>
        /// <param name="data"></param>
        /// <param name="_onDialogueFinish">對話結束後的事件，可以空值</param>
        public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;         //關閉 玩家輸入元件
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }

        /// <summary>
        /// 淡入淡出群組物件
        /// </summary>
        private IEnumerator FadeGroup(bool FadeIn = true)
        {
            //三元運算子 ? :
            //語法 :
            //布林值 ? 布林值為 true : 布林值為 false ;
            //true ? 1 : 10; 結果為 1 
            //false ? 1 : 10; 結果為 10

            float increase = FadeIn ? +0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }
        }

        /// <summary>
        /// 打字效果
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

                // 如果 玩家 還沒按下 就等待
                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }

                print("<color=#993300>玩家按下按鍵 !</color>");
            }

            StartCoroutine(FadeGroup(false));

            playerInput.enabled = true;      // 開啟 玩家輸入元件
            
            // ?. 當 onDialogueFinish 沒有值時就不執行
            onDialogueFinish?.Invoke();      // 對話事件結束，呼叫() ;
        }



    }

}