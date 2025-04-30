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
        
        private QuestData _data;
        private QuestsDataJsonController _dataController;
        private EpisodeUIController _episodeUIController;
        private ChapterData _currentChapter;
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
            var episodeData = GetCurrentEpisodeData(FirstEpisodeID);
            
            _episodeUIController = new EpisodeUIController(this,_episodePrefab, _chapterPrefab,episodeData);
            _episodeUIController.SetupView();
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

        public void CheckTrigger(string action, int count)
        {
            if(true)
                ChapterCompletedEvent?.Invoke(_currentChapter);
        }
    }
}