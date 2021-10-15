using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleAwaits
{
    class Program
    {
        static async Task Main()
        {
            //await MultipleAwaits();
            //Console.WriteLine("Main1 Main1 Main1!");

            //await MultipleAwaitsWhenAll();
            //Console.WriteLine("Main2 Main2 Main2!");

            await MultipleAwaitsWhenAny();
            Console.WriteLine("Main3 Main3 Main3!");

            Console.ReadLine();
        }

        // Here each task is not doing much more than suspending the current thread for a spell
        static async Task MultipleAwaits()
        {
            await Task.Run(() => { Thread.Sleep(4000); });
            Console.WriteLine("Done with first task!");

            await Task.Run(() => { Thread.Sleep(500); });
            Console.WriteLine("Done with second task!");

            await Task.Run(() => { Thread.Sleep(1000); });
            Console.WriteLine("Done with third task!");
        }

        // Another option is to not await each task but await them all together.
        // This is a more likely scenario, where there are three things(check email, update server, download files)
        // that must be completed in a batch, but can be done in parallel.
        // Here is the code updated using the Task.WhenAll() method
        static async Task MultipleAwaitsWhenAll()
        {
            var task1 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Done with first task!");
            });

            Console.WriteLine("TEST1!");

            var task2 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Done with second task!");
            });

            Console.WriteLine("TEST2");
            
            var task3 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Done with third task!");
            });

            await Task.WhenAll(task1, task2, task3);
        }

        static async Task MultipleAwaitsWhenAny()
        {
            var task1 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Done with first task!");
            });

            Console.WriteLine("TEST1!");

            var task2 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Done with second task!");
            });

            Console.WriteLine("TEST2");

            var task3 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Done with third task!");
            });

            await Task.WhenAny(task1, task2, task3);
        }
    }
}