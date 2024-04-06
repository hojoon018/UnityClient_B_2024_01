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
                //오브젝트 이름으로 Text 컴포넌트를 찾기
                GameObject textObject = GameObject.Find("StoryTextUI");
                if(textObject != null)
                {
                    Text textComponet = textObject.GetComponent<Text>();
                    if(textComponet != null)
                    {
                        //Text Componet 할당
                        gameSystem.textComponent = textComponet;
                    }
                }
            }
        }
    }
#endif

    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance; //Scene 내부에서만 존재

        public float delay = 0.1f; //글자가 나타나는 시간
        private string currentText = ""; //표시된 텍스트
        public Text textComponent; //TextMexhPro 컴포넌트

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
            //Resources 폴더 아래 모든 StoryModel 불러 오기
        }
#endif
    }
}

