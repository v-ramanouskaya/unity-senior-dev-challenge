using Task2_QuestNarration.Scripts.Data;
using UnityEngine;

namespace Task2_QuestNarration.Scripts.UI
{
    public class EpisodeUiView : MonoBehaviour
    {
        [SerializeField] private Transform _chaptersParentTransform;
    
        public ChapterUiView SetupChapterView(ChapterData data, ChapterUiView chapterUiViewPrefab)
        {
            var view = Instantiate(chapterUiViewPrefab, _chaptersParentTransform);
            return view;
        }
    }
}
