using Task2_QuestNarration.Scripts.Data;

namespace Task2_QuestNarration.Scripts
{
    public interface IQuestsDataController
    {
        public void ReadData();
        public QuestData Data { get; }
    }
}