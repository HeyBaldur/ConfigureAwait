using System.Threading;
using System;
using System.Threading.Tasks;

namespace ConfigureAwait.Tasks
{
    public class OperationService
    {
        /// <summary>
        /// Create a sum async using ConfigureAwait
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static async Task<int> SumAsyncWithConfigureAwait(int a, int b)
        {
            /// ConfigureAwait(false) can be used to tell the await keyword 
            /// that it should not resume execution on the original synchronization context 
            /// when the code after await completes. This can improve performance and can help 
            /// avoid deadlocks and other issues.
            Console.WriteLine($"SumAsync running on thread {Thread.CurrentThread.Name}");

            int sum = await Task.Run(() =>
            {
                if (Thread.CurrentThread.Name == null)
                {
                    Thread.CurrentThread.Name = Guid.NewGuid().ToString();
                }

                /// It's important to note that using ConfigureAwait(false) can have 
                /// implications for how your code behaves, especially if you're working 
                /// with user interfaces or other contexts that have specific synchronization 
                /// requirements. In general, it's a good practice to use ConfigureAwait(false) 
                /// when you're working with background tasks that don't require the original 
                /// synchronization context.
                Console.WriteLine($"Task.Run running on thread id: {Thread.CurrentThread.Name}");
                return a + b;
            }).ConfigureAwait(false);

            return sum;
        }

        /// <summary>
        /// Create a sum async without ConfigureAwait
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static async Task<int> SumAsync(int a, int b)
        {
            Console.WriteLine($"SumAsync running on thread {Thread.CurrentThread.Name}");

            int sum = await Task.Run(() =>
            {
                if (Thread.CurrentThread.Name == null)
                {
                    Thread.CurrentThread.Name = Guid.NewGuid().ToString();
                }

                Console.WriteLine($"Task.Run running on thread {Thread.CurrentThread.Name}");
                return a + b;
            });

            return sum;
        }
    }
}
