using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace RxExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Observable.Create<int>(
                o =>
                    {
                        foreach (int x in Enumerable.Range(1, 10))
                            o.OnNext(x);

                        o.OnCompleted();
                        return Disposable.Empty;
                    });

            numbers.Subscribe(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
