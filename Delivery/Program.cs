using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Delivery.Extension;
using Delivery.Interface;

namespace Delivery
{

    class Program
    {

        static void Main(string[] args)
        {
            CommandCalculate _command = new CommandCalculate();

            Console.WriteLine("Where is the path of the files?");
            var pathFile = Console.ReadLine();
            _command.CalculateRoute(pathFile);

        }
    }
}
