using UnityEngine;
using UnityEngine.Events;

namespace Leaf
{
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("第一段對話資料")]
        private DialogueData dataDialogue;
        [SerializeField, Header("對話結束後的事件")]
        private UnityEvent onDialogueFinish;

        [SerializeField, Header("啟動道具")]
        private GameObject propActive;
        [SerializeField, Header("啟動後的對話資料")]
        private DialogueData dataDialogueActive;
        [SerializeField, Header("啟動後對話結束後的事件")]
        private UnityEvent onDialogueFinishActive;

        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("畫布對話系統").GetComponent<DialogueSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameTarget))
            {
                print(other.name);

                if (propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive, onDialogueFinishActive);
                }

            }
        }

        private void OnTriggerStay(Collider other)
        {
            
        }

        private void OnTriggerExit(Collider other)
        {
            
        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    }
}


