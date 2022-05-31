using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data
{
    internal class Json
    {
        private static readonly JsonSerializerOptions _options =
        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        public static void PrettyWrite(object obj)
        {
            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(obj, options);
            using StreamWriter file = new("C:\\Users\\Filip\\Desktop\\Infa4\\wspolbiezne\\test.txt", append: true);
            file.Write(jsonString + ",\n");
            file.Close();
        }

        public static void EndWrite()
        {
            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(new InformationAboutCircle(0,0,0,0,0), options);
            using StreamWriter file = new("C:\\Users\\Filip\\Desktop\\Infa4\\wspolbiezne\\test.txt", append: true);
            file.Write(jsonString + "\n");
            file.Close();
        }

        public static void PrettySimleString(string s)
        {
            using StreamWriter file = new("C:\\Users\\Filip\\Desktop\\Infa4\\wspolbiezne\\test.txt", append: true);
            file.Write(s);
            file.Close();
        }

        public static void YamlTest(InformationAboutCircle o)
        {
            using StreamWriter file = new("C:\\Users\\Filip\\Desktop\\Infa4\\wspolbiezne\\yamlTest.yaml", append: true);
            file.Write(o.ToString());
            file.Close();
        }
    }
}
