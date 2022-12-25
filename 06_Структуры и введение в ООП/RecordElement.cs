using System;

namespace _06_Структуры_и_введение_в_ООП
{
    public struct RecordElement
    {
        /// <summary>
        /// Дата записи
        /// </summary>
        public DateTime Date { get;  set; }
        /// <summary>
        /// Срок выполнения
        /// </summary>
        public DateTime EndDate { get;  set; }
        /// <summary>
        /// Заголовок записи
        /// </summary>
        public string Title { get;  set; }
        /// <summary>
        /// Основной текст
        /// </summary>
        public string Text { get;  set; }
        /// <summary>
        /// Место действия
        /// </summary>
        public string Place { get;  set; }        
    }
}
