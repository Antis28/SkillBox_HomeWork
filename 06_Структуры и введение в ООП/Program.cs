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
            var schedular = new SchedularConsolUI("");


            var greatings = "Добро пожаловать выберите действие";
            var menu = ConstructMainMenu(schedular, greatings);

            while (!isExit)
            {
                menu.ShowMenu();
            }
        }

        private static Menu ConstructMainMenu(SchedularConsolUI schedular, string greatings)
        {
            var menuItems = new MenuItem[]
            {
                new MenuItem
                {
                    Text = "Показать все записи",
                    Command = () =>{
                       schedular.ShowRecords();
                       Console.ReadKey();
                    }
                },
                new MenuItem
                {
                    Text = "Создать новую запись",
                    Command = () =>{
                        schedular.NewRecord();
                    }
                },
                new MenuItem
                { Text = "Удалить запись",
                    Command =() => {
                        schedular.RemoveRecord();
                    }
                },
                 new MenuItem
                 {
                     Text = "Редактировать запись",
                     Command = () => {
                        schedular.EditRecord();
                    }
                 },
                 new MenuItem
                 {
                     Text = "Сохранить",
                     Command = () => {
                        schedular.Save();
                    }
                 },
                 new MenuItem
                 {
                     Text = "Загрузить",
                    Command =() => {
                       schedular.Load();
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
