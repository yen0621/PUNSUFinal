using UnityEngine;
using UnityEngine.Events;

namespace Leaf
{
    /// <summary>
    /// ���ʨt�� : �������a�O�_�i�J�åB���椬��
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("��ܸ��")]
        private DialogueData dataDialogue;
        [SerializeField, Header("��ܵ�����ƥ�")]
        private UnityEvent onDialogueFinish;         //Unity�ƥ�

        [SerializeField, Header("�ҰʹD��")]
        private GameObject propActive;
        [SerializeField, Header("�Ұʫ᪺��ܸ��")]
        private DialogueData dataDialogueActive;
        [SerializeField, Header("�Ұʫ��ܵ����᪺�ƥ�")]
        private UnityEvent onDialogueFinishAfterActive;

        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("�e����ܨt��").GetComponent<DialogueSystem>();
        }

        // 3D ����A��
        // ��ӸI���ƥ󥲶��䤤�@�ӤĿ� Is Trigger
        // �I���}�l
        private void OnTriggerEnter(Collider other)
        {
            // �p�G �I������W�� �]�t PlayerCapsule �N���� {}
            if (other.name.Contains(nameTarget))
            {
                print(other.name);
                if (propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive, onDialogueFinishAfterActive);
                }
            }
        }

        //�I������
        private void OnTriggerExit(Collider other)
        {
            
        }

        //�I������
        private void OnTriggerStay(Collider other)
        {
            
        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    }
}

