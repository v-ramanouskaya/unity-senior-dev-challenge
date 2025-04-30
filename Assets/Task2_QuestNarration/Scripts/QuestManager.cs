using DefaultNamespace.QuestSystem;
using Task2_QuestNarration.Scripts.Data;
using UnityEngine;

namespace Task2_QuestNarration.Scripts
{
    public class QuestManager: MonoBehaviour
    {
        private const string ContentFileName = "Data";
        private QuestData _data;
        
        private QuestsDataJsonController _dataController;

        public void Awake()
        {
            _dataController = new QuestsDataJsonController();
        }
    }
}