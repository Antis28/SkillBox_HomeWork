using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _06_Структуры_и_введение_в_ООП;

internal class SaveProvider : ISaveProvider
{
    private readonly string _path;
    private readonly Encoding _defaultEncoding;

    public SaveProvider(string path,Encoding defaultEncoding )
    {
        _defaultEncoding = defaultEncoding;
        _path = path;
    }

    public void  SaveToFile(List<RecordElement> records)
    {
        var note = new StringBuilder();

        foreach (var record in records)
        {
            note.AppendLine(PrepareFormat(record));
        }
        using (StreamWriter sw = new StreamWriter(_path, false, _defaultEncoding))
        {
            sw.Write(note);
        }
    }
    
    private static string PrepareFormat(RecordElement record)
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
}
