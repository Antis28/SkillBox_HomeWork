using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Структуры_и_введение_в_ООП
{
    public struct Scheduler : IScheduler
    {
        public int Count => _records.Count;
        private List<RecordElement> _records;

        private readonly ISaveProvider _saveProvider;
        private readonly ILoadProvider _loadProvider;

        public Scheduler(string pathToFile)
        {
            pathToFile = "db.csv";
            _loadProvider = new LoadProvider(pathToFile, Encoding.UTF8);
            _saveProvider = new SaveProvider(pathToFile, Encoding.UTF8);
        }

        /// <summary>
        /// Для тестов
        /// </summary>
        /// <param name="loadProvider"></param>
        /// <param name="saveProvider"></param>
        public Scheduler(ILoadProvider loadProvider, ISaveProvider saveProvider)
        {
            _loadProvider = loadProvider;
            _saveProvider = saveProvider;
        }

        public readonly void AddRecord(RecordElement record) => _records.Add(record);

        public void RemoveRecord(RecordElement record) => _records.Remove(record);

        public void RemoveRecord(int index) => _records.RemoveAt(index);


        public void EditRecord(int index, RecordElement record) => _records[index] = record;

        public void Save() => _saveProvider.SaveToFile(_records);


        public void Load() => _records = _loadProvider.LoadFromFile();

        public void AppendFromFile(string path)
        {
            _records.AddRange(_loadProvider.LoadFromFile(path));
        }

        public void SelectByDate()
        {
            throw new NotImplementedException();
        }

        public void SortByField()
        {
            throw new NotImplementedException();
        }

        public RecordElement GetRecord(int index) => _records[index];
    }
}
