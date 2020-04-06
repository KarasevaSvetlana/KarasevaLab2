using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace lab2Software
{
    [XmlInclude(typeof(FreeSoft))]
    [XmlInclude(typeof(SharewareSoft))]
    [XmlInclude(typeof(CommercialSoft))]
    [Serializable]
    public abstract class Software
    {
        public string Name;
        public string Manufacturer;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Name">Название программного обеспечения</param>
        /// <param name="Manufacturer">Производитель программного обеспечения</param>
        public Software(string Name, string Manufacturer)
        {
            this.Name = Name;
            this.Manufacturer = Manufacturer;
        }
        
        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public Software() {}


        /// <summary>
        /// Метод, который проверяет допустимо ли использовать ПО на текущую дату
        /// </summary>
        /// <returns>Истина, если ПО допустимо использовать, иначе - ложь</returns>
        public abstract bool checkValid();
        
        /// <summary>
        /// Метод для вывода информации о программном обеспечении
        /// </summary>
        public abstract void displayInfo();
    }
}
