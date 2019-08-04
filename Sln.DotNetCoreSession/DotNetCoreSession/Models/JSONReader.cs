using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace DotNetCoreSession.Models
{
    public static class JSONReader<T> where T : class
    {
        public static List<T> GetAll(string dataFileName, string filePath)
        {
            DriveInfo cDrive = new DriveInfo(System.Environment.CurrentDirectory);

            var getCurrentDirectory = Directory.GetCurrentDirectory();
            string json = File.ReadAllText(filePath + "\\Models\\" + dataFileName + ".json");
            var list = JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }
    }
}