using Task2_QuestNarration.Scripts.Data;

namespace Task2_QuestNarration.Scripts.UI
{
    public class QuestsUIController
    {
        private readonly QuestsUIView _view;
        private readonly EpisodeData _currentEpisodeData;

        public QuestsUIController(QuestsUIView view, EpisodeData currentEpisodeData) {
            _view = view;
            _currentEpisodeData = currentEpisodeData;
        }

        private void SetupView()
        {
            foreach (var chapter in _currentEpisodeData.chapters)
                SetupChapterView(chapter);
        }

        private void SetupChapterView(ChapterData data)
        {
        }

        private void SetChapterCompleted()
        {
            
        }
    }
}
