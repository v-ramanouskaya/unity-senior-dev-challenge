using System.Collections.Generic;
using Task2_QuestNarration.Scripts.Data;
using UnityEngine;

namespace Task2_QuestNarration.Scripts.UI
{
    public class EpisodeUIController
    {
        private readonly EpisodeData _currentEpisodeData;
        private readonly QuestManager _questManager;
        private readonly Transform _targetTransform;
        private readonly EpisodeUiView _episodeViewPrefab;
        private readonly ChapterUiView _chapterUiViewPrefab;

        private Dictionary<string, ChapterUiView> _chapterViewList = new();
        private EpisodeUiView _view;

        public EpisodeUIController(QuestManager questManager,Transform targetTransform, EpisodeUiView episodeViewPrefab, ChapterUiView chapterUiViewPrefab, EpisodeData currentEpisodeData) {
            _questManager = questManager;
            _targetTransform = targetTransform;
            _episodeViewPrefab = episodeViewPrefab;
            _chapterUiViewPrefab = chapterUiViewPrefab;
            
            _currentEpisodeData = currentEpisodeData;
        }

        public void SetupView()
        {
            _view = Object.Instantiate(_episodeViewPrefab, _targetTransform);
            foreach (var data in _currentEpisodeData.chapters)
            {
                var view = _view.SetupChapterView(data, _chapterUiViewPrefab);
                view.SetChapterIdLabel(data.chapterId);
                
                _chapterViewList.Add(data.chapterId, view);
            }
        }
        
        public void SetChapterCompleted(string chapterId)
        {
            if(_chapterViewList.TryGetValue(chapterId, out var view))
                view.SetIsCompleted(true);
        }
    }
}
