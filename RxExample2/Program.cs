using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;

namespace RxExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Observable.Create<int>(
                o =>
                {
                    foreach (int x in Enumerable.Range(1, 10))
                    {
                        o.OnNext(x);
                        Thread.Sleep(1000);
                    }

                    o.OnCompleted();
                    return Disposable.Empty;
                });

            numbers.Subscribe(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
