using System.Threading.Tasks;
using Task2_QuestNarration.Scripts;
using Task2_QuestNarration.Scripts.Data;
using UnityEngine;

namespace DefaultNamespace.QuestSystem
{
    public class QuestsDataJsonController : IQuestsDataController
    {
        private const string ContentFileName = "Data";

        public QuestData Data { get; private set; }

        public async Task<QuestData>  ReadData()
        {
            var jsonString = await LoadJsonStringAsync();

            if (string.IsNullOrEmpty(jsonString))
                return null;

            Data = JsonUtility.FromJson<QuestData>(jsonString);
            return Data;
        }
        
        private async Task<string> LoadJsonStringAsync()
        {
            var request = Resources.LoadAsync<TextAsset>(ContentFileName);

            while (!request.isDone)
                await Task.Yield();

            var textAsset = request.asset as TextAsset;

            if (textAsset == null)
                Debug.LogError($"Failed to load JSON file: {ContentFileName}");

            return textAsset.text;
        }
    }
}