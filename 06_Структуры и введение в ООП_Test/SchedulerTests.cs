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
       

        [SetUp]
        public void Setup()
        {
            _scheduler = new Scheduler(new LoadProviderMock(), new SaveProviderMock());
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
            var expectedCount = 4;
            _scheduler.Load();
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
            _scheduler.Load();
            var actualRecord = _scheduler.GetRecord(0);

            Assert.That(actualRecord, Is.EqualTo(expectedRecord));
        }

        [Test]
        public void AddRecordCorrectData()
        {
            var expectedRecord = _newRecordElement;
            _scheduler.Load();
            _scheduler.AddRecord(expectedRecord);
            var actualRecord = _scheduler.GetRecord(_scheduler.Count - 1);

            Assert.That(actualRecord, Is.EqualTo(expectedRecord));
        }
        
        [Test]
        public void RemoveRecordCorrectIndex()
        {
            var expectedCount = 3;
            
            _scheduler.Load();
            
            _scheduler.RemoveRecord(0);
            
            var actualCount = _scheduler.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [Test]
        public void RemoveRecordCorrectData()
        {
            var expectedCount = 3;
            
            _scheduler.Load();
            var element =  _scheduler.GetRecord(0);
            
            _scheduler.RemoveRecord(element);
            
            var actualCount = _scheduler.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [Test]
        public void EditRecordCorrectDataAndIndexAddedCount()
        {
            var expectedCount = 4;
            
            _scheduler.Load();

            _scheduler.EditRecord(0,_newRecordElement);
            var actualCount = _scheduler.Count;
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [Test]
        public void EditRecordCorrectDataAndIndexDataEquals()
        {
            var expectedElement = _newRecordElement;
            
            _scheduler.Load();

            _scheduler.EditRecord(0,_newRecordElement);
            var actualElement =  _scheduler.GetRecord(0);
          
            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }
        [Test]
        public void AppendFileCountCorrect()
        {
            var expectedCount = 8;
            
            _scheduler.Load();

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
            
            _scheduler.Load();

            _scheduler.AppendFromFile("stub.csv");
            var actualElement = _scheduler.GetRecord(_scheduler.Count-1);
          
            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }
    }
}
