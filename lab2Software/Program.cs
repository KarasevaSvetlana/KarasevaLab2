using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace lab2Software
{
    class Program
    {
        static void Main(string[] args)
        {
    

            TextWriterTraceListener trac = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(trac);

            FileInfo file = new FileInfo("input.txt");
            bool isFileExists = false;
            if (file.Exists)
            {
                isFileExists = true;
                Trace.WriteLine("файл input.txt найден");
            }

            if (!isFileExists)
            {
                StreamWriter tmp = new StreamWriter("input.txt");
                tmp.Close();
                Trace.WriteLine("файл input.txt был создан");
            }


            StreamReader reader = new StreamReader("input.txt");

            uint n = 0;
            if (!uint.TryParse(reader.ReadLine(), out n))
            {
                //Console.WriteLine("no values!");
                Trace.WriteLine("no values in input");
                Console.ReadKey();
                return;
            }

            List<Software> soft = new List<Software>(Convert.ToInt32(n));
            Software[] softSer = new Software[n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    string info = reader.ReadLine();
                    
                    string[] measures = info.Split(',');
                    if (measures.Length == 2)
                    {
                        soft.Add(new FreeSoft(measures[0], measures[1]));
                        softSer[i] = new FreeSoft(measures[0], measures[1]);
                    }
                    else if (measures.Length == 4)
                    {
                        soft.Add(new SharewareSoft(measures[0], measures[1], Convert.ToDateTime(measures[2]), int.Parse(measures[3])));
                        softSer[i] = new SharewareSoft(measures[0], measures[1], Convert.ToDateTime(measures[2]), int.Parse(measures[3]));
                    }
                    else
                    {
                        soft.Add(new CommercialSoft(measures[0], measures[1], Convert.ToDateTime(measures[2]), int.Parse(measures[3]), float.Parse(measures[4])));
                        softSer[i] = new CommercialSoft(measures[0], measures[1], Convert.ToDateTime(measures[2]), int.Parse(measures[3]), float.Parse(measures[4]));
                    }
                }

                Console.WriteLine("Информация о програмном обеспечении");
                foreach (Software animal in softSer)
                    animal.displayInfo();
                reader.Close();

                XmlSerializer formatter = new XmlSerializer(typeof(Software[]));
                using (FileStream fs = new FileStream("Software.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, softSer);
                    Trace.WriteLine("Объект сериализован");
                    //Console.WriteLine("Объект сериализован");
                }



                findListOfSoftware(soft);
                Console.ReadLine();

            }
            catch
            { //Console.WriteLine("ошибка при чтении данных");
                System.Diagnostics.Trace.WriteLine("ошибка при чтении данных");
               
            }
           
            Console.ReadKey();
        }
        /// <summary>
        /// Метод для вывода всей информации о програмном обеспечении, которое допустимо использовать на текущую дату
        /// </summary>
        /// <param name="Softwares">Список имеющегося программного обеспечения</param>
        public static void findListOfSoftware(List<Software> Softwares) {
            Console.WriteLine("Информация о програмном обеспечении, которое допустимо использовать на текущую дату");
            List<Software> foundSoftwares = Softwares.FindAll(item => item.checkValid() == true);
            foreach (Software foundSoftware in foundSoftwares)
                foundSoftware.displayInfo();
            Trace.WriteLine("поиск реализован");
        }
    
    }
}
