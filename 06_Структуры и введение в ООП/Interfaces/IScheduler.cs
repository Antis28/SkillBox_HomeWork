using System.Collections.Generic;

namespace _06_Структуры_и_введение_в_ООП;

internal interface IScheduler
{
    public int Count { get; }
    
    public void AddRecord(RecordElement record);
    public void RemoveRecord(RecordElement record);
    public void RemoveRecord(int index);
    public void EditRecord(int index, RecordElement record);

    public void Save();
    public void Load();

    public RecordElement GetRecord(int index);
    public void AppendFromFile(string path);
    public List<RecordElement> SelectByDate(string date);
    public void SortByField();
}
