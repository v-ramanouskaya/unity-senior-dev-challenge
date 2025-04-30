using UnityEngine;
using UnityEngine.UI;

namespace Task2_QuestNarration.Scripts.UI
{
    public class ChapterUiView : MonoBehaviour
    {
        [SerializeField] private GameObject _completedView;
        [SerializeField] private GameObject _regularView;
        [SerializeField] private Text _chapterIdLabelText;

        public void SetChapterIdLabel(string id) => _chapterIdLabelText.text = id;
        
        public void SetIsCompleted(bool isCompleted)
        {
            _completedView.SetActive(isCompleted);
            _regularView.SetActive(!isCompleted);
        }
    }
}