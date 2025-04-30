using System;
using DefaultNamespace.QuestSystem;
using Task2_QuestNarration.Scripts.Data;
using Task2_QuestNarration.Scripts.UI;
using UnityEngine;

namespace Task2_QuestNarration.Scripts
{
    public class QuestManager: MonoBehaviour
    {
        private const string FirstEpisodeID = "1";
        
        [SerializeField] private ChapterUiView _chapterPrefab;
        [SerializeField] private EpisodeUiView _episodePrefab;
        [SerializeField] private Transform _targetTransform;
        
        private QuestData _data;
        private QuestsDataJsonController _dataController;
        private EpisodeUIController _episodeUIController;
        private string _currentEpisodeId;
        
        public event Action<ChapterData> ChapterCompletedEvent;

        public async void Awake()
        {
            _dataController = new QuestsDataJsonController();
            _data = await _dataController.ReadData();
            
            if(_data == null)
                return;

            //TODO:replace with current episode data from progressController
            //var currentEpisodeId = ProgressController.GetActiveEpisodeId();
            //var episodeData = GetCurrentEpisodeData(currentEpisodeId)
            _currentEpisodeId = FirstEpisodeID;
            var episodeData = GetCurrentEpisodeData(_currentEpisodeId);
            
            _episodeUIController = new EpisodeUIController(this, _targetTransform, _episodePrefab, _chapterPrefab, episodeData);
            _episodeUIController.SetupView();
        }

        public void SimulateTrigger_Stars_10() => CheckCompletionTrigger("Stars", 10);
        public void SimulateTrigger_Gems_8() => CheckCompletionTrigger("Gems", 8);
        public void SimulateTrigger_Keys_5() => CheckCompletionTrigger("Keys", 5);

        private void CheckCompletionTrigger(string action, int count)
        {
            var inputTrigger = $"{action}_{count}";
            foreach (var chapter in GetCurrentEpisodeData(_currentEpisodeId).chapters)
            {
                if(chapter.completionTrigger.ToUpper() == inputTrigger.ToUpper())
                    ChapterCompletedEvent?.Invoke(chapter);
            }
        }
        
        private EpisodeData GetCurrentEpisodeData(string id)
        {
            for (int i = 0; i < _data.episodes.Count; i++)
            {
                if (_data.episodes[i].episodeId == id)
                    return _data.episodes[i];
            }

            return null;
        }
    }
}