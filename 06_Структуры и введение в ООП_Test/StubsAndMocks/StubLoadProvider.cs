using System;
using System.Collections.Generic;
using _06_Структуры_и_введение_в_ООП;
namespace _06_Структуры_и_введение_в_ООП_Test
{
    public class LoadProviderMock : ILoadProvider
    {
        public List<RecordElement> LoadFromFile()
        {
            return new List<RecordElement>
             {
                 new RecordElement
                 {
                     Date = DateTime.Parse("11.12.2022"),
                     EndDate = DateTime.Parse("11.12.2022"),
                     Place = "Дом",
                     Title = "Домашнее задание на ежедневник",
                     Text = "Сегодня я начал разрабатывать ежедневник.",
                 },
                 new RecordElement
                 {
                     Date = DateTime.Parse("15.12.2022"),
                     EndDate = DateTime.Parse("15.12.2022"),
                     Place = "Дом",
                     Title = "Не программировал",
                     Text = "Сегодня я сходил на процедуры. За программирование не садился",
                 },
                 new RecordElement
                 {
                     Date = DateTime.Parse("19.12.2022"),
                     EndDate = DateTime.Parse("19.12.2022"),
                     Place = "Дом",
                     Title = "Пульт управления плеером с Android приложения",
                     Text = "Пытался оптимизировать UI в мобильном клиенте. Клиент стал меньше тормозить.",
                 },
                 new RecordElement
                 {
                     Date = DateTime.Parse("25.12.2022"),
                     EndDate = DateTime.Parse("27.12.2022"),
                     Place = "Дом",
                     Title = "Домашнее задание на ежедневник",
                     Text = "Снова пытаюсь выполнить дз на ежедневник.\n" +
                            "Написал несколько тестов в Nunit для ускорения работы.",
                 }
             };
        }

        public List<RecordElement> LoadFromFile(string path)
        {
            return new List<RecordElement>
            {
                new RecordElement
                {
                    Date = DateTime.Parse("01.01.2022"),
                    EndDate = DateTime.Parse("01.01.2022"),
                    Place = "Дом",
                    Title = "1 Happy New Year!!!",
                    Text = "Это тест 2-го ежедневника",
                },
                new RecordElement
                {
                    Date = DateTime.Parse("02.01.2022"),
                    EndDate = DateTime.Parse("02.01.2022"),
                    Place = "Дом",
                    Title = "2 Happy New Year!!!",
                    Text = "Это тест 2-го ежедневника",
                },
                new RecordElement
                {
                    Date = DateTime.Parse("03.01.2022"),
                    EndDate = DateTime.Parse("03.01.2022"),
                    Place = "Дом",
                    Title = "3 Happy New Year!!!",
                    Text = "Это тест 2-го ежедневника",
                },
                new RecordElement
                {
                    Date = DateTime.Parse("04.01.2022"),
                    EndDate = DateTime.Parse("04.01.2022"),
                    Place = "Дом",
                    Title = "4 Happy New Year!!!",
                    Text = "Это тест 2-го ежедневника",
                },
            };
        }
    }
}
