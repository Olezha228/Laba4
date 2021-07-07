using System;
using System.CodeDom.Compiler;
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

        //функция парсирования положительного целого элемента
        static int Parsing(string stroka)
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n);
                if (!ok) Console.WriteLine("Значение введено неверно, необходимо ввести целое число! Введите заново: ");
                else if (n < 0) 
                { 
                    Console.WriteLine($"{stroka}! Введите заново: ");
                    ok = false;
                }
            }
            while (!ok);
            return n;
        }
        //функция поиска целого элемента
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
            bool keepGo; //выход из программы
            bool goOn;  //выход из меню2
            bool dalshe; //выход из меню1
            int i;
            do
            {
                //вывод меню на экран
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Шаг 1: \n1) Создание рандомного массива  \n2) Создание массива вручную \n3) Выход\n\n");
                
                Console.ResetColor();

                //Количество элементов в массиве
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Введите кол-во элементов в массиве:");
                Console.ResetColor();
                int size = Parsing("Количество элементов в массиве должно быть неотрицательным");
                int[] mas;
                if (size != 0)
                    mas = new int[size];
                else
                    mas = null;
                Console.WriteLine();

                dalshe = false;
                //ШАГ 1
                do
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Ваше решение(Шаг 1):");
                    Console.ResetColor();
                    keepGo = true;
                    goOn = true;
                    i = Parsing("Число должно быть положительным");
                    
                    switch(i)
                    {
                        case 1:         //Рандомный массив
                        #region
                            {

                                Random rnd = new Random();
                                Console.WriteLine("Сформированный массив: ");
                                if (mas != null)
                                    for (int j = 0; j < mas.Length; j++)
                                    {
                                        mas[j] = rnd.Next(left, right);
                                        Console.Write(mas[j] + " ");
                                    }
                                else Console.WriteLine("Пустой массив");
                                Console.WriteLine();
                                dalshe = false;
                                break;
                            }
                        #endregion      
                        case 2:         //Массив в ручную
                        #region
                            {
                                if (mas != null)
                                {
                                    Console.WriteLine("Введите элемент массива: ");
                                    for (int j = 0; j < mas.Length; j++)
                                        mas[j] = ParsingElement();
                                    Console.WriteLine("Сформированный массив: ");
                                    foreach (int x in mas) Console.Write(x + " ");
                                }
                                else Console.WriteLine("Массив пустой");
                                Console.WriteLine();
                                dalshe = false;
                                break;
                        }
                        #endregion
                        case 3:         //Выход из программы
                            goOn = false;
                            dalshe = false;
                            keepGo = false;
                            break;
                        default:
                        {
                            dalshe = true;
                            Console.WriteLine("В меню нет данного варианта!");
                            break;
                        }
                    }
                }
                while (dalshe);

                Console.WriteLine();

                //ШАГ 2
                while (goOn)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Шаг 2: \n1) " +
                    "Удаление максимального элемента \n2) " +
                    "Добавление k элементов в конец массива  \n3) Сдвинуть циклически на M элементов влево \n4) " +
                    "Поиск первого отрицательного элемента  \n5) Поиск в отсортированном массиве(простой обмен)  \n6) Переход к Шагу 1 \n7) Вывод массива на экран\n8) Выход\n\n");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ваше решение(Шаг 2):");
                    Console.ResetColor();
                    i = Parsing("Число должно быть положительным");

                    switch (i) 
                    { 
                        case 1:         //Удаление максимального элемента
                            #region 
                            {
                                if (mas == null) Console.WriteLine("Массив пуст. Соответственно в нем нет максимальных элементов.");
                                else
                                {
                                    //Поиск максимума
                                    int max = mas[0];
                                    for (int j = 1; j < mas.Length; j++)
                                        if (mas[j] > max) max = mas[j];
                                    //Поиск количества максимумов
                                    int countMax = 0;
                                    for (int j = 0; j < mas.Length; j++)
                                        if (mas[j] == max) countMax++;
                                    //Создание массива с удаленными максимумами
                                    if (mas.Length == 1)
                                    {
                                        Console.WriteLine("Теперь массив пуст");
                                        mas = null;
                                    }
                                    else if (countMax == mas.Length)
                                    {
                                        Console.WriteLine("Теперь массив пуст");
                                        mas = null;
                                    }
                                    else
                                    {
                                        int[] temp = new int[mas.Length - countMax];
                                        int number = 0;
                                        for (int j = 0; j < mas.Length; j++) // Поиск количества максимумов
                                            if (mas[j] != max)
                                            {
                                                temp[number] = mas[j];
                                                number++;
                                            }
                                        Console.WriteLine("В массиве удалены максимумы: ");
                                        foreach (int x in temp)
                                            Console.Write(x + " ");
                                        mas = temp;
                                        Console.WriteLine();
                                    }
                                }
                            }
                            Console.WriteLine();
                            break;

                        #endregion
                        case 2:         //Добавление k элементов в конец массива
                            #region
                            Console.Write("Введите, сколько чисел нужно добавить в массив: ");
                            int k = Parsing("Число должно быть положительным");

                            int[] temp2; //создание нового массива
                            if (mas != null)
                            {
                                temp2 = new int[mas.Length + k];
                                for (int j = 0; j < mas.Length; j++)        //присвоение элементов из прошлого массива
                                {
                                    temp2[j] = mas[j];
                                }
                                Console.WriteLine("Введите новые элементы: ");
                                for (int j = mas.Length; j < k + mas.Length; j++) // добавление в массив вводимых новых элементов
                                    temp2[j] = ParsingElement();
                            }
                            else
                            {
                                if (k == 0) temp2 = null;
                                else
                                {
                                    temp2 = new int[k];
                                    Console.WriteLine("Введите новые элементы: ");
                                    for (int j = 0; j < k; j++) // добавление в массив вводимых новых элементов
                                        temp2[j] = ParsingElement();
                                }
                            }
                            if (temp2 != mas)
                            {
                                Console.WriteLine("Массив после добавления элементов: ");
                                foreach (int x in temp2) Console.Write(x + " ");
                            }
                            else Console.WriteLine("Пустой массив");
                            Console.WriteLine();
                            mas = temp2; 
                            break;
                        #endregion

                        case 3:         //Сдвинуть циклически на M элементов влево
                            #region
                            if (mas != null)
                            {
                                Console.WriteLine("Введите, на сколько элементов необходимо сдвинуть влево");
                                int m = Parsing("Число должно быть положительным");
                                for (int j = 0; j < m; j++)  // сдвиг массива на j элементов влево
                                {
                                    int s = mas[0];
                                    for (int t = 0; t < mas.Length - 1; t++) //сдвиг элементов на один шаг влево
                                        mas[t] = mas[t + 1];
                                    mas[mas.Length - 1] = s;
                                }
                                Console.WriteLine($"Массив, сдвинутый на {m} элементов влево: ");
                                foreach (int x in mas) Console.Write(x + " ");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else
                                Console.WriteLine("Массив пуст. Действие невозможно.");
                            break;
                        #endregion
                        case 4:         //Поиск первого отрицательного элемента
                            #region
                            if (mas != null)
                            {
                                int firstOtr = 0;
                                int indexOtr = 0;
                                for (int j = 0; j < mas.Length; j++) //поиск первого отрицательного элемента и его индекса
                                    if (mas[j] < 0)
                                    {
                                        firstOtr = mas[j];
                                        indexOtr = j + 1;
                                        break;
                                    }
                                if (firstOtr == 0) Console.WriteLine("В массиве нет отрицательных элементов");
                                else Console.WriteLine($"Первый отрицательный элемент в массиве: {firstOtr}, стоящий на {indexOtr} месте");
                                Console.WriteLine();
                            }
                            else
                                Console.WriteLine("Массив пуст. Соответственно не имеет отрицательных элементов.");
                            break;
                        #endregion
                        case 5:         //Поиск в отсортированном массиве(простой обмен)
                            #region
                            Console.WriteLine("Введите число для поиска");
                            int numberForFind = ParsingElement();
                            if (mas == null) Console.WriteLine("Массив пуст. Действие невозможно.");
                            else if(mas.Length == 1)
                                {
                                    if (mas[0] == numberForFind) Console.WriteLine("Элемент найден. Позиция элемента - 1");
                                    else Console.WriteLine("Элемент не найден");
                                }
                            else
                            {
                                Console.WriteLine("Оставить массив отсортированным?\n1. Да\n2. Нет");
                                Console.Write("Ваш выбор: ");

                                int choiceMenu = Parsing("Число должно быть положительным");

                                switch (choiceMenu)
                                {
                                    case 1:
                                        #region
                                        int l;
                                        for (i = 1; i < mas.Length; i++) //сортировка массива по возрастанию простым обменом
                                            for (l = mas.Length - 1; l >= i; l--)
                                                if (mas[l] < mas[l - 1])
                                                {
                                                    int temp = mas[l];
                                                    mas[l] = mas[l - 1];
                                                    mas[l - 1] = temp;
                                                }
                                        foreach (int x in mas) Console.Write(x + " ");
                                        Console.WriteLine();
                                        Console.WriteLine();


                                        
                                        int left = 0, right = mas.Length - 1, sred;
                                        int sravn = 0;
                                        do
                                        {
                                            sravn += 1;
                                            sred = (left + right) / 2;//средний элемент
                                            if (mas[sred] < numberForFind) left = sred + 1;//перенести левую границу
                                            else right = sred;//перенести правую границу
                                        } while (left != right);
                                        if (mas[left] == numberForFind) Console.WriteLine("Номер Элемента {0} равен {1}\nКоличество сделанных сравнений - {2} ", numberForFind, left + 1, sravn);
                                        else Console.WriteLine("Элемент не найден");
                                        break;
                                    #endregion
                                    case 2:
                                        #region
                                        int srav = 0;
                                        int[] sort = new int[mas.Length];
                                        for (int j = 0; j < mas.Length; j++)
                                            sort[j] = mas[j];
                                        int cikle;
                                        for (i = 1; i < mas.Length; i++) //сортировка массива по возрастанию простым обменом
                                            for (cikle = mas.Length - 1; cikle >= i; cikle--)
                                                if (mas[cikle] < mas[cikle - 1])
                                                {
                                                    int temp = mas[cikle];
                                                    mas[cikle] = mas[cikle - 1];
                                                    mas[cikle - 1] = temp;
                                                }
                                        Console.WriteLine();
                                        Console.WriteLine();

                                        int numberFind = numberForFind;
                                        int left1 = 0, right2 = size - 1, sred1;


                                        do
                                        {
                                            srav += 1;
                                            sred1 = (left1 + right2) / 2;//средний элемент
                                            if (mas[sred1] < numberFind) left1 = sred1 + 1;//перенести левую границу
                                            else right2 = sred1;//перенести правую границу
                                        } while (left1 != right2);

                                        if (mas[left1] == numberFind) Console.WriteLine("Элемент {0} существует в данном массиве\nКоличество сделанных сравнений - {1}", numberFind, srav);
                                        else Console.WriteLine("Элемент не найден");

                                        break;
                                    #endregion

                                    default:
                                        Console.WriteLine("В меню нет такого пункта!");
                                        break;
                                }
                            }
                            break;
                        #endregion
                        case 6:         //Переход к Шагу 1
                            #region
                            goOn = false;   //переход к шагу1
                            Console.WriteLine();
                            break;
                        #endregion
                        case 7:         //Вывод массива на экран
                            Console.WriteLine("Текущий массив: ");
                            if (mas != null)
                                foreach (int x in mas) Console.Write(x + " ");
                            else Console.WriteLine("Массив пуст");
                            Console.WriteLine();
                            break;
                        case 8:         //Выход из программы
                        #region
                            keepGo = false;  //заврешение работы 
                            goOn = false;    //с программой
                            Console.WriteLine();
                            break;
                        #endregion
                        default:
                            Console.WriteLine("В меню нет данного варианта!");
                            break;
                    }
                }
            } while (keepGo);
        }
    }
}
