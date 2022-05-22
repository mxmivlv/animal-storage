using System;
using System.Collections.Generic;
using Xceed.Words.NET;

namespace Module_19
{
    internal static class SaveFileDocx
    {
        /// <summary>
        /// Сохранение информации в фаил word
        /// </summary>
        /// <param name="animals">Коллекция данных</param>
        public static void SaveFile(List<Animal> animals)
        {
            using (var file = DocX.Create("Animal.docx"))
            {
                foreach (var item in animals)
                {
                    file.InsertParagraph(item.ToString());
                }
                file.Save("Animal.docx");
            }
        }
    }
}
