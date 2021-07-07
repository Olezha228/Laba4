using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp3
{
    class Program
    {
        const int left = -200, right = 200;

        static int Parsing()
        {
            bool ok, ;
            int n;
            
            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n);
                if (!ok) Console.WriteLine("Значение введено неверно! Введите заново: ");
                else if (n <= 0) Console.WriteLine("Число должно быть положительным! Введите заново: ");
            }
            while ((!ok) || (n <= 0));
            return n;
        }

        static int ParsingElement()
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n);
                if (!ok) Console.WriteLine("Значение введено неверно! Введите заново: ");
            }
            while (!ok);
            return n;
        }

        static void Main(string[] args)
        {
            int keepGo;
            bool tru;
            do
            {
                Console.Write("Меню:\n1) Создание рандомного массива  \n2) Создание массива вручную \n3) " +
                    "Удаление максимального элемента \n4) " +
                    "Добавление k элементов в конец массива  \n5) Сдвинуть циклически на M элементов влево \n6) " +
                    "Поиск первого отрицательного элемента  \n7) Сортировка простым обменом  \n" + "Ваше решение: ");

                int i = Parsing();
                int[] mas;
                switch (i)
                {

                    case 1:
                        {
                            Console.WriteLine("Введите кол-во элементов в массиве: ");
                            int size = Parsing();
                            mas = new int[size];
                            Random rnd = new Random();
                            for (int j = 0; j < size; j++)
                            {
                                mas[j] = rnd.Next(left, right);
                                Console.Write(mas[j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Введите кол-во элементов в массиве: ");
                            int size = Parsing();
                            mas = new int[size];
                            for (int j = 0; j < size; j++)
                                mas[j] = ParsingElement();
                            foreach (int x in mas) Console.Write(x + " ");
                            Console.WriteLine();
                        }
                        break;
                        
                    case 3:
                            Console.WriteLine("4");
                            break;
                    case 4:
                             Console.WriteLine("4");
                             break;
                    case 5:
                             Console.WriteLine("5");
                             break;
                    case 6:
                             Console.WriteLine("6");
                             break;
                    case 7:
                             Console.WriteLine("7");
                             break;
                    case 8:
                             Console.WriteLine("8");
                             break;
                    default:
                             Console.WriteLine("В меню нет данного варианта!");
                             break;
                        
                }
                Console.WriteLine("Для продолжения введите 1, для завершения 0: ");
                string bul = Console.ReadLine();
                tru = int.TryParse(bul, out keepGo);
            } while (keepGo == 1 && tru);


        }
        
    }
}
