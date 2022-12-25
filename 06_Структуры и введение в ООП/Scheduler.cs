using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<RecordElement> SelectByDate(string date)
        {
            var selectData = DateTime.Parse("19.12.2022");
            var res = from rec in _records
                      where rec.Date == selectData
                      select rec;
            return res.ToList();
        }

        public List<RecordElement> SortByField(RecordField field)
        {
            switch (field)
            {
                case RecordField.Date:
                    return SortByDate();
                    break;
                case RecordField.EndDate:
                    return SortByEndDate();
                    break;
                case RecordField.Place:
                    return SortByPlace();
                    break;
                case RecordField.Title:
                    return SortByTitle();
                    break;
                case RecordField.Text:
                    return SortByText();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(field), field, null);
            }
        }

        

        public RecordElement GetRecord(int index) => _records[index];

        private List<RecordElement> SortByDate()
        {
            var res = from rec in _records
                      orderby rec.Date, rec.Title
                      select rec;
            return res.ToList();
        }
        private List<RecordElement> SortByTitle()
        {
            var res = from rec in _records
                      orderby rec.Title
                      select rec;
            return res.ToList();
        }
        private List<RecordElement> SortByText()
        {
            var res = from rec in _records
                      orderby rec.Text
                      select rec;
            return res.ToList();
        }
        private List<RecordElement> SortByPlace()
        {
            var res = from rec in _records
                      orderby rec.Place
                      select rec;
            return res.ToList();
        }
        private List<RecordElement> SortByEndDate()
        {
            var res = from rec in _records
                      orderby rec.EndDate
                      select rec;
            return res.ToList();
        }
    }
}
