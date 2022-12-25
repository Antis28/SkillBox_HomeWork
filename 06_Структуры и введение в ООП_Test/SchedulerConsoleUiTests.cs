using System;
using _06_Структуры_и_введение_в_ООП;
using NUnit.Framework;

namespace _06_Структуры_и_введение_в_ООП_Test
{
    [TestFixture]
    public class SchedulerConsoleUiTests
    {
        private Scheduler _scheduler;
        [SetUp]
        public void Setup()
        {
            _scheduler = new Scheduler(new LoadProviderMock(), new SaveProviderMock());
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
    }
}
