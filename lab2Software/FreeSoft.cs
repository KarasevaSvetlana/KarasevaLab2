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
    public class FreeSoft : Software
    {
        private bool Flag;
        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public FreeSoft()
        { }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Name">Название программного обеспечения</param>
        /// <param name="Manufacturer">Производитель программного обеспечения</param>
        public FreeSoft(string Name, string Manufacturer)
        {
            this.Name = Name;
            this.Manufacturer = Manufacturer;
            Flag = checkValid();
        }

        /// <summary>
        /// Конструктор класса для возможности копирования информации
        /// </summary>
        /// <param name="soft">Информация о программном обеспечении</param>
        public FreeSoft(FreeSoft soft)
        {
            Name = soft.Name;
            Manufacturer = soft.Manufacturer;
            Flag = checkValid();
        }

        /// <summary>
        /// Метод, который проверяет допустимо ли использовать ПО на текущую дату
        /// </summary>
        /// <returns>Истина, если ПО допустимо использовать, иначе - ложь</returns>
        public override bool checkValid() { return true; }

        /// <summary>
        /// Метод для вывода информации о бесплатном программном обеспечении
        /// </summary>
        public override void displayInfo()
        {
            Console.WriteLine(Name + " " + Manufacturer + " допустимо использовать");
        }

    }
}
