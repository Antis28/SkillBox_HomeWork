using System;
using System.Collections.Generic;
using _06_Структуры_и_введение_в_ООП;
using NUnit.Framework;

namespace _06_Структуры_и_введение_в_ООП_Test
{
    [TestFixture]
    public class SchedulerTests
    {
        private Scheduler _scheduler;
        private RecordElement _newRecordElement;
        private int _startCountRecordElements;


        [SetUp]
        public void Setup()
        {
            _startCountRecordElements = 5;
            _scheduler = new Scheduler(new LoadProviderMock(), new SaveProviderMock());
            _scheduler.Load();
            _newRecordElement = new RecordElement
            {
                Date = DateTime.Parse("11.12.2022"),
                EndDate = DateTime.Parse("11.12.2022"),
                Place = "Дом",
                Title = "Домашнее задание на ежедневник",
                Text = "Написал несколько тестов для ежедневника.",
            };
        }

        [Test]
        public void LoadAndCountCorrect()
        {
            var expectedCount = _startCountRecordElements;
            var actualCount = _scheduler.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void SaveCountCorrect()
        {
            _scheduler.Save();
        }

        [Test]
        public void GetRecordCorrect()
        {
            var expectedRecord = new RecordElement
            {
                Date = DateTime.Parse("11.12.2022"),
                EndDate = DateTime.Parse("11.12.2022"),
                Place = "Дом",
                Title = "Домашнее задание на ежедневник",
                Text = "Сегодня я начал разрабатывать ежедневник.",
            };
            var actualRecord = _scheduler.GetRecord(0);

            Assert.That(actualRecord, Is.EqualTo(expectedRecord));
        }

        [Test]
        public void AddRecordCorrectData()
        {
            var expectedRecord = _newRecordElement;
            _scheduler.AddRecord(expectedRecord);
            var actualRecord = _scheduler.GetRecord(_scheduler.Count - 1);

            Assert.That(actualRecord, Is.EqualTo(expectedRecord));
        }

        [Test]
        public void RemoveRecordCorrectIndex()
        {
            var expectedCount = _startCountRecordElements - 1;

            _scheduler.RemoveRecord(0);
            var actualCount = _scheduler.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveRecordCorrectData()
        {
            var expectedElement = _scheduler.GetRecord(1);
            var removedElement = _scheduler.GetRecord(0);
            _scheduler.RemoveRecord(removedElement);

            var actualElement = _scheduler.GetRecord(0);

            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }

        [Test]
        public void EditRecordCorrectDataAndIndexAddedCount()
        {
            var expectedCount = 5;

            _scheduler.EditRecord(0, _newRecordElement);
            var actualCount = _scheduler.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void EditRecordCorrectDataAndIndexDataEquals()
        {
            var expectedElement = _newRecordElement;

            _scheduler.EditRecord(0, _newRecordElement);
            var actualElement = _scheduler.GetRecord(0);

            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }

        [Test]
        public void AppendFileCountCorrect()
        {
            var expectedCount = _startCountRecordElements + 4;

            _scheduler.AppendFromFile("stub.csv");
            var actualCount = _scheduler.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AppendFileItemCorrect()
        {
            var expectedElement = new RecordElement
            {
                Date = DateTime.Parse("04.01.2022"),
                EndDate = DateTime.Parse("04.01.2022"),
                Place = "Дом",
                Title = "4 Happy New Year!!!",
                Text = "Это тест 2-го ежедневника",
            };

            _scheduler.AppendFromFile("stub.csv");
            var actualElement = _scheduler.GetRecord(_scheduler.Count - 1);

            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }

        [Test]
        public void SelectByDateCountEqualTwo()
        {
            var stringDate = "19.12.2022";
            var expectedCount = 2;

            var result = _scheduler.SelectByDate(stringDate);
            var actualCount = result.Count;

            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public void SelectByDateElementIsCorrect()
        {
            var stringDate = "19.12.2022";
            var expectedElement = new RecordElement
            {
                Date = DateTime.Parse("19.12.2022"),
                EndDate = DateTime.Parse("19.12.2022"),
                Place = "Дом",
                Title = "Пульт управления плеером с Android приложения",
                Text = "Пытался оптимизировать UI в мобильном клиенте. Клиент стал меньше тормозить.",
            };


            var result = _scheduler.SelectByDate(stringDate);
            var actualElement = result[0];

            Assert.That(expectedElement, Is.EqualTo(actualElement));
        }

        [Test]
        public void SortByDateFieldElementsCorrect()
        {
            var expectedElementFirst = new RecordElement
            {
                Date = DateTime.Parse("11.12.2022"),
                EndDate = DateTime.Parse("11.12.2022"),
                Place = "Дом",
                Title = "Домашнее задание на ежедневник",
                Text = "Сегодня я начал разрабатывать ежедневник.",
            };
            var expectedElementLast = new RecordElement
            {
                Date = DateTime.Parse("25.12.2022"),
                EndDate = DateTime.Parse("27.12.2022"),
                Place = "Дом",
                Title = "Домашнее задание на ежедневник",
                Text = "Снова пытаюсь выполнить дз на ежедневник.\n" +
                       "Написал несколько тестов в Nunit для ускорения работы.",
            };


            _scheduler.SortByField(RecordField.Date);
            var actualElementFirst = _scheduler.GetRecord(0);
            var actualElementLast = _scheduler.GetRecord(_scheduler.Count - 1);

            Assert.That(expectedElementFirst.Date, Is.EqualTo(actualElementFirst.Date));
            Assert.That(expectedElementLast.Date, Is.EqualTo(actualElementLast.Date));
        }

        [Test]
        public void SortByTitleFieldElementsCorrect()
        {
            var expectedElementFirst = new RecordElement
            {
                Date = DateTime.Parse("25.12.2022"),
                EndDate = DateTime.Parse("27.12.2022"),
                Place = "Дом",
                Title = "А домашнее задание на ежедневник?",
                Text = "Снова пытаюсь выполнить дз на ежедневник.\n" +
                       "Написал несколько тестов в Nunit для ускорения работы.",
            };
            var expectedElementLast = new RecordElement
            {
                Date = DateTime.Parse("15.12.2022"),
                EndDate = DateTime.Parse("15.12.2022"),
                Place = "Дом",
                Title = "Я не программировал",
                Text = "Сегодня я сходил на процедуры. За программирование не садился",
            };


            var resul = _scheduler.SortByField(RecordField.Title);
            var actualElementFirst = resul[0];
            var actualElementLast = resul[_scheduler.Count - 1];

            Assert.That(expectedElementFirst.Title, Is.EqualTo(actualElementFirst.Title));
            Assert.That(expectedElementLast.Title, Is.EqualTo(actualElementLast.Title));
        }
        
        [Test]
        public void SortByEndDateFieldElementsCorrect()
        {
            var expectedElementFirst = new RecordElement
            {
                Date = DateTime.Parse("11.12.2022"),
                EndDate = DateTime.Parse("11.12.2022"),
                Place = "Дом",
                Title = "Домашнее задание на ежедневник",
                Text = "Сегодня я начал разрабатывать ежедневник.",
            };
            var expectedElementLast = new RecordElement
            {
                Date = DateTime.Parse("15.12.2022"),
                EndDate = DateTime.Parse("30.12.2022"),
                Place = "Водолечебница",
                Title = "Я не программировал",
                Text = "Сегодня я сходил на процедуры. За программирование не садился",
            };


            var resul = _scheduler.SortByField(RecordField.EndDate);
            var actualElementFirst = resul[0];
            var actualElementLast = resul[_scheduler.Count - 1];

            Assert.That(expectedElementFirst.EndDate, Is.EqualTo(actualElementFirst.EndDate));
            Assert.That(expectedElementLast.EndDate, Is.EqualTo(actualElementLast.EndDate));
        }
        
        [Test]
        public void SortByPlaceFieldElementsCorrect()
        {
            var expectedElementFirst = "Водолечебница";
            var expectedElementLast = "Дом";
            


            var resul = _scheduler.SortByField(RecordField.Place);
            var actualElementFirst = resul[0];
            var actualElementLast = resul[_scheduler.Count - 1];

            Assert.That(expectedElementFirst, Is.EqualTo(actualElementFirst.Place));
            Assert.That(expectedElementLast, Is.EqualTo(actualElementLast.Place));
        }
        
        [Test]
        public void SortByPlaceTextElementsCorrect()
        {
            var expectedElementFirst = "Пытался оптимизировать UI в мобильном клиенте. Клиент стал меньше тормозить.";
            var expectedElementLast = "Снова пытаюсь выполнить дз на ежедневник.\n" +
                                      "Написал несколько тестов в Nunit для ускорения работы.";

            var resul = _scheduler.SortByField(RecordField.Text);
            var actualElementFirst = resul[0];
            var actualElementLast = resul[_scheduler.Count - 1];

            Assert.That(expectedElementFirst, Is.EqualTo(actualElementFirst.Text));
            Assert.That(expectedElementLast, Is.EqualTo(actualElementLast.Text));
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SortByFieldNonCorrect()
        {
            var expectedElementFirst = "Водолечебница";
            var expectedElementLast = "Дом";
            


            var resul = _scheduler.SortByField((RecordField)10);
            var actualElementFirst = resul[0];
            var actualElementLast = resul[_scheduler.Count - 1];

            Assert.That(expectedElementFirst, Is.EqualTo(actualElementFirst.Text));
            Assert.That(expectedElementLast, Is.EqualTo(actualElementLast.Text));
        }
    }
}
