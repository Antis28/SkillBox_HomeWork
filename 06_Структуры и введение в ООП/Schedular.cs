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
        private string _path;
        private List<RecordElement> records;

        public Schedular(string path)
        {
            _path = path;
            _path = "db.csv";
            records = new List<RecordElement>();
            OpenFile();
        }

        private void OpenFile()
        {
            // чтение из файла
            using (var sr = new StreamReader(_path, Encoding.Unicode))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {                    
                    string[] data = line.Split('\t');
                    Console.WriteLine($"{data[0],15}{data[1],8} {data[2]}");
                    var rec = new RecordElement
                    {
                        Date = DateTime.Parse(data[0]),
                        Title = data[1],
                        Text = data[2],
                        Place = data[3],
                        EndDate = DateTime.Parse(data[4]),
                    };
                }
            }
        }
        public void NewRecord() { throw new NotImplementedException(); }
        public void RemoveRecord() { throw new NotImplementedException(); }
        public void EditRecord() { throw new NotImplementedException(); }
        public void Save() { throw new NotImplementedException(); }
        public void Load() { throw new NotImplementedException(); }
        public void AppendFromFile() { throw new NotImplementedException(); }
        public void SelectByDate() { throw new NotImplementedException(); }
        public void SortByFild() { throw new NotImplementedException(); }
    }
}
