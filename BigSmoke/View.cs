using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BigSmoke
{
    class View
    {
        public static void message(string str)
        {
            Console.WriteLine(
                Thread.CurrentThread.Name + 
               // "(" + Thread.CurrentThread.ManagedThreadId + ")" + 
                ": \t" + str
            );
        }

        public static void rawMessage(string str)
        {
            Console.Write(str);
        }
    }
}
