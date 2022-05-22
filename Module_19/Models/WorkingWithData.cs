using Notifications.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Module_19
{
    internal sealed class WorkingWithData
    {
        public event Action<string> Error;
        private List<Animal> tempListAnimal = new List<Animal>();
        private NotificationManager notificationManager = new NotificationManager();

        /// <summary>
        /// Вывод данных на форму
        /// </summary>
        /// <param name="collectionAnimal">Коллекция животных</param>
        public async void PrintDbAsync(ObservableCollection<Animal> collectionAnimal)
        {
            try
            {
                using (AnimalContext context = new AnimalContext())
                {
                    await Task.Run(() =>
                    {
                        tempListAnimal = context.Animals.ToList();
                    });

                    foreach (Animal anim in tempListAnimal)
                        collectionAnimal.Add(anim);

                    tempListAnimal.Clear();
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Добавление животного в базу данных
        /// </summary>
        /// <param name="typeAnimal">Тип животного</param>
        /// <param name="name">Имя животного</param>
        /// <param name="age">Возраст животного</param>
        /// <param name="weight">Вес животного</param>
        public async void AddAnimalInDBAnimalAsync(string typeAnimal, string name, string age, string weight, ObservableCollection<Animal> collectionAnimal) 
        {
            try 
            {
                Animal tempAnimal = null;

                double tempAge;
                double tempWeight;

                bool flagAge = Double.TryParse(age, out tempAge);
                bool flagWeight = Double.TryParse(weight, out tempWeight);

                if(flagAge && flagWeight && typeAnimal != null && name != null) 
                {
                    using (AnimalContext context = new AnimalContext())
                    {
                        switch (typeAnimal)
                        {
                            case "Млекопитающее":
                                {
                                    tempAnimal = new Mammal("Млекопитающее", name, tempAge, tempWeight);
                                    break;
                                }
                            case "Птица":
                                {
                                    tempAnimal = new Bird("Птица", name, tempAge, tempWeight);
                                    break;
                                }
                            case "Земноводное":
                                {
                                    tempAnimal = new Bird("Земноводное", name, tempAge, tempWeight);
                                    break;
                                }
                            default:
                                {
                                    tempAnimal = new NullAnimal();
                                    break;
                                }
                        }

                        await Task.Run(() => 
                        {
                            context.Animals.Add(tempAnimal);
                            context.SaveChanges();
                            tempListAnimal = context.Animals.ToList();
                        });

                        collectionAnimal.Clear();

                        foreach (Animal anim in tempListAnimal)
                            collectionAnimal.Add(anim);

                        tempListAnimal.Clear();
                    }
                }
                else
                    Error?.Invoke($"Введены неверные данные возраста или веса");
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Удаление животного из бд
        /// </summary>
        /// <param name="animal">Выбранное животное в базе</param>
        /// <param name="collectionAnimal">Коллекция животных</param>
        public async void DeleteAnimalAsync(Animal animal, ObservableCollection<Animal> collectionAnimal)
        {
            try
            {
                using (AnimalContext context = new AnimalContext())
                {
                    await Task.Run(() =>
                    {
                        var tempAnimal = context.Animals.Where(item => item.Id == animal.Id).FirstOrDefault();
                        context.Animals.Remove(tempAnimal);
                        context.SaveChanges();

                        tempListAnimal = context.Animals.ToList();
                    });

                    collectionAnimal.Clear();

                    foreach (Animal anim in tempListAnimal)
                        collectionAnimal.Add(anim);

                    tempListAnimal.Clear();
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Обновления данных
        /// </summary>
        /// <param name="animal">Выбранное животное, у которого нужно обновить данные</param>
        /// <param name="collectionAnimal">Коллекция животных</param>
        public async void UpdateAnimalAsync(Animal animal, ObservableCollection<Animal> collectionAnimal)
        {
            try
            {
                using (AnimalContext context = new AnimalContext())
                {
                    await Task.Run(() =>
                    {
                        var tempAnimal = context.Animals.Where(item => item.Id == animal.Id).FirstOrDefault();
                        tempAnimal.TypeAnimal = animal.TypeAnimal;
                        tempAnimal.Name = animal.Name;
                        tempAnimal.Age = animal.Age;
                        tempAnimal.Weight = animal.Weight;
                        context.SaveChanges();

                        tempListAnimal = context.Animals.ToList();
                    });

                    collectionAnimal.Clear();

                    foreach (Animal anim in tempListAnimal)
                        collectionAnimal.Add(anim);

                    tempListAnimal.Clear();
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Сохранение данных на диск
        /// </summary>
        /// <param name="selectedSaveFileComboBox">Формат для сохранения</param>
        public async void SaveFileInDiskAsync(string selectedSaveFileComboBox) 
        {
            try 
            {
                await Task.Run(() =>
                {
                    using (AnimalContext context = new AnimalContext())
                    {
                        var tempListAnimal = context.Animals.ToList();

                        switch (selectedSaveFileComboBox)
                        {
                            case "Формат .docx":
                                {
                                    SaveFileDocx.SaveFile(tempListAnimal);
                                    break;
                                }
                            case "Формат .xlsx":
                                {
                                    SaveFileXlsx.SaveFile(tempListAnimal);
                                    break;
                                }
                            case "Формат .json":
                                {
                                    SaveFileJson.SaveFile(tempListAnimal);
                                    break;
                                }
                        }
                    }
                });
            }
            catch (Exception ex) 
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Метод вывода информации об ошибки
        /// </summary>
        /// <param name="text">Текст ошибки</param>
        public async void ErrorAsync(string text) 
        {
            try 
            {
                await Task.Run(() => notificationManager.ShowAsync(new NotificationContent
                {
                    Title = $"Ошибка",
                    Message = $"{text}",
                    Type = NotificationType.Error
                }));
            }
            catch (Exception ex) 
            {
                Error?.Invoke($"{ex.Message}");
            } 
        }
    }
}
