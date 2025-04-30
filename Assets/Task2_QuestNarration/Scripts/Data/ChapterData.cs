using System;
using System.Collections.Generic;

namespace Task2_QuestNarration.Scripts.Data
{
    [Serializable]
    public class Chapter
    {
        public string chapterId;
        public string completionTrigger;
        public List<Dialogue> dialogues;
    }
}