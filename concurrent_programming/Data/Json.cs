using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data
{
    internal class Json
    {
        private static readonly JsonSerializerOptions _options =
        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        public static void PrettyWrite(object obj, string fileName)
        {
            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(obj, options);
            //File.WriteAllText(fileName, jsonString);
            using StreamWriter file = new("C:\\Users\\Filip\\Desktop\\Infa4\\wspolbiezne\\test.txt", append: true);
            file.Write(jsonString + "\n");
            file.Close();
        }
    }
}
