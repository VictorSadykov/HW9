using System;

namespace HW9
{
    internal class Program
    {
        
        public const string SORT_IN_ALPHABETICAL_ORDER = "1";
        public const string SORT_IN_REVERSE_ALPHABETICAL_ORDER = "2";

        static void Main(string[] args)
        {

            // Задание 1
            Exception[] exceptions = new Exception[5];
            exceptions[0] = new CustomException("CustomException was thrown");
            exceptions[1] = new NullReferenceException("NullReferenceException was thrown");
            exceptions[2] = new StackOverflowException("StackOverflowException was thrown");
            exceptions[3] = new AccessViolationException("AccessViolationException was thrown");
            exceptions[4] = new ArgumentOutOfRangeException("ArgumentOutOfRangeException was thrown");

            foreach (var item in exceptions)
            {
                try
                {
                    throw item;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            // Задание 2

            string[] surnames = new string[5];
            for (int i = 0; i < surnames.Length; i++)
            {
                try
                {
                    Console.Write("Введите фамилию: ");
                    surnames[i] = Console.ReadLine();


                    for (int j = 0; j < surnames[i].Length; j++)
                    {
                        string symbol = surnames[i][j].ToString();
                        if (int.TryParse(symbol, out int number))
                        {
                            throw new CustomException("Введено некорректное значение. Фамилия не может содержать в себе цифры");
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            SortHelper sortHelper = new SortHelper();
            sortHelper.SortStarted += Sort;




            string[] sortedArray = sortHelper.Sort(surnames);

            foreach (var item in sortedArray)
            {
                Console.WriteLine(item);
            }
        }

        static string[] Sort(string[] array)
        {
            Console.WriteLine("Введите значение");
            Console.WriteLine("1 - Отсортировать массив в алфавитном порядке");
            Console.WriteLine("2 - Отсортировать обратном в алфавитном порядке");
            bool bl = false;
            do
            {
                string operation = Console.ReadLine();
                try
                {
                    switch (operation)
                    {
                        case SORT_IN_ALPHABETICAL_ORDER:
                            Array.Sort(array);
                            bl = false;

                            break;
                        case SORT_IN_REVERSE_ALPHABETICAL_ORDER:
                            Array.Sort(array);
                            Array.Reverse(array);
                            bl = false;
                            break;
                        default:
                            throw new CustomException("Введено неверное значение. Введите 1 или 2");
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    bl = true;
                }
            } while (bl);


            return array;
        }
    }
}
