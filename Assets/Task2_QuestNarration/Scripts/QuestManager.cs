using System.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace.QuestSystem
{
    public class QuestManager: MonoBehaviour
    {
        private const string ContentFileName = "Data";
        private ContentData _data;
        
        public async void Awake()
        {
            var jsonString = await LoadJsonStringAsync();

            if (string.IsNullOrEmpty(jsonString))
                return;

            ReadContentData(jsonString);
        }

        private void ReadContentData(string jsonString)
        { 
            _data = JsonUtility.FromJson<ContentData>(jsonString);
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