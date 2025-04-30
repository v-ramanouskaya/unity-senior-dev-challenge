using Task2_QuestNarration.Scripts.Data;

namespace Task2_QuestNarration.Scripts.UI
{
    public class QuestsUIController
    {
        private readonly QuestsUIView _view;
        private readonly QuestData _data;

        public QuestsUIController(QuestsUIView view, QuestData data) {
            _view = view;
            _data = data;
        }

        private void SetupView()
        {
            
        }
    }
}
