﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{


    class Node
    {
        public string Element { get; set; }
        public Node Next { get; set; }
    }

    class List
    {
        Node[] Elements;
        public List()
        {
            Elements = new Node[5];
        }
        public string this[int index]
        {
            get
            {
                return Elements[index].Element;
            }
            set
            {
                Elements[index].Element = value;
            }
        }


        private Node Head { get; set; }
        private Node Current { get; set; }

        public int Size { get; set; }

        //Удаление элемента списка
        public void DeleteNode(int number)
        {

            if ((Head != null) && (number < Size) && (number >= 0))
            {
                Node n = Head;
                Node prevNode = null;
                if (number == 0)
                {
                    n = n.Next;
                    Head = n;
                }
                if (number == Size)
                {
                    for (int i = 0; i < number - 2; i++)
                    {
                        n = n.Next;
                    }

                    n.Next = null;
                }
                else
                {
                    for (int i = 0; i < number - 1; i++)
                    {
                        prevNode = n;
                        n = n.Next;

                    }
                    n.Next = n.Next.Next;
                }

            }
        }

        //Получение значения "головного элемента" списка
        public Node GetHead()
        {
            return this.Head;
        }

        //Добавление элемента в список

        public void Push(string elem)
        {
            Size++;
            var node = new Node() { Element = elem };
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Current.Next = node;
            }
            Current = node;
        }


        //Вывод элементов списка в консоль

        public void Output()
        {
            Node n = Head;
            while (n != null)
            {
                Console.WriteLine($"Скейт-бренд: {n.Element}");
                n = n.Next;
            }
        }
        //Вложенный класс Owner и его инициализация
        public class Owner
        {
            private int _Id;
            private string _Name;
            private string _Organization;

            public int ID
            {
                get
                {
                    return _Id;
                }

            }
            public string Name
            {
                get
                {
                    return _Name;
                }

            }
            public string Organization
            {
                get
                {
                    return _Organization;
                }

            }
            public Owner(int Id, string Name, string Organization)
            {
                _Id = Id;
                _Name = Name;
                _Organization = Organization;
            }
        }

        //Вложенный класс Date и его инициализация

        public class Date
        {
            private string dateOfCreation;

            public string DateOfCreation
            {
                get
                {
                    return dateOfCreation;
                }
            }

            public Date(string _dateOfCreation)
            {
                dateOfCreation = _dateOfCreation;
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List e1 = new List();
            e1.Push("Santa Cruz");
            e1.Push("Carhartt");
            e1.Push("Pass~port");
            e1.Push("Blind");


            List e2 = new List();
            e2.Push("Supreme");
            e2.Push("FA|Hockey");
            e2.Push("Vans");
            e2.Push("Nike SB");
            e2.Push("Rassvet");



            Console.WriteLine("\nПервый список:");
            e1.Output();
            Console.WriteLine("\nВторой список:");
            e2.Output();
            Console.WriteLine("\nДобавление еще одного наименования в первый список: ");
            e1.Push("Dime");
            e1.Output();
            Console.WriteLine($"\nStringCounter: {e2.StringCounter()}");
            e2.SumOfStrings();
            e1.FirstAndLastString();
            e1.LongestAndShortestWord(); 




        }

    }


    public static class StatisticOperation
    {
        internal static void SumOfStrings(this List elem)
        {
            string Sum = "";
            Node head = elem.GetHead();
            for (int i = 1; i < elem.Size; i++)
            {
                Sum += head.Element;
                head = head.Next;
            }
            Console.WriteLine($"Сумма элементов списка: {Sum}");
        }

        internal static void FirstAndLastString(this List elem)
        {
            Node head = elem.GetHead();
            string first = head.Element;
            string last = first;
            int key;
            Node next = head.Next;
            while (next.Next != null)
            {
                key = String.Compare(first, next.Element);
                if (key > 0)
                {
                    first = next.Element;
                }
                if (key < 0)
                {
                    last = next.Element;
                }
                next = next.Next;
            }
            Console.WriteLine($"Самое первое слово в алфавитном порядке: {first}");
            Console.WriteLine($"Самое последнее слово в алфавитном порядке: {last}");
        }
        internal static int StringCounter(this List e)
        {
            return e.Size;
        }

        internal static void LongestAndShortestWord(this List elem)
        {
            Node head = elem.GetHead();
            string maxword = head.Element;
            string minword = head.Element;
            Node next = head.Next;
            while (next.Next != null)
            {
                if (next.Element.Length > maxword.Length)
                {
                    maxword = next.Element;

                }
                if (next.Element.Length < minword.Length)
                {
                    minword = next.Element;

                }
                next = next.Next;
            }
            Console.WriteLine($"Самое длинное слово в списке: {maxword}");
            Console.WriteLine($"Самое короткое слово в списке: {minword}");
        }
        
        //internal static void DeleteLastNode(this List e)
        //{
            


        //}
    }
}
