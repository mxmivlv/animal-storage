using SpreadsheetLight;
using System.Collections.Generic;

namespace Module_19
{
    internal static class SaveFileXlsx
    {
        /// <summary>
        /// Сохранение информации в фаил excel
        /// </summary>
        /// <param name="animals">Коллекция данных</param>
        public static void SaveFile(List<Animal> animals) 
        {
            using (SLDocument excel = new SLDocument())
            {
                excel.SetCellValue(1, 1, "Id");
                excel.SetCellValue(1, 2, "Тип животного");
                excel.SetCellValue(1, 3, "Имя");
                excel.SetCellValue(1, 4, "Возраст");
                excel.SetCellValue(1, 5, "Вес");

                for (int i = 0, indexLine = 2; i < animals.Count; i++)
                {
                    var animal = animals[i];

                    for (int indexColumn = 1; indexColumn <= 5; )
                    {
                        excel.SetCellValue(indexLine, indexColumn++, animal.Id);
                        excel.SetCellValue(indexLine, indexColumn++, animal.TypeAnimal);
                        excel.SetCellValue(indexLine, indexColumn++, animal.Name);
                        excel.SetCellValue(indexLine, indexColumn++, animal.Age);
                        excel.SetCellValue(indexLine, indexColumn++, animal.Weight);
                    }
                    indexLine++;
                }
                excel.SaveAs("Animal.xlsx");
            }
        }
    }
}
