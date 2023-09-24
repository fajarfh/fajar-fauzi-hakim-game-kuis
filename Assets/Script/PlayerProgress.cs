using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "Player Progress Baru",
    menuName = "Game Kuis/Player Progress")]

public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progressLevel;
    }

    public string fileName = "playerprogress.txt";
    public MainData progressData = new MainData();

    public void SimpanProgress()
    {
        string directory = Application.dataPath + "/Temporary/";
        string path = directory + fileName;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been created: " + directory);

        }


        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created: " + path);
            
        }

        progressData.koin = 200;

        if (progressData.progressLevel == null)
            progressData.progressLevel = new();

        progressData.progressLevel.Add("Level Pack 1", 3);
        progressData.progressLevel.Add("Level Pack 4", 1);

        // Mode Penimpanan Tanpa Binary
        /*string kontenData = $"Koin: {progressData.koin}\nProgress:\n";          
        foreach(KeyValuePair<string, int> entry in progressData.progressLevel)
        {
            kontenData += $"{entry.Key}-{entry.Value}\n";
        }
        
        File.WriteAllText(path, kontenData);*/

        // Mode Penyimpanan Binary
        try
        {

            //Penyimpanan menggunakan Binaryformatter
            var fileStream = File.Open(path, FileMode.Create); //Membuat file baru setiap save
            var formatter = new BinaryFormatter();

            fileStream.Flush();
            formatter.Serialize(fileStream, progressData);
            fileStream.Dispose();

            //Penyimpanan tanpa Binaryformatter
            /*var writer = new BinaryWriter(fileStream);

            writer.Flush();
            writer.Write(progressData.koin);
            writer.Write(progressData.progressLevel.Count);

            foreach (var i in progressData.progressLevel)
            {
                writer.Write(i.Key);
                writer.Write(i.Value);
            }

            writer.Dispose();*/

            Debug.Log("Data saved to file: " + path);
        }
        catch (System.Exception e)
        {
            Debug.Log($"ERROR: Terjadi kesalahan saat menyimpan progress\n{e.Message}");
        }

    }

    public bool MuatProgress()
    {
        string directory = Application.dataPath + "/Temporary/";
        string path = directory + fileName;

        

        try
        {
            var fileStream = File.Open(path, FileMode.Open);//dipindah agar jika error masuk try-catch

            //Pemuatan menggunakan Binaryformatter
            var formatter = new BinaryFormatter();
            progressData = (MainData)formatter.Deserialize(fileStream);

            fileStream.Dispose();

            Debug.Log($"{progressData.koin}; {progressData.progressLevel.Count}");

            //Pemuatan tanpa Binaryformatter
            /*var reader = new BinaryReader(fileStream);

            if (progressData.progressLevel == null)
                progressData.progressLevel = new();

            fileStream.Position = 0;
            progressData.koin = reader.ReadInt32();
            int count0 = reader.ReadInt32();

            for (int i = 0; i < count0; i++)
            {
                var key = reader.ReadString();
                var value = reader.ReadInt32();

                progressData.progressLevel.Add(key, value);
            }
            
            //Menggunakan PeekChar selalu menghasilkan error
            //while (reader.PeekChar() != -1)
            //{

            //}*

            reader.Dispose();
            fileStream.Dispose();

            Debug.Log($"{progressData.koin}");
            Debug.Log("Progress:");
            foreach (var v in progressData.progressLevel)
            {
                Debug.Log($"{v.Key}-{v.Value}");
            }*/

            return true;
        }
        catch(System.Exception e)
        {
            Debug.Log($"ERROR: Terjadi kesalahan saat memuat progress\n{e.Message}");

            //fileStream.Dispose();

            return false;
        }
        
    }
}
