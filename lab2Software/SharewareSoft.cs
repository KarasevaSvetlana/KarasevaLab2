using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace lab2Software
{
    [Serializable]
    public class SharewareSoft : Software
    {
        public DateTime Date;
        public int FreeDays;
        private bool Flag;
        
        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public SharewareSoft()
        { }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Name">Название программного обеспечения</param>
        /// <param name="Manufacturer">Производитель программного обеспечения</param>
        /// <param name="Date">Дата установки</param>
        /// <param name="FreeDays">Срок бесплатного использования</param>
        public SharewareSoft(string Name, string Manufacturer, DateTime Date, int FreeDays)
        {
            this.Name = Name;
            this.Manufacturer = Manufacturer;
            this.Date = Date;
            this.FreeDays = FreeDays;
            Flag = checkValid();
        }
        
        /// <summary>
        /// Конструктор класса для возможности копирования информации
        /// </summary>
        /// <param name="soft">Информация о программном обеспечении</param>
        public SharewareSoft(SharewareSoft soft)
        {
            Name = soft.Name;
            Manufacturer = soft.Manufacturer;
            Date = soft.Date;
            FreeDays = soft.FreeDays;
            Flag = checkValid();
        }

        /// <summary>
        /// Метод, который проверяет допустимо ли использовать ПО на текущую дату
        /// </summary>
        /// <returns>Истина, если ПО допустимо использовать, иначе - ложь</returns>
        public override bool checkValid()
        {
            DateTime nowDate = DateTime.Now;
            if (Date.AddDays(FreeDays) >= nowDate) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Метод для вывода информации об условно-бесплатном программном обеспечении
        /// </summary>
        public override void displayInfo()
        {
            Console.WriteLine(Name + " " + Manufacturer + " установлено " + Date.ToString());
        }

    }
}
