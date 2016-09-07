using System;
using System.Threading;

namespace AsynchronousProgramming
{
    internal class AsyncProgram
    {
        //Create a delegate which has the same signature as the LongRunningMethod
        private delegate void DelLongRunningMethod();

        private static void Main()
        {
            Console.WriteLine("Main method started.");

            //Display the current thread id
            Console.WriteLine(string.Format("Current Thread Id is {0}", Thread.CurrentThread.ManagedThreadId));

            //Create an instance of the delegate passing the function name as the parameter
            var del = new DelLongRunningMethod(LongRunningMethod);

            //Call the BeginInvoke method to start executing the LongRunningMethod asynchronously
            del.BeginInvoke(null, null);

            Console.WriteLine("Main method ended.");
            Console.ReadKey();
        }

        private static void LongRunningMethod()
        {
            Console.WriteLine("LongRunningMethod started");

            //Display the current thread id
            Console.WriteLine(string.Format("Current Thread Id is {0}", Thread.CurrentThread.ManagedThreadId));

            //Create a delay to replicate a long running process
            Thread.Sleep(3000);

            Console.WriteLine("LongRunningMethod ended");
        }

        private static void MultiplyNumbers(out int threadId)
        {
            Console.WriteLine("MethodWithParameters started");
            //Create a delay to replicate a long running process
            threadId = Thread.CurrentThread.ManagedThreadId;
            Thread.Sleep(3000);
            Console.WriteLine("MethodWithParameters ended");
        }
    }
}