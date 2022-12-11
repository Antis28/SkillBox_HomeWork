using ConsoleMenu;
using System;
using System.IO;
using System.Text;

namespace _06_Структуры_и_введение_в_ООП
{
    internal class SchedularConsolUI
    {
        private readonly string _mainPath;
        private readonly Schedular _schedular;

        public SchedularConsolUI(string mainPath)
        {
            _mainPath = mainPath;
            _schedular = new Schedular(_mainPath);
        }

        private RecordElement CreateNewRecord(RecordElement record)
        {
            var isExit = false;
            var menuItems = new MenuItem[]
            {
                new MenuItem
                {
                    Text = "Добавить заголовок",
                    Command = () =>{
                        Console.WriteLine("Введите текст заголовка:");
                        record.Title = Console.ReadLine();
                    }
                },
                new MenuItem
                { Text = "Добавить место действия",
                    Command =() => {
                        Console.WriteLine("Введите место действия:");
                        record.Place = Console.ReadLine();
                    }
                },
                 new MenuItem
                 {
                     Text = "Добавить срок выполнения",
                     Command = () => {
                        Console.WriteLine("Введите количество дней:");
                        record.EndDate = DateTime.Now + TimeSpan.Parse(Console.ReadLine());
                    }
                 },
                 new MenuItem
                 {
                     Text = "Добавить дату вручную",
                     Command = () => {
                        Console.WriteLine("Введите дату в формате :");
                        record.Date =  DateTime.Parse( Console.ReadLine());
                    }
                 },
                 new MenuItem
                 {
                     Text = "Добавить текст записи",
                    Command =() => {
                        Console.WriteLine("Введите текст записи :");
                        record.Text = Console.ReadLine();
                    }
                 },
                 new MenuItem
                 {
                     Text = "Сохранить запись и вернуться",
                    Command =() => {
                        isExit = true;
                    }
                 },
            };
            var menu = Menu.CreateMenu("Выберите действие", menuItems);
            while (!isExit)
            {
                menu.ShowMenu();
            }
            return record;
        }
        private RecordElement CreateNewRecord()
        {
            return CreateNewRecord(new RecordElement());
        }


        internal void NewRecord()
        {
            var rec = CreateNewRecord();
            _schedular.AddRecord(rec);
        }

        /// <summary>
        /// Показывает все записи в ежедневнике.
        /// </summary>      
        internal void ShowRecords()
        {
            var col1 = "Заголовок записи\t";
            var col2 = "Дата записи\t";
            var col3 = "Срок выполнения\t";
            var col4 = "Место действия\t";
            var col5 = "Основной текст";


            for (var i = 0; i < _schedular.Count; i++)
            {
                var record = _schedular.GetRecord(i);
                Console.WriteLine(
                        new string('-', 60) + "\n"
                        + $"№ записи = {i+1}" + "\n"
                        + new string('*', 10) + "Заголовок" + new string('*', 10) + "\n"
                        + record.Title + "\n"
                        + new string('*', 10) + "Дата записи" + new string('*', 10) + "\n"
                        + record.Date + "\n"
                        + new string('*', 10) + "Срок окончания" + new string('*', 10) + "\n"
                        + record.EndDate + "\n"
                        + new string('*', 10) + "Место расположения" + new string('*', 10) + "\n"
                        + record.Place + "\n"
                        + new string('*', 10) + "Основной текст" + new string('*', 10) + "\n"
                        + record.Text + "\n"
                        + new string('-', 60)
                    );
            }
        }

        internal void RemoveRecord()
        {
            Console.WriteLine("Введите номер записи");
            var index = int.Parse(Console.ReadLine());
            index--;
            _schedular.RemoveRecord(index);
        }

        internal void EditRecord()
        {
            Console.WriteLine("Введите номер записи");
            var index = int.Parse(Console.ReadLine());
            index--;
            var newRecord = CreateNewRecord(_schedular.GetRecord(index));
            _schedular.EditRecord(index, newRecord);
        }

        internal void Save()
        {
            _schedular.Save();
        }

        internal void Load()
        {
            _schedular.Load();
        }
    }
}
