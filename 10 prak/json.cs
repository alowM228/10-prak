using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;


namespace ConsoleApp1
{
    internal class JsonDS
    {
        private static string PathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string MainPathToJson;
        public static void Serelialize<T>(string Path, T arr)
        {
            File.WriteAllText(MainPathToJson, JsonConvert.SerializeObject(arr));
            File.WriteAllText(PathToDesktop+"\\"+ Path, JsonConvert.SerializeObject(arr));
        }
        public static T Deserialize<T>()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(MainPathToJson));
        }
        public static void SearchToJsonFiles()
        {
            string a = Assembly.GetExecutingAssembly().Location;
            for(int i = a.Length-1; i > 0; i--)
            {
                if (a[i].ToString() == @"\")
                {
                    a = a.Remove(i);
                    foreach(var element in Directory.GetFiles(a))
                    {
                        if(Path.GetFileName(element) == "Account.json")
                        {
                            MainPathToJson = a + "\\" + "Account.json";
                            i = 0;
                            break;
                        }
                    }
                }
                else
                {
                    a = a.Remove(i);
                }
            }
            if(File.Exists(PathToDesktop + "\\" + "Account.json"))
            {
                File.Delete(PathToDesktop + "\\" + "Account.json");
                File.Copy(MainPathToJson, PathToDesktop + "\\" + "Account.json");
            }
            else
            {
                File.Copy(MainPathToJson, PathToDesktop + "\\" + "Account.json");
            }
        }
    }
}
