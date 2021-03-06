﻿using System;

namespace NetCore
{
    class Program
    {
        static void Main(string[] args)
        {

            var amount = 10000;

            var data = new MyData(amount);

            Console.WriteLine($"Using {amount} initial items");
            Console.WriteLine();

            var meterings = data.Meterings;

            Test.Run(new SQLClientProvider(meterings));

            Test.Run(new EFCProvider(meterings));

            Console.Write("Finished. Hit Enter to continue..");
            Console.ReadLine();
        }
    }
}
