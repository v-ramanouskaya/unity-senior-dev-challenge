using System;
using DefaultNamespace.QuestSystem;
using Task2_QuestNarration.Scripts.Data;
using Task2_QuestNarration.Scripts.UI;
using UnityEngine;

namespace Task2_QuestNarration.Scripts
{
    public class QuestManager: MonoBehaviour
    {
        private const string ContentFileName = "Data";
        private QuestData _data;

        public event Action<ChapterData> ChapterCompletedEvent;
        
        private QuestsDataJsonController _dataController;
        private QuestsUIController _questsUIController;
        private ChapterData _currentChapter;
        private string _currentEpisodeId;

        public void Awake()
        {
            _dataController = new QuestsDataJsonController();
            
            //TODO: assumed there should be some progressController to get Active episode
            //var currentEpisodeId = ProgressController.GetActiveEpisodeId();
            //var episodeData = GetCurrentEpisodeData(currentEpisodeId)
            
            var episodeData = GetCurrentEpisodeData("A");
            _questsUIController = new QuestsUIController(new QuestsUIView(),episodeData);
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