using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace PAD_Search.ViewModels
{
    class JsonData
    {
        public static List<T> ReadJsonFromFile<T>(string filePath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            List<T> list = new List<T>();

            using (Stream stream = assembly.GetManifestResourceStream(filePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                list = JsonSerializer.Deserialize<List<T>>(result);
            }
            return list;
        }
    }
}
