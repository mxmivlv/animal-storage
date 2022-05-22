using Module_19.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module_19.ViewModels
{
    internal class ViewModelMainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private WorkingWithData workingWithData;

        #region Заголовки, лейбл
        public string Title { get { return title; } }
        public string[] SaveFile { get { return saveFile; } }
        public string SaveFileSelection { get { return saveFileSelection; } }
        public string GroupboxTitleAnimal { get { return groupboxTitleAnimal; } }
        public string Type { get { return type; } }
        public string TitleName { get { return titleName; } }
        public string Age { get { return age; } }
        public string Weight { get { return weight; } }

        public ObservableCollection<Animal> CollectionAnimal
        {
            get { return collectionAnimal; }
            set
            {
                if (collectionAnimal == value)
                    return;
                collectionAnimal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CollectionAnimal)));
            }
        }
        public Animal SelectedAnimalDataGrid
        {
            get { return selectedAnimalDataGrid; }
            set
            {
                if (selectedAnimalDataGrid == value)
                    return;
                selectedAnimalDataGrid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedAnimalDataGrid)));
            }
        }
        public string SelectedSaveFileComboBox 
        {
            get { return selectedSaveFileComboBox; }
            set
            {
                if (selectedSaveFileComboBox == value)
                    return;
                selectedSaveFileComboBox = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedSaveFileComboBox)));
            }
        }
        public string TextboxType
        {
            get { return textboxType; }
            set
            {
                if (textboxType == value)
                    return;
                textboxType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextboxType)));
            }
        }
        public string TextboxTitleName
        {
            get { return textboxTitleName; }
            set
            {
                if (textboxTitleName == value)
                    return;
                textboxTitleName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextboxTitleName)));
            }
        }
        public string TextboxAge
        {
            get { return textboxAge; }
            set
            {
                if (textboxAge == value)
                    return;
                textboxAge = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextboxAge)));
            }
        }
        public string TextboxWeight
        {
            get { return textboxWeight; }
            set
            {
                if (textboxWeight == value)
                    return;
                textboxWeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextboxWeight)));
            }
        }

        private string title = "Животные";
        private string[] saveFile = new string[] { "Формат .json", "Формат .docx", "Формат .xlsx" };
        private string saveFileSelection = "Сохранить данные:";
        private string groupboxTitleAnimal = "Работа с данными";
        private string type = "Тип животного:";
        private string titleName = "Название животного:";
        private string age = "Возраст:";
        private string weight = "Вес:";

        private ObservableCollection<Animal> collectionAnimal;
        private Animal selectedAnimalDataGrid;
        private string selectedSaveFileComboBox;
        private string textboxType;
        private string textboxTitleName;
        private string textboxAge;
        private string textboxWeight;
        #endregion

        #region Команды
        #region Команда добавления клиента
        public ICommand CommandAddAnimal { get; }
        private void onCommandAddAnimalExecuted(object p)
        {
            workingWithData.AddAnimalInDBAnimalAsync(TextboxType, TextboxTitleName, TextboxAge, TextboxWeight, CollectionAnimal);
            TextboxType = null;
            TextboxTitleName = null;
            TextboxAge = null;
            TextboxWeight = null;
        }
        private bool commandAddAnimalExecute(object p)
        {
            return true;
        }
        #endregion

        #region Команда удаления клиента
        public ICommand CommandDeleteAnimal { get; }
        private void onCommandDeleteAnimalExecuted(object p)
        {
            workingWithData.DeleteAnimalAsync(SelectedAnimalDataGrid, CollectionAnimal);
        }
        private bool commandDeleteAnimalExecute(object p) => true;
        #endregion

        #region Команда обновления данных
        public ICommand CommandUpdateAnimal { get; }
        private void onCommandUpdateAnimalExecuted(object p)
        {
            workingWithData.UpdateAnimalAsync(SelectedAnimalDataGrid, CollectionAnimal);
        }
        private bool commandUpdateAnimalExecute(object p) => true;
        #endregion

        #region Команда сохранения данных на диск
        public ICommand CommandSaveFile { get; }
        private void onCommandSaveFileExecuted(object p)
        {
            workingWithData.SaveFileInDiskAsync(SelectedSaveFileComboBox);
        }
        private bool commandSaveFileExecute(object p) => true;
        #endregion
        #endregion

        public ViewModelMainWindow()
        {
            CollectionAnimal = new ObservableCollection<Animal>();
            workingWithData = new WorkingWithData();
            workingWithData.Error += workingWithData.ErrorAsync;
            workingWithData.PrintDbAsync(CollectionAnimal);
            CommandAddAnimal = new Command(onCommandAddAnimalExecuted, commandAddAnimalExecute);
            CommandDeleteAnimal = new Command(onCommandDeleteAnimalExecuted, commandDeleteAnimalExecute);
            CommandUpdateAnimal = new Command(onCommandUpdateAnimalExecuted, commandUpdateAnimalExecute);
            CommandSaveFile = new Command(onCommandSaveFileExecuted, commandSaveFileExecute);
        }
    }
}
