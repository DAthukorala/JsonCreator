using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.Json;

namespace Utilities
{
    public static class JsonFileUtilities
    {
        private static readonly string folderPath = ConfigurationManager.AppSettings["RepositoryPath"];
        public static readonly JsonSerializerOptions SerializerOptions;

        static JsonFileUtilities()
        {
            //properties to have camel case and pretty print indenting 
            SerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        /// <summary>
        /// Read the content of the file as a string
        /// </summary>
        /// <param name="fileName">name of the file (the mocked class name)</param>
        /// <returns>Json content from the file</returns>
        public static string ReadData(string fileName)
        {
            var fullPath = $"{folderPath}{fileName}.js";
            var data = File.ReadAllText(fullPath);
            return data;
        }

        /// <summary>
        /// Create a file in the given file path and write Json content
        /// If there is an existing file in the path. delete and create the file again with the new content
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public static void WriteData(string fileName, string data)
        {
            var fullPath = $"{folderPath}{fileName}.js";
            //if a file already exists with that name, delete that file and replace with the new data
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                File.Create(fullPath).Close();
            }
            using (var writer = new StreamWriter(fullPath))
            {
                writer.Write(data);
            }
        }

        /// <summary>
        /// Write a list of .net objects as json objects to a .js file
        /// </summary>
        /// <typeparam name="T">Type of the objects to serialize</typeparam>
        /// <param name="fileName">Name of the file to create (the class name)</param>
        /// <param name="dataToWrite">List to serialize</param>
        public static void WriteToFile<T>(string fileName, List<T> dataToWrite)
        {
            var json = JsonSerializer.Serialize(dataToWrite, SerializerOptions);
            WriteData(fileName, json);
        }

        /// <summary>
        /// Write a .net object as a json object to a .js file
        /// </summary>
        /// <typeparam name="T">Type of the object to serialize</typeparam>
        /// <param name="fileName">Name of the file to create (the class name)</param>
        /// <param name="dataToWrite">Object to serialize</param>
        public static void WriteToFile<T>(string fileName, T dataToWrite)
        {
            var json = JsonSerializer.Serialize(dataToWrite, SerializerOptions);
            WriteData(fileName, json);
        }

    }
}
