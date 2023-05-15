using ConfigureAwait.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureAwait
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Thread.CurrentThread.Name = "MainThread";

            Console.WriteLine($"Main running on thread {Thread.CurrentThread.Name}");

            for (int i = 0; i < 10; i++)
            {
                /// When you use the await keyword in C#, the code after it is executed 
                /// on a different thread from the one that called it.
                var result = await OperationService.SumAsyncWithConfigureAwait(i, i + 1);
                Console.WriteLine($"the result is: {result}");
            }
        }
    }
}
