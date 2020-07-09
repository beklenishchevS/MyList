using System;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            foreach(var e in myList)
            {
                Console.WriteLine(e);
            }
        }
    }
}
