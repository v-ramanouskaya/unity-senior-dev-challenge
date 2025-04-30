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

        public void Awake()
        {
            _dataController = new QuestsDataJsonController();
            _questsUIController = new QuestsUIController(new QuestsUIView(),_data);
        }

        public void CheckTrigger(string action, int count)
        {
            if(true)
                ChapterCompletedEvent?.Invoke(_currentChapter);
        }
    }
}