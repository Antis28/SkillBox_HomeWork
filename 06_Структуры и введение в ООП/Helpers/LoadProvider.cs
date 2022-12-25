using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _06_Структуры_и_введение_в_ООП;

internal class LoadProvider : ILoadProvider
{
    private readonly string _path;
    private readonly Encoding _defaultEncoding;

    public LoadProvider(string path,Encoding defaultEncoding )
    {
        _defaultEncoding = defaultEncoding;
        _path = path;
    }
    public List<RecordElement> LoadFromFile()
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
                //Console.WriteLine($"{data[0],15}{data[1],8} {data[2]}");
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
}
