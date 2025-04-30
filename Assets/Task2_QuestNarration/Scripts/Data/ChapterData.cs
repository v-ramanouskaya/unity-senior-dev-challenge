using System;
using System.Collections.Generic;

namespace Task2_QuestNarration.Scripts.Data
{
    [Serializable]
    public class ChapterData
    {
        public string chapterId;
        public string completionTrigger;
        public List<DialogueData> dialogues;
    }
}