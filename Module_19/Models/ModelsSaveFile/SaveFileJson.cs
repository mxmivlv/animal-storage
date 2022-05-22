using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Module_19
{
    internal static class SaveFileJson
    {
        /// <summary>
        /// Сохранение информации в фаил json
        /// </summary>
        /// <param name="animals">Коллекция данных</param>
        public static void SaveFile(List<Animal> animals)
        {
            JArray jsonarray = new JArray();

            foreach (var item in animals)
            {
                JObject message = new JObject();
                JObject jsonobject1 = new JObject();

                message["Animal"] = jsonobject1;
                jsonobject1["Id"] = item.Id;
                jsonobject1["TypeAnimal"] = item.TypeAnimal;
                jsonobject1["Name"] = item.Name;
                jsonobject1["Age"] = item.Age;
                jsonobject1["Weight"] = item.Weight;

                jsonarray.Add(message);
            }

            using (StreamWriter Animal = new StreamWriter("Animal.json", true))
            {
                Animal.Write(jsonarray);
            }
        }
    }
}
