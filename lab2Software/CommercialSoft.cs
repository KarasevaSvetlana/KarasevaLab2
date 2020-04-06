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
    public class CommercialSoft : Software
    {
        public DateTime Date;
        public int UseDays;
        public float Price;
        private bool Flag;

        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public CommercialSoft()
        { }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Name">Название программного обеспечения</param>
        /// <param name="Manufacturer">Производитель программного обеспечения</param>
        /// <param name="Date">Дата установки</param>
        /// <param name="UseDays">Срок использования</param>
        /// <param name="Price">Цена</param>
        public CommercialSoft(string Name, string Manufacturer,DateTime Date, int UseDays, float Price)
        {
            this.Name = Name;
            this.Manufacturer = Manufacturer;
            this.Date = Date;
            this.UseDays = UseDays;
            this.Price = Price;
            Flag = checkValid();
        }

        /// <summary>
        /// Конструктор класса для возможности копирования информации
        /// </summary>
        /// <param name="soft">Информация о программном обеспечении</param>
        public CommercialSoft(CommercialSoft soft)
        {
            Name = soft.Name;
            Manufacturer = soft.Manufacturer;
            Date = soft.Date;
            UseDays = soft.UseDays;
            Price = soft.Price;
            Flag = checkValid();
        }

        /// <summary>
        /// Метод, который проверяет допустимо ли использовать ПО на текущую дату
        /// </summary>
        /// <returns>Истина, если ПО допустимо использовать, иначе - ложь</returns>
        public override bool checkValid() {
            DateTime nowDate = DateTime.Now;
            if (Date.AddDays(UseDays) >= nowDate) { return true; }
            else { return false; }
             }

        /// <summary>
        /// Метод для вывода информации о коммерческом программном обеспечении
        /// </summary>
        public override void displayInfo()
        {
            Console.WriteLine(Name + " " + Manufacturer + " установлено " + Date.ToString() + " стоимостью " + Price.ToString());
        }
    }
}
