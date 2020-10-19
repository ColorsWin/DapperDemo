using DapperDemo.Test;
using System;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connetionString = "Data Source=|DataDirectory|\\DB\\Test.db; Pooling=true;Min Pool Size=1";
            //TestUser.Ouput(connetionString);

            TestRole.Ouput(connetionString);
            Console.Read();
        }
    }
}
