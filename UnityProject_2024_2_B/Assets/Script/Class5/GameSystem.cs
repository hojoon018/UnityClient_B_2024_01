using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using UnityEngine.UI;
using TMPro;
using STORYGAME;

namespace STORYGAME
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]
    public class GameSystemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GameSystem gameSystem = (GameSystem)target;

            if(GUILayout.Button("Reset Stroy Models"))
            {
                gameSystem.ResetStoryModels();
            }

            if(GUILayout.Button("Assing Text Component by Name"))
            {
                //������Ʈ �̸����� Text ������Ʈ�� ã��
                GameObject textObject = GameObject.Find("StoryTextUI");
                if(textObject != null)
                {
                    Text textComponet = textObject.GetComponent<Text>();
                    if(textComponet != null)
                    {
                        //Text Componet �Ҵ�
                        gameSystem.textComponent = textComponet;
                    }
                }
            }
        }
    }
#endif

    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance; //Scene ���ο����� ����

        public float delay = 0.1f; //���ڰ� ��Ÿ���� �ð�
        private string currentText = ""; //ǥ�õ� �ؽ�Ʈ
        public Text textComponent; //TextMexhPro ������Ʈ

        private void Awake()
        {
            instance = this;
        }
        public enum GAMESTATE
        {
            STORYSHOW,
            STORYEND,
            ENDMODE
        }
        public GAMESTATE state;

        public StoryTableObject[] storyModels;
        public StoryTableObject currentModels;

        private void Start()
        {
            currentModels = FindStoryModel(1);
            StartCoroutine(ShowText());
        }

        StoryTableObject FindStoryModel(int number)
        {
            StoryTableObject tempStoryModels = null;
            for(int i = 0; i < storyModels.Length; i++)
            {
                if (storyModels[i].storyNumber==number)
                {
                    tempStoryModels = storyModels[i];
                    break;
                }
            }
            return tempStoryModels;

        }

        IEnumerator ShowText()
        {
            for(int i = 0; i < currentModels.storyText.Length; i++)
            {
                currentText = currentModels.storyText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(delay);
        }

#if UNITY_EDITOR
        [ContextMenu("Reset Story Models")]
        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");
            //Resources ���� �Ʒ� ��� StoryModel �ҷ� ����
        }
#endif
    }
}

