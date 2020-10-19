using DapperDemo.Test;
using System;

namespace DapperDemo
{
    class Program
    {
        private static string connetionString;
        static void Main(string[] args)
        {
            connetionString = "Data Source=|DataDirectory|\\DB\\Test.db; Pooling=true;Min Pool Size=1";
            TestRole.Ouput(connetionString);

            Console.Read();
        }

    }
}
