using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Tsutsuji.Framework.Encoding;

namespace Tsutsuji.Framework.IO
{
    public class Configuration
    {
        private string filePath;
        private Dictionary<string, List<KeyValuePair<string, dynamic>>> configValues = new Dictionary<string, List<KeyValuePair<string, dynamic>>>();

        private Regex READ_CATEGORY = new Regex(@"\[(.{0,})\]");
        private Regex READ_KVP = new Regex(@"(.{0,})\=(.{0,})");

        // public indexes
        public string FilePath
        {
            get
            {
                return filePath;
            }
        }

        public Configuration()
        {
            return;
        }

        public Configuration(string file, BaseConfiguration baseConfiguration = null)
        {
            if (File.Exists(file))
            {
                filePath = file;
                this.Load();
            }
            else
            {
                FileStream stream = File.Create(file);
                if (baseConfiguration != null)
                {
                    configValues = baseConfiguration.configValues;
                }

                filePath = file;
                stream.Close();
                this.Save();

                filePath = file;
            }
        }

        // read functions
        public void Load()
        {
            StreamReader reader = new StreamReader(filePath);
            string line;
            string currentCategory = null;

            while ((line = reader.ReadLine()) != null)
            {
                if (READ_CATEGORY.Match(line).Success == true)
                {
                    foreach (Match match in READ_CATEGORY.Matches(line))
                    {
                        currentCategory = match.Groups[1].Value;
                        configValues.Add(currentCategory, new List<KeyValuePair<string, dynamic>>());
                    }
                }
                else if (READ_KVP.Match(line).Success == true)
                {
                    foreach (Match match in READ_KVP.Matches(line))
                    {
                        configValues[currentCategory].Add(new KeyValuePair<string, dynamic>(match.Groups[1].Value, match.Groups[2].Value));
                        Debug.WriteLine(configValues[currentCategory][0]);
                    }
                } else
                {
                    return;
                }
            }

            reader.Close();
            return;
        }

        public bool FileExists()
        {
            return File.Exists(filePath);
        }

        public void Save()
        {
            List<string> lines = new List<string>();
            foreach (string key in configValues.Keys)
            {
                lines.Add("[" + key + "]");
                foreach (KeyValuePair<string, dynamic> kvp in configValues[key])
                {
                    lines.Add(kvp.Key + "=" + kvp.Value);
                }

                lines.Add("");
            }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string line in lines.ToArray())
                    {
                        writer.WriteLine(line);
                    }

                writer.Close();
            }

            return;
        }

        // Categories
        public void AddCategory(string category)
        {
            if (configValues.ContainsKey(category) == true) return;

            configValues.Add(category, new List<KeyValuePair<string, dynamic>>());
        }

        public void DelCategory(string category)
        {
            if (configValues.ContainsKey(category) == false) return;

            configValues.Remove(category);
        }

        // Values
        public T Read<T>(string category, string key)
        {
            KeyValuePair<string, dynamic> result = new KeyValuePair<string, dynamic>(null, null);
            foreach (KeyValuePair<string, dynamic> kvp in configValues[category])
            {
                if (kvp.Key == key)
                {
                    result = kvp;
                }
            }

            return (T)result.Value;
        }

        public void Add(string category, KeyValuePair<string, dynamic> config)
        {
            configValues[category].Add(config);
        }

        public void Edit(string category, KeyValuePair<string, dynamic> config)
        {
            var index = configValues[category].FindIndex(c => c.Key == config.Key);
            configValues[category][index] = config;
        }

        public void Remove()
        {
        }
    }
}
