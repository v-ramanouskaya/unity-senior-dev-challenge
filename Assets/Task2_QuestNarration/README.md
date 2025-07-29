Task 2 — JSON-Driven Quest & Narration System
Goal: Build a small QuestManager that loads Episodes → Chapters → Dialogues from JSON and fires an event when a chapter trigger is met.
- Data Model (C# Serializable classes)
- Loads JSON via Resources.Load<TextAsset> or StreamingAssets.
- Exposes event Action<ChapterData> OnChapterComplete.
- Method CheckTrigger(string action, int count) → invokes event when criteria met.
- UI Demo: Scrollable list of episodes/chapters; “Simulate Action” button to call CheckTrigger; Visually mark completed chapters.

To run:
1. Run QuestSystemTestScene.unity from Assets/Task2_QuestNarration/Scenes
2. Click action buttons in order to Call debug methods Simulate;
3. Initial JSON file was extended in order to demonstrate the UI list of chapters; The episode with id '1' is picked manually to simulate ProgressController logic, which wasn't implemented in this example;

