using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using Xunit;


namespace ConsoleApplication1
{
    class Program
    {
        private static readonly IObservable<int> numSequence = Observable.Interval(TimeSpan.FromSeconds(1)).Zip(Enumerable.Range(1, 10), (tick, index) => index);
        
        static void Main(string[] args)
        {
            
            numSequence.Subscribe(Console.WriteLine);

            Console.ReadKey();
        }

        [Fact]
        public void SequenceValueIs8After7Seconds()
        {
            int value = 0;

            numSequence.Subscribe(x => value = x);

            Thread.Sleep(7100);

            Assert.Equal(value, 8);
        }
    }
}
