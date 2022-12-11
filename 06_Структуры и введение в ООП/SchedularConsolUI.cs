﻿using ConsoleMenu;
using System;
using System.IO;
using System.Text;

namespace _06_Структуры_и_введение_в_ООП
{
    internal class SchedularConsolUI
    {
        private readonly string _mainPath;
        private readonly Schedular _schedular;

        internal SchedularConsolUI(string mainPath)
        {
            _mainPath = mainPath;
            _schedular = new Schedular(_mainPath);
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
            for (var i = 0; i < _schedular.Count; i++)
            {
                ShowRecord(i);
            }
        }
        internal void ShowRecord(int index)
        {
            var record = _schedular.GetRecord(index);
            ShowRecord(record);
        }
        internal void RemoveRecord()
        {
            int index = SelectRecordByIndex();
            if (index < 0) return;

            _schedular.RemoveRecord(index);

        }
        internal void EditRecord()
        {
            int index = SelectRecordByIndex();
            if (index < 0) return;

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

        #region private
        private int SelectRecordByIndex()
        {
            Console.WriteLine("Введите номер записи");
            ShowTitles();
            int.TryParse(Console.ReadLine(), out int index);
            index--;
            return index;
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
                        ShowRecord(record);
                        Console.WriteLine("Введите текст заголовка:");
                        record.Title = Console.ReadLine();
                    }
                },
                new MenuItem
                { Text = "Добавить место действия",
                    Command =() => {
                        ShowRecord(record);
                        Console.WriteLine("Введите место действия:");
                        record.Place = Console.ReadLine();
                    }
                },
                 new MenuItem
                 {
                     Text = "Добавить срок выполнения",
                     Command = () => {
                        ShowRecord(record);
                        Console.WriteLine("Введите количество дней:");
                        record.EndDate = DateTime.Now + TimeSpan.Parse(Console.ReadLine());
                    }
                 },
                 new MenuItem
                 {
                     Text = "Добавить дату вручную",
                     Command = () => {
                          ShowRecord(record);
                        Console.WriteLine("Введите дату в формате :");
                        record.Date =  DateTime.Parse( Console.ReadLine());
                    }
                 },
                 new MenuItem
                 {
                     Text = "Добавить текст записи",
                    Command =() => {
                         ShowRecord(record);
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
        private void ShowTitles()
        {
            for (int i = 0; i < _schedular.Count; i++)
            {
                Console.WriteLine((i + 1) + " - " + _schedular.GetRecord(i).Title);
            }
        }
        private static void ShowRecord(RecordElement record)
        {
            var col1 = "\tЗаголовок записи\t";
            var col2 = "\tДата записи\t";
            var col3 = "\tСрок выполнения\t";
            var col4 = "\tМесто действия\t";
            var col5 = "\tОсновной текст\t";
            Console.WriteLine(
                    new string('-', 60) + "\n"
                    + new string('*', 10) + col1 + new string('*', 10) + "\n"
                    + record.Title + "\n"
                    + new string('*', 10) + col2 + new string('*', 10) + "\n"
                    + record.Date + "\n"
                    + new string('*', 10) + col3 + new string('*', 10) + "\n"
                    + record.EndDate + "\n"
                    + new string('*', 10) + col4 + new string('*', 10) + "\n"
                    + record.Place + "\n"
                    + new string('*', 10) + col5 + new string('*', 10) + "\n"
                    + record.Text + "\n"
                    + new string('-', 60)
                );
        }
        #endregion
    }
}
