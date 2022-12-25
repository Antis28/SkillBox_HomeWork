using System.Collections.Generic;

namespace _06_Структуры_и_введение_в_ООП;

public interface ILoadProvider
{
    public List<RecordElement> LoadFromFile();
    public List<RecordElement> LoadFromFile(string path);
}

