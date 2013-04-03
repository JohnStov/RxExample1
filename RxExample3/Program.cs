using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace RxExample3
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Observable.Interval(TimeSpan.FromMilliseconds(100), Scheduler.CurrentThread);

            numbers.Where(x => x % 2 == 0).Subscribe(Console.WriteLine);
        }
    }
}
