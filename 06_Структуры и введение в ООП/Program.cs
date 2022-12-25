/*
 Разработать ежедневник
+ создание
+ удаление
+ редактирование
записей

Возможности:
+ загрузки/сохранения из/в файл
- добавление данных в текущий ежедневник из выбранного файла
- импорт по выбранному диапазону дат
- упорядочивание записей по выбранному полю
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu;

namespace _06_Структуры_и_введение_в_ООП
{
    internal class Program
    {
        private static bool isExit = false;

        static void Main(string[] args)
        {
            var scheduler = new SchedulerConsoleUi("");


            var greatings = "Добро пожаловать выберите действие";
            var menu = ConstructMainMenu(scheduler, greatings);

            while (!isExit)
            {
                menu.ShowMenu();
            }
        }

        private static Menu ConstructMainMenu(SchedulerConsoleUi scheduler, string greatings)
        {
            var menuItems = new MenuItem[]
            {
                new MenuItem
                {
                    Text = "Показать все записи",
                    Command = () =>{
                       scheduler.ShowRecords();
                       Console.ReadKey();
                    }
                },
                new MenuItem
                {
                    Text = "Создать новую запись",
                    Command = () =>{
                        scheduler.NewRecord();
                    }
                },
                new MenuItem
                { Text = "Удалить запись",
                    Command =() => {
                        scheduler.RemoveRecord();
                    }
                },
                 new MenuItem
                 {
                     Text = "Редактировать запись",
                     Command = () => {
                        scheduler.EditRecord();
                    }
                 },
                 new MenuItem
                 {
                     Text = "Сохранить",
                     Command = () => {
                        scheduler.Save();
                    }
                 },
                 new MenuItem
                 {
                     Text = "Загрузить",
                    Command =() => {
                       scheduler.Load();
                    }
                 },
                 new MenuItem
                 {
                     Text = "Выйти",
                    Command =() => {
                       isExit = true;
                    }
                 },
            };
            var menu = Menu.CreateMenu(greatings, menuItems);
            return menu;
        }

    }
}
