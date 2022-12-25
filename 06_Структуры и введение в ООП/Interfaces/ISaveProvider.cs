
using System.Collections.Generic;

namespace _06_Структуры_и_введение_в_ООП;

public interface ISaveProvider
{
    public void SaveToFile(List<RecordElement> records);
}