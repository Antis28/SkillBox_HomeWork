using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Структуры_и_введение_в_ООП
{
    internal struct Schedular
    {
        internal int Count => _records.Count;

        private string _path;
        private List<RecordElement> _records;
        private Encoding _defaultEncoding;

        public Schedular(string path)
        {
            _path = path;
            _path = "db.csv";
            _defaultEncoding = Encoding.UTF8;
            _records = new List<RecordElement>();
            _records = LoadFromFile(_path);
        }

        public void AddRecord(RecordElement record) 
        {
            _records.Add(record);
        }

        public void RemoveRecord(RecordElement record) 
        {
            _records.Remove(record);
        }
        public void RemoveRecord(int index)
        {
            _records.RemoveAt(index);
        }


        public void EditRecord(int index, RecordElement record) 
        {
            _records[index] = record;
        }
        public void Save()
        {
            SaveToFile();
        }

        public void Load() { LoadFromFile(_path); }
        public void AppendFromFile() { throw new NotImplementedException(); }
        public void SelectByDate() { throw new NotImplementedException(); }
        public void SortByFild() { throw new NotImplementedException(); }

        private void SaveToFile()
        {
            var note = new StringBuilder();

            foreach (var record in _records)
            {
                note.AppendLine(PrepareFormat(record));
            }
            using (StreamWriter sw = new StreamWriter(_path, true, _defaultEncoding))
            {
                sw.Write(note);
            }
        }

        private string PrepareFormat(RecordElement record)
        {
            var note = new StringBuilder();
            // Дата записи               
            note.Append($"{record.Date}\t");
            // Дата окончания               
            note.Append($"{record.EndDate}\t");
            // Место проведения             
            note.Append($"{record.Place}\t");
            // Заголовок записи
            note.Append($"{record.Title}\t");
            // Текст записи
            note.Append($"{record.Text}\t");

            return note.ToString();
        }

        private List<RecordElement> LoadFromFile(string path)
        {
            List<RecordElement> recordElements = new List<RecordElement>();
            if (!File.Exists(_path))
            {
                return recordElements;
            }
            
            // чтение из файла
            using (var sr = new StreamReader(_path, _defaultEncoding))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    Console.WriteLine($"{data[0],15}{data[1],8} {data[2]}");
                    var rec = new RecordElement
                    {
                        Date = DateTime.Parse(data[0]),
                        EndDate = DateTime.Parse(data[1]),
                        Place = data[2],
                        Title = data[3],
                        Text = data[4],
                    };
                    recordElements.Add(rec);
                }
            }
            return recordElements;
        }
       
        internal RecordElement GetRecord(int index)
        {
            return _records[index];
        }       
       
    }
}
