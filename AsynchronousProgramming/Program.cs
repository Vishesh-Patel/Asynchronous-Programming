using System;
using System.Threading;

namespace AsynchronousProgramming
{
    internal class AsyncProgram
    {
        //Create a delegate which has the same signature as the LongRunningMethod
        private delegate void DelLongRunningMethod();

        private delegate int DelMultiplyNumbers(int x, int y);

        private static void Main()
        {
            Console.WriteLine("Main method started.");

            //Display the current thread id
            Console.WriteLine(string.Format("Current Thread Id is {0}", Thread.CurrentThread.ManagedThreadId));

            //Create an instance of DelLongRunningMethod passing the function name as the parameter
            var del = new DelLongRunningMethod(LongRunningMethod);

            //Call the BeginInvoke method to start executing the LongRunningMethod asynchronously
            del.BeginInvoke(null, null);

            //Create an instance of DelMultiplyNumbers passing the function name as the parameter
            var delMultiplyNumbers = new DelMultiplyNumbers(MultiplyNumbers);

            //Call the BeginInvoke method to start executing the MultiplyNumbers method asynchronously.
            //The BeginInvoke method here takes the two numbers we need to multiply as parameters
            var asyncResult = delMultiplyNumbers.BeginInvoke(4, 3, null, null);

            Console.WriteLine("MultiplyNumbers ended");

            //Call EndInvoke passing the IAsyncResult object to retrieve the result.
            //This line will block the calling thread until the MultiplyNumbers method has completed execution
            int multipliedNumber = delMultiplyNumbers.EndInvoke(asyncResult);

            Console.WriteLine("Result of multiplication is {0}", multipliedNumber);

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

        private static int MultiplyNumbers(int x, int y)
        {
            //Create a delay to replicate a long running process
            Thread.Sleep(3000);
            return x * y;
        }
    }
}