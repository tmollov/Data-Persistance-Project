using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

namespace DefaultNamespace
{
    public static class SaveManager
    {
        private static string path = Application.persistentDataPath + "/savefile.json";

        public static void SaveScore(string playerName, int score)
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData save = JsonConvert.DeserializeObject<SaveData>(json);

                if (save.Scores.ContainsKey(playerName))
                {
                    if (score > save.Scores[playerName])
                    {
                        save.Scores[playerName] = score;
                    }
                }
                else
                {
                    save.Scores.Add(playerName, score);
                }

                json = JsonConvert.SerializeObject(save);
                Debug.Log(json);
                File.WriteAllText(path, json);
            }
            else
            {
                SaveData save = new SaveData();
                save.Scores.Add(playerName, score);
                string json = JsonConvert.SerializeObject(save);
                File.WriteAllText(path, json);
            }
        }

        public static int GetBestScore()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData save = JsonConvert.DeserializeObject<SaveData>(json);
                return save.Scores.Values.Max();
            }
            else
            {
                return 0;
            }
        }

        public static int GetUserScore(string username)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData save = JsonConvert.DeserializeObject<SaveData>(json);
                if (save.Scores.ContainsKey(username))
                    return save.Scores[username];
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

        public static Dictionary<string, int> GetTopScores()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData save = JsonConvert.DeserializeObject<SaveData>(json);
                return save.Scores.OrderByDescending(x => x.Value).Take(3)
                    .ToDictionary(k => k.Key, v => v.Value);
            }
            else
            {
                return null;
            }
        }
    }

    [Serializable]
    class SaveData
    {
        public Dictionary<string, int> Scores { get; set; } = new Dictionary<string, int>();
    }
}