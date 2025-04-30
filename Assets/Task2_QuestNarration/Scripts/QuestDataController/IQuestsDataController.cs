using System.Threading.Tasks;
using Task2_QuestNarration.Scripts.Data;

namespace Task2_QuestNarration.Scripts
{
    public interface IQuestsDataController
    {
        public Task<QuestData> ReadData();
        public QuestData Data { get; }
    }
}